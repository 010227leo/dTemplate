using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dTemplate
{
	public class ProjectGenerator
	{
		private readonly string _projectName;
		private readonly string _templatePath;
		private readonly string _templatePlaceholder;

		private static readonly HashSet<string> NeedRewriteFileExtensions = new HashSet<string>() { ".cs", ".sln", ".csproj", ".cshtml", ".master", ".aspx", ".asax", ".config", ".xml" };
		private static readonly HashSet<string> IgnoreFileExtensions = new HashSet<string>() { ".dll", ".pdb" };

		public ProjectGenerator(string projectName, string templatePath, string templatePlaceholder)
		{
			if (string.IsNullOrWhiteSpace(projectName))
				throw new ArgumentNullException("projectName");

			if (!Directory.Exists(templatePath))
				throw new DirectoryNotFoundException("template path does not exist");

			if (string.IsNullOrWhiteSpace(templatePlaceholder))
				throw new ArgumentNullException("templatePlaceholder");

			_projectName = projectName;
			_templatePath = templatePath;
			_templatePlaceholder = templatePlaceholder;
		}

		public void Create(string outputPath)
		{
			if (Directory.Exists(outputPath))
				Directory.Delete(outputPath, true);

			Directory.CreateDirectory(outputPath);

			Create(_templatePath, outputPath);
		}

		private void Create(string currentTemplatePath, string currentOutputPath)
		{
			var templateFiles = Directory.GetFiles(currentTemplatePath);

			foreach (var templateFileFullName in templateFiles)
			{
				CreateFileAsync(templateFileFullName, currentOutputPath);
			}

			var templateDirs = Directory.GetDirectories(currentTemplatePath);

			foreach (var templateDirFullName in templateDirs)
			{
				var templateDirName = Path.GetFileName(templateDirFullName);
				var outputDirName = ReplaceProjectName(templateDirName);
				var outputDirFullName = Path.Combine(currentOutputPath, outputDirName);

				Directory.CreateDirectory(outputDirFullName);

				Create(templateDirFullName, outputDirFullName);
			}
		}

		private async void CreateFileAsync(string templateFileFullName, string currentOutputPath)
		{
			var fileExtension = Path.GetExtension(templateFileFullName);

			if (string.IsNullOrWhiteSpace(fileExtension))
				return;

			if (IgnoreFileExtensions.Contains(fileExtension.ToLower()))
				return;

			var templateFilename = Path.GetFileName(templateFileFullName);
			var outputFilename = ReplaceProjectName(templateFilename);
			var outputFileFullName = Path.Combine(currentOutputPath, outputFilename);

			if (NeedRewriteFileExtensions.Contains(fileExtension))
			{
				using (var streamReader = new StreamReader(templateFileFullName, Encoding.UTF8))
				{
					var content = streamReader.ReadToEndAsync();
					var replacedContent = ReplaceProjectName(await content);

					using (var fileStream = new FileStream(outputFileFullName, FileMode.CreateNew))
					{
						using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
						{
							await streamWriter.WriteAsync(replacedContent);
						}
					}
				}
			}
			else
			{
				File.Copy(templateFileFullName, outputFileFullName);
			}
		}

		private string ReplaceProjectName(string input)
		{
			return Regex.Replace(input, _templatePlaceholder, _projectName);
		}
	}
}
