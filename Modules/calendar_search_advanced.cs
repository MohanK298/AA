/*
 * Created by Ranorex
 * User: qa
 * Date: 9/24/2020
 * Time: 3:33 PM
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
	/// Description of calendar_search_advanced.
	/// </summary>
	[TestModule("5DB9DC99-4FBA-48BD-8D5A-1A96B2643FBF", ModuleType.UserCode, 1)]
	public class calendar_search_advanced : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public calendar_search_advanced()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		Calendar cal=Calendar.Instance;
		Common cmn=new Common();
		
		string type="Events";
		int count=0;
		
		private void Cal_search_Advanced()
		{
			
			
			System.DateTime date = System.DateTime.Now;
			var firstDayOfMonth = new System.DateTime(date.Year, date.Month, 1);
			var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
			Report.Info(firstDayOfMonth.ToShortDateString());
			Report.Info(lastDayOfMonth.ToShortDateString());
			
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
				
				cal.Search.PnlBase.btnType.Click();
				cal.var=type;
				Delay.Milliseconds(500);
				cal.DropDownForm.TreeItem.Click();
				
				
				cal.Search.PnlBase.rdoAdvanced.Select();
				Report.Success("Advance Radio Button is selected");	
//				
				cal.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(cal.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					cal.SearchCriteria.PnlBase.btnType.Click();
					cal.var="Date";
					Delay.Milliseconds(500);
					cal.DropDownForm.TreeItem.Click();
					
					cal.SearchCriteria.PnlBase.btnCondition.Click();
					cal.var="Greater Than";
					Delay.Milliseconds(500);
					cal.DropDownForm.TreeItem.Click();
					cal.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					cal.SearchCriteria.PnlBase.txtValue.PressKeys(firstDayOfMonth.ToShortDateString());
					Report.Success("First Day of Month is entered");
					cal.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(cal.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(cal.SearchItemSelectForm.Panel1.tbSelection,"Date","Field Selection Table");
						cal.SearchItemSelectForm.Panel1.tbAdd.Click();
						cal.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					cal.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				}
				cal.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(cal.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					cal.SearchCriteria.PnlBase.btnType.Click();
					cal.var="Date";
					Delay.Milliseconds(500);
					cal.DropDownForm.TreeItem.Click();
					
					cal.SearchCriteria.PnlBase.btnCondition.Click();
					cal.var="Less Than";
					Delay.Milliseconds(500);
					cal.DropDownForm.TreeItem.Click();
					
					cal.SearchCriteria.PnlBase.btnLogicalOperator.Click();
					cal.var="And";
					Delay.Milliseconds(500);
					cal.DropDownForm.TreeItem.Click();
					cal.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					cal.SearchCriteria.PnlBase.txtValue.PressKeys(lastDayOfMonth.ToShortDateString());
					Report.Success("Last Day of Month is entered");
					cal.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(cal.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(cal.SearchItemSelectForm.Panel1.tbSelection,"Date","Field Selection Table");
						cal.SearchItemSelectForm.Panel1.tbAdd.Click();
						cal.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					cal.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				
				}
				cal.Search.Toolbar1.btnFindNow.Click();
				
				if(cal.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.AttributeContains(cal.SearchResult.PnlBase.txtShowingFieldInfo,"Text",type,"Showing Fields is displayed correctly");
					Validate.AttributeContains(cal.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
//					Validate.AttributeContains(cal.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
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
			Cal_search_Advanced();
			cmn.ClosePrompt();
		}
	}
}
