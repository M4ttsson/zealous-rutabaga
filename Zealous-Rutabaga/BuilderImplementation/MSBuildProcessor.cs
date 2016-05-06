using BuilderInterfaces;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderImplementation
{
	public class MSBuildProcessor : IBuildProcessor
	{
		public IBuildConfiguration Configuration { get; set; }

		public bool Success
		{
			get;
			private set;
		}

		public void Build(string solutionPath)
		{
			ProjectCollection pc = new ProjectCollection();

			//Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
			//GlobalProperty.Add("Configuration", "Debug");
			//GlobalProperty.Add("Platform", "Any CPU");

			BuildParameters bp = new BuildParameters(pc);
			ConsoleLogger log = new ConsoleLogger();
			bp.Loggers = new List<ILogger>() { Configuration.BuildLogger };
			
			BuildRequestData buildRequest = new BuildRequestData(solutionPath, Configuration.GlobalProperties, null, Configuration.Targets, null);

			BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, buildRequest);

			if (buildResult.OverallResult == BuildResultCode.Success)
				Success = true;
			else
				Success = false;
		}

		public void Build(string projectPath, string outputPath)
		{
			throw new NotImplementedException();
		}
	}
}
