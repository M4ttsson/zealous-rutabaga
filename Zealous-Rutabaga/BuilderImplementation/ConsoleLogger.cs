using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderImplementation
{
	public class ConsoleLogger : ILogger
	{
		public string Parameters
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public LoggerVerbosity Verbosity
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public void Initialize(IEventSource eventSource)
		{
			eventSource.ErrorRaised += new BuildErrorEventHandler(eventSource_ErrorRaised);

		}

		void eventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
		{
			// BUILDERROREVENTARGS ADDS LINENUMBER, COLUMNNUMBER, FILE, AMONGST OTHER PARAMETERS
			string line = String.Format(": ERROR {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);

			using (StreamWriter sw = new StreamWriter("logfil.txt"))
			{
				sw.WriteLine(line);
			}
		}

		public void Shutdown()
		{
			
		}
	}
}
