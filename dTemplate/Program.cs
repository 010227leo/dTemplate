using System;
using System.Diagnostics;
using System.IO;

namespace dTemplate
{
	class Program
	{
		static void Main(string[] args)
		{
			var projectName = string.Empty;

			while (string.IsNullOrWhiteSpace(projectName))
			{
				Console.Clear();
				Console.WriteLine("Project name:");

				projectName = Console.ReadLine();
			}

			try
			{
				var stopwatch = Stopwatch.StartNew();

				var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template");
				var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
				var projectGenerator = new ProjectGenerator(projectName, templatePath, "dTemplate");

				projectGenerator.Create(outputPath);

				stopwatch.Stop();

				Console.WriteLine("{0} created! cost: {1}ms.", projectName, stopwatch.ElapsedMilliseconds);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Create project error: {0}.", ex.Message);
			}

			Console.ReadKey(true);
		}
	}
}
