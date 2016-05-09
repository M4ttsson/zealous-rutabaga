using BuilderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace BuilderImplementation
{
	public class MSBuildConfiguration : IBuildConfiguration
	{
		public ILogger BuildLogger { get; set; }
		public IDictionary<string, string> GlobalProperties { get; set; }
		public string[] Targets { get; set; }

		public MSBuildConfiguration()
		{

		}

		public void InitBuild()
		{
			BuildLogger = new ConsoleLogger();
			GlobalProperties = new Dictionary<string, string>();
			GlobalProperties.Add("Configuration", "Debug");
			GlobalProperties.Add("Platform", "Any CPU");

			Targets = new string[] { "Build" };
		}

		public void InitRebuild()
		{
			BuildLogger = new ConsoleLogger();
			GlobalProperties = new Dictionary<string, string>();
			GlobalProperties.Add("Configuration", "Debug");
			GlobalProperties.Add("Platform", "Any CPU");

			Targets = new string[] { "Rebuild" };
		}

		public void InitClean()
		{
			BuildLogger = new ConsoleLogger();
			GlobalProperties = new Dictionary<string, string>();
			GlobalProperties.Add("Configuration", "Debug");
			GlobalProperties.Add("Platform", "Any CPU");

			Targets = new string[] { "Clean" };
		}
	}
}
