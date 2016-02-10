using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderInterfaces
{
	public interface IBuildConfiguration
	{
		IDictionary<string, string> GlobalProperties { get; set; }
		ILogger BuildLogger { get; set; }
		string[] Targets { get; set; }
	}
}
