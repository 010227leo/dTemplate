using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dTemplate
{
	public class ProjectGenerator
	{
		private const string TEMPLATE_PLACEHOLDER = "dTemplate";

		private static readonly string _templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template");
		private static readonly string[] _needRewriteFileExtensions = new string[] { ".sln", ".csproj", ".config", ".cs", ".cshtml", ".asax" };
		private static readonly string[] _ignoreFileExtensions = new string[] { ".dll", ".pdb" };

		public static void Create(string projectName, string outputPath)
		{
			if (string.IsNullOrWhiteSpace(projectName))
				throw new ArgumentNullException("projectName");

			if (!Directory.Exists(_templatePath))
				throw new Exception("template path does not exist");

			if (Directory.Exists(outputPath))
				Directory.Delete(outputPath, true);

			Directory.CreateDirectory(outputPath);

			Create(projectName, _templatePath, outputPath);

			Console.WriteLine("{0} created!", projectName);
		}

		private static void Create(string projectName, string currentTemplatePath, string currentOutputPath)
		{
			var templateFiles = Directory.GetFiles(currentTemplatePath);

			foreach (var templateFileFullName in templateFiles)
			{
				CreateFile(projectName, templateFileFullName, currentOutputPath);
			}

			var templateDirs = Directory.GetDirectories(currentTemplatePath);

			foreach (var templateDirFullName in templateDirs)
			{
				var templateDirName = Path.GetFileName(templateDirFullName);
				var outputDirName = Regex.Replace(templateDirName, TEMPLATE_PLACEHOLDER, projectName);
				var outputDirFullName = Path.Combine(currentOutputPath, outputDirName);

				Directory.CreateDirectory(outputDirFullName);

				Create(projectName, templateDirFullName, outputDirFullName);
			}
		}

		private static void CreateFile(string projectName, string templateFileFullName, string currentOutputPath)
		{
			var fileExtension = Path.GetExtension(templateFileFullName);

			if (_ignoreFileExtensions.Contains(fileExtension))
				return;

			var templateFilename = Path.GetFileName(templateFileFullName);
			var outputFilename = Regex.Replace(templateFilename, TEMPLATE_PLACEHOLDER, projectName);
			var outputFileFullName = Path.Combine(currentOutputPath, outputFilename);

			if (_needRewriteFileExtensions.Contains(fileExtension))
			{
				using (var streamReader = new StreamReader(templateFileFullName, Encoding.UTF8))
				{
					var content = streamReader.ReadToEnd();
					var replacedContent = Regex.Replace(content, TEMPLATE_PLACEHOLDER, projectName);

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
	}
}
