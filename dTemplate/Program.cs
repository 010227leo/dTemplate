using System;
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
				var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");

				ProjectGenerator.Create(projectName, outputPath);
			}
			catch (Exception ex)
			{
				Console.WriteLine("ProjectGenerator.Create error: {0}", ex.Message);
				Console.WriteLine(ex.StackTrace);
			}

			Console.ReadKey(true);
		}
	}
}
