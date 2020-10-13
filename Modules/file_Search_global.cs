/*
 * Created by Ranorex
 * User: qa
 * Date: 9/23/2020
 * Time: 2:07 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
	/// <summary>
	/// Description of file_Search_global.
	/// </summary>
	[TestModule("3C514C9C-9907-418A-AF42-F73B5CBBF6FF", ModuleType.UserCode, 1)]
	public class file_Search_global : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public file_Search_global()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		
		Files file=Files.Instance;
		Common cmn=new Common();
		string inSearch="Frequently-used text";
		int count=0;
		
		private void file_search()
		{
			file.MainForm.Self.Activate();
			file.MainForm.btnFiles1.Click();
			Delay.Seconds(2);
			file.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			file.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(file.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				file.Search.PnlBase.txtSearch.PressKeys("Test");
				file.Search.PnlBase.btnIn.Click();
				file.var=inSearch;
				Delay.Milliseconds(500);
				file.DropDownForm.TreeItem.Click();
				
				file.Search.Toolbar1.btnFindNow.Click();
				
				if(file.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.Attribute(file.SearchResult.PnlBase.txtShowingFieldInfo,"Text","Files","Showing Fields is displayed correctly");
					Validate.Attribute(file.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
					Validate.AttributeContains(file.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(file.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					file.SearchResult.Toolbar1.btnClose.Click();
					
					
					
					
				}
				
				
				
				
				
			}
			
			
			
		}

		/// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		void ITestModule.Run()
		{
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
			file_search();
			cmn.ClosePrompt();
		}
	}
}
