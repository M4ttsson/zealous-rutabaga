﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderInterfaces
{
	public interface IBuildProcessor
	{
		IBuildConfiguration Configuration { get; set; }

		void Build(string solutionPath);
		void Build(string projectPath, string outputPath);
		bool Success { get; }
	}
}
