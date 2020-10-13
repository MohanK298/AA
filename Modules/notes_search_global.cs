/*
 * Created by Ranorex
 * User: qa
 * Date: 9/23/2020
 * Time: 4:13 PM
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
	/// Description of notes_search_global.
	/// </summary>
	[TestModule("FC82D37E-BA8D-417B-9E9E-CC39A52D8963", ModuleType.UserCode, 1)]
	public class notes_search_global : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public notes_search_global()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		
		Note notes=Note.Instance;
		Common cmn=new Common();
		string inSearch="Frequently-used text";
		int count=0;
		
		private void notes_search()
		{
			notes.MainForm.Self.Activate();
			notes.MainForm.btnNotes.Click();
			Delay.Seconds(2);
			notes.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			notes.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(notes.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				notes.Search.PnlBase.txtSearch.PressKeys("Test");
				notes.Search.PnlBase.btnIn.Click();
				notes.var=inSearch;
				Delay.Milliseconds(500);
				notes.DropDownForm.TreeItem.Click();
				
				notes.Search.Toolbar1.btnFindNow.Click();
				
				if(notes.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.Attribute(notes.SearchResult.PnlBase.txtShowingFieldInfo,"Text","Notes","Showing Fields is displayed correctly");
					Validate.Attribute(notes.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
					Validate.AttributeContains(notes.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(notes.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					notes.SearchResult.Toolbar1.btnClose.Click();
					
					
					
					
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
			notes_search();
			cmn.ClosePrompt();
		}
	}
}
