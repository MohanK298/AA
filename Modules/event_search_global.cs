/*
 * Created by Ranorex
 * User: qa
 * Date: 9/23/2020
 * Time: 3:49 PM
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
	/// Description of event_search_global.
	/// </summary>
	[TestModule("269F982C-19D1-4F1B-8330-35F837487215", ModuleType.UserCode, 1)]
	public class event_search_global : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public event_search_global()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		
		
		Calendar cal=Calendar.Instance;
		Common cmn=new Common();
		string inSearch="Frequently-used text";
		int count=0;
		
		private void event_search()
		{
			cal.MainForm.Self.Activate();
			cal.MainForm.btnCalendar.Click();
			Delay.Seconds(2);
			cal.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			cal.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(cal.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				cal.Search.PnlBase.txtSearch.PressKeys("Test");
				cal.Search.PnlBase.btnIn.Click();
				cal.var=inSearch;
				Delay.Milliseconds(500);
				cal.DropDownForm.TreeItem.Click();
				
				cal.Search.Toolbar1.btnFindNow.Click();
				
				if(cal.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.Attribute(cal.SearchResult.PnlBase.txtShowingFieldInfo,"Text","Events","Showing Fields is displayed correctly");
					Validate.Attribute(cal.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
					Validate.AttributeContains(cal.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(cal.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					cal.SearchResult.Toolbar1.btnClose.Click();
					
					
					
					
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
			event_search();
			cmn.ClosePrompt();
		}
	}
}
