using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dTemplate
{
	public class ProjectGenerator
	{
		private string _projectName;
		private string _templatePath;
		private string _templatePlaceholder;

		private static readonly HashSet<string> _needRewriteFileExtensions = new HashSet<string>() { ".cs", ".sln", ".csproj", ".cshtml", ".master", ".aspx", ".asax", ".config", ".xml" };
		private static readonly HashSet<string> _ignoreFileExtensions = new HashSet<string>() { ".dll", ".pdb" };

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
				CreateFile(templateFileFullName, currentOutputPath);
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

		private void CreateFile(string templateFileFullName, string currentOutputPath)
		{
			var fileExtension = Path.GetExtension(templateFileFullName).ToLower();

			if (_ignoreFileExtensions.Contains(fileExtension))
				return;

			var templateFilename = Path.GetFileName(templateFileFullName);
			var outputFilename = ReplaceProjectName(templateFilename);
			var outputFileFullName = Path.Combine(currentOutputPath, outputFilename);

			if (_needRewriteFileExtensions.Contains(fileExtension))
			{
				using (var streamReader = new StreamReader(templateFileFullName, Encoding.UTF8))
				{
					var content = streamReader.ReadToEnd();
					var replacedContent = ReplaceProjectName(content);

					using (var fileStream = new FileStream(outputFileFullName, FileMode.CreateNew))
					{
						using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
						{
							streamWriter.Write(replacedContent);
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
