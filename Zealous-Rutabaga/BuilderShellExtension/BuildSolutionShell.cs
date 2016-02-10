using BuilderImplementation;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuilderShellExtension
{
	[ComVisible(true)]
	[COMServerAssociation(AssociationType.ClassOfExtension, ".sln")]
	public class BuildSolutionShell : SharpContextMenu
	{
		protected override bool CanShowMenu()
		{
			return true;
		}

		protected override ContextMenuStrip CreateMenu()
		{
			var menu = new ContextMenuStrip();

			var itemCountLines = new ToolStripMenuItem
			{
				Text = "Build Solution"
			};

			itemCountLines.Click += (sender, args) => BuildSolution();
			menu.Items.Add(itemCountLines);
			return menu;
		}

		private void BuildSolution()
		{
			var builder = new MSBuildProcessor();
			var config = new MSBuildConfiguration();
			config.InitDebugBuild();
			builder.Configuration = config;
			var message = new StringBuilder();

			foreach(var filePath in SelectedItemPaths)
			{
				if(Path.GetExtension(filePath).Equals(".sln"))
				{
					builder.Build(filePath);

					if (builder.Success)
						message.AppendLine(filePath + " was built successfully");
					else
						message.AppendLine("Failed build for " + filePath);
				}
			}

			MessageBox.Show(message.ToString());
		}
	}
}
