/*
 * Created by Ranorex
 * User: qa
 * Date: 9/24/2020
 * Time: 4:21 PM
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
	/// Description of notes_Search_Advanced.
	/// </summary>
	[TestModule("DD76BD39-1C71-4CBC-95D0-2E84EE3BFB8E", ModuleType.UserCode, 1)]
	public class notes_Search_Advanced : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public notes_Search_Advanced()
		{
			// Do not delete - a parameterless constructor is required!
		}

		Note notes=Note.Instance;
		Common cmn=new Common();
		
		string type="Notes";
		int count=0;
		
		private void Notes_search_Advanced()
		{
			
			
			System.DateTime date = System.DateTime.Now;
			var firstDayOfMonth = new System.DateTime(date.Year, date.Month, 1);
			var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
			Report.Info(firstDayOfMonth.ToShortDateString());
			Report.Info(lastDayOfMonth.ToShortDateString());
			
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
				
				notes.Search.PnlBase.btnType.Click();
				notes.var=type;
				Delay.Milliseconds(500);
				notes.DropDownForm.TreeItem.Click();
				
				
				notes.Search.PnlBase.rdoAdvanced.Select();
				Report.Success("Advance Radio Button is selected");	
//				
				notes.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(notes.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					notes.SearchCriteria.PnlBase.btnType.Click();
					notes.var="Date";
					Delay.Milliseconds(500);
					notes.DropDownForm.TreeItem.Click();
					
					notes.SearchCriteria.PnlBase.btnCondition.Click();
					notes.var="Greater Than";
					Delay.Milliseconds(500);
					notes.DropDownForm.TreeItem.Click();
					notes.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					notes.SearchCriteria.PnlBase.txtValue.PressKeys(firstDayOfMonth.ToShortDateString());
					Report.Success("First Day of Month is entered");
					notes.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(notes.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(notes.SearchItemSelectForm.Panel1.tbSelection,"Note Date","Field Selection Table");
						notes.SearchItemSelectForm.Panel1.tbAdd.Click();
						notes.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					notes.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				}
				notes.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(notes.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					notes.SearchCriteria.PnlBase.btnType.Click();
					notes.var="Date";
					Delay.Milliseconds(500);
					notes.DropDownForm.TreeItem.Click();
					
					notes.SearchCriteria.PnlBase.btnCondition.Click();
					notes.var="Less Than";
					Delay.Milliseconds(500);
					notes.DropDownForm.TreeItem.Click();
					
					notes.SearchCriteria.PnlBase.btnLogicalOperator.Click();
					notes.var="And";
					Delay.Milliseconds(500);
					notes.DropDownForm.TreeItem.Click();
					notes.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					notes.SearchCriteria.PnlBase.txtValue.PressKeys(lastDayOfMonth.ToShortDateString());
					Report.Success("Last Day of Month is entered");
					notes.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(notes.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(notes.SearchItemSelectForm.Panel1.tbSelection,"Note Date","Field Selection Table");
						notes.SearchItemSelectForm.Panel1.tbAdd.Click();
						notes.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					notes.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				
				}
				notes.Search.Toolbar1.btnFindNow.Click();
				
				if(notes.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.AttributeContains(notes.SearchResult.PnlBase.txtShowingFieldInfo,"Text",type,"Showing Fields is displayed correctly");
					Validate.AttributeContains(notes.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
//					Validate.AttributeContains(notes.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
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
			Notes_search_Advanced();
			cmn.ClosePrompt();
		}
	}
}
