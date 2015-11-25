using BuilderInterfaces;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderImplementation
{
	public class MSBuildProcessor : IBuildProcessor
	{
		public void Build(string solutionPath)
		{

		}

		public void Build(string projectPath, string outputPath)
		{
			throw new NotImplementedException();
		}
	}
}
