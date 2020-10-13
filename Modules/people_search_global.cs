/*
 * Created by Ranorex
 * User: qa
 * Date: 9/23/2020
 * Time: 10:41 AM
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
	/// Description of people_search_global.
	/// </summary>
	[TestModule("A8ABC4E1-AE4F-4FB9-8943-EC066373D892", ModuleType.UserCode, 1)]
	public class people_search_global : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public people_search_global()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		People ppl=People.Instance;
		Common cmn=new Common();
		string inSearch="Frequently-used text fields";
		int count=0;
		
		private void people_search()
		{
			ppl.MainForm.Self.Activate();
			ppl.MainForm.btnPeople.Click();
			Delay.Seconds(2);
			ppl.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			ppl.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(ppl.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				ppl.Search.PnlBase.txtSearch.PressKeys("Test");
				ppl.Search.PnlBase.btnIn.Click();
				ppl.var=inSearch;
				Delay.Milliseconds(500);
				ppl.DropDownForm.TreeItem.Click();
				
				ppl.Search.Toolbar1.btnFindNow.Click();
				
				if(ppl.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.Attribute(ppl.SearchResult.PnlBase.txtShowingFieldInfo,"Text","Contacts","Showing Fields is displayed correctly");
					Validate.Attribute(ppl.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
					Validate.AttributeContains(ppl.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(ppl.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					ppl.SearchResult.Toolbar1.btnClose.Click();
					
					
					
					
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
			people_search();
			cmn.ClosePrompt();
		}
	}
}
