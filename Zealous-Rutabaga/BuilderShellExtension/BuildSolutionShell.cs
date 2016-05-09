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

			var topItemBuild = new ToolStripMenuItem
			{
				Text = "Build options"
			};

			topItemBuild.DropDownItems.Add("Clean", null, (s,a) => CleanSolution(s,a));
			topItemBuild.DropDownItems.Add("Build", null, (s, a) => BuildSolution(s, a));
			topItemBuild.DropDownItems.Add("Rebuild", null, (s, a) => ReBuildSolution(s, a));

			menu.Items.Add(topItemBuild);
			return menu;
		}

		protected void CleanSolution(object sender, EventArgs args)
		{
			var builder = new MSBuildProcessor();
			var config = new MSBuildConfiguration();
			config.InitClean();
			builder.Configuration = config;
			var message = new StringBuilder();

			DoBuildAction(builder, message);

			MessageBox.Show(message.ToString());
		}

		protected void BuildSolution(object sender, EventArgs args)
		{
			var builder = new MSBuildProcessor();
			var config = new MSBuildConfiguration();
			config.InitBuild();
			builder.Configuration = config;
			var message = new StringBuilder();

			DoBuildAction(builder, message);

			MessageBox.Show(message.ToString());
		}

		private void ReBuildSolution(object sender, EventArgs args)
		{
			var builder = new MSBuildProcessor();
			var config = new MSBuildConfiguration();
			config.InitRebuild();
			builder.Configuration = config;
			var message = new StringBuilder();

			DoBuildAction(builder, message);

			MessageBox.Show(message.ToString());
		}

		private void DoBuildAction(MSBuildProcessor builder, StringBuilder message)
		{
			foreach (var filePath in SelectedItemPaths)
			{
				if (Path.GetExtension(filePath).Equals(".sln"))
				{
					builder.Build(filePath);

					if (builder.Success)
						message.AppendLine(filePath + " was built successfully");
					else
						message.AppendLine("Failed build for " + filePath);
				}
			}
		}
	}
}
