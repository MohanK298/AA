/*
 * Created by Ranorex
 * User: qa
 * Date: 9/24/2020
 * Time: 3:50 PM
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
	/// Description of te_search_advanced.
	/// </summary>
	[TestModule("B9E2E2A4-E6C5-498F-80D3-DFFFD984BE46", ModuleType.UserCode, 1)]
	public class te_search_advanced : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public te_search_advanced()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		TimeSheets ts=TimeSheets.Instance;
		Common cmn=new Common();
		
		string type="Time";
		int count=0;
		
		private void Timesheet_search_Advanced()
		{
			
			
			System.DateTime date = System.DateTime.Now;
			var firstDayOfMonth = new System.DateTime(date.Year, date.Month, 1);
			var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
			Report.Info(firstDayOfMonth.ToShortDateString());
			Report.Info(lastDayOfMonth.ToShortDateString());
			
			ts.MainForm.Self.Activate();
			ts.MainForm.btnTimeSheets.Click();
			Delay.Seconds(2);
			ts.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			ts.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(ts.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				
				ts.Search.PnlBase.btnType.Click();
				ts.var=type;
				Delay.Milliseconds(500);
				ts.DropDownForm.TreeItem.Click();
				
				
				ts.Search.PnlBase.rdoAdvanced.Select();
				Report.Success("Advance Radio Button is selected");	
//				
				ts.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(ts.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					ts.SearchCriteria.PnlBase.btnType.Click();
					ts.var="Date";
					Delay.Milliseconds(500);
					ts.DropDownForm.TreeItem.Click();
					
					ts.SearchCriteria.PnlBase.btnCondition.Click();
					ts.var="Greater Than";
					Delay.Milliseconds(500);
					ts.DropDownForm.TreeItem.Click();
					ts.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					ts.SearchCriteria.PnlBase.txtValue.PressKeys(firstDayOfMonth.ToShortDateString());
					Report.Success("First Day of Month is entered");
					ts.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(ts.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(ts.SearchItemSelectForm.Panel1.tbSelection,"Date","Field Selection Table");
						ts.SearchItemSelectForm.Panel1.tbAdd.Click();
						ts.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					ts.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				}
				ts.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(ts.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					ts.SearchCriteria.PnlBase.btnType.Click();
					ts.var="Date";
					Delay.Milliseconds(500);
					ts.DropDownForm.TreeItem.Click();
					
					ts.SearchCriteria.PnlBase.btnCondition.Click();
					ts.var="Less Than";
					Delay.Milliseconds(500);
					ts.DropDownForm.TreeItem.Click();
					
					ts.SearchCriteria.PnlBase.btnLogicalOperator.Click();
					ts.var="And";
					Delay.Milliseconds(500);
					ts.DropDownForm.TreeItem.Click();
					ts.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					ts.SearchCriteria.PnlBase.txtValue.PressKeys(lastDayOfMonth.ToShortDateString());
					Report.Success("Last Day of Month is entered");
					ts.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(ts.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(ts.SearchItemSelectForm.Panel1.tbSelection,"Date","Field Selection Table");
						ts.SearchItemSelectForm.Panel1.tbAdd.Click();
						ts.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					ts.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				
				}
				ts.Search.Toolbar1.btnFindNow.Click();
				
				if(ts.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.AttributeContains(ts.SearchResult.PnlBase.txtShowingFieldInfo,"Text",type,"Showing Fields is displayed correctly");
					Validate.AttributeContains(ts.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
//					Validate.AttributeContains(ts.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(ts.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					ts.SearchResult.Toolbar1.btnClose.Click();
					
					
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
			Timesheet_search_Advanced();
			cmn.ClosePrompt();
		}
	}
}
