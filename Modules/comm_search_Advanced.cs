/*
 * Created by Ranorex
 * User: qa
 * Date: 9/24/2020
 * Time: 4:10 PM
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
	/// Description of comm_search_Advanced.
	/// </summary>
	[TestModule("1C87368D-8924-413E-B1AF-61F57DB7D2D7", ModuleType.UserCode, 1)]
	public class comm_search_Advanced : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public comm_search_Advanced()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		Communications comm=Communications.Instance;
		Common cmn=new Common();
		
		string type="E-mail";
		int count=0;
		
		private void Communication_search_Advanced()
		{
			
			
			System.DateTime date = System.DateTime.Now;
			var firstDayOfMonth = new System.DateTime(date.Year, date.Month, 1);
			var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
			Report.Info(firstDayOfMonth.ToShortDateString());
			Report.Info(lastDayOfMonth.ToShortDateString());
			
			comm.MainForm.Self.Activate();
			comm.MainForm.btnCommunications.Click();
			Delay.Seconds(2);
			comm.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			comm.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(comm.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				
				comm.Search.PnlBase.btnType.Click();
				comm.var=type;
				Delay.Milliseconds(500);
				comm.DropDownForm.TreeItem.Click();
				
				
				comm.Search.PnlBase.rdoAdvanced.Select();
				Report.Success("Advance Radio Button is selected");	
//				
				comm.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(comm.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					comm.SearchCriteria.PnlBase.btnType.Click();
					comm.var="Date";
					Delay.Milliseconds(500);
					comm.DropDownForm.TreeItem.Click();
					
					comm.SearchCriteria.PnlBase.btnCondition.Click();
					comm.var="Greater Than";
					Delay.Milliseconds(500);
					comm.DropDownForm.TreeItem.Click();
					comm.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					comm.SearchCriteria.PnlBase.txtValue.PressKeys(firstDayOfMonth.ToShortDateString());
					Report.Success("First Day of Month is entered");
					comm.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(comm.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(comm.SearchItemSelectForm.Panel1.tbSelection,"Email Date","Field Selection Table");
						comm.SearchItemSelectForm.Panel1.tbAdd.Click();
						comm.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					comm.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				}
				comm.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(comm.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					comm.SearchCriteria.PnlBase.btnType.Click();
					comm.var="Date";
					Delay.Milliseconds(500);
					comm.DropDownForm.TreeItem.Click();
					
					comm.SearchCriteria.PnlBase.btnCondition.Click();
					comm.var="Less Than";
					Delay.Milliseconds(500);
					comm.DropDownForm.TreeItem.Click();
					
					comm.SearchCriteria.PnlBase.btnLogicalOperator.Click();
					comm.var="And";
					Delay.Milliseconds(500);
					comm.DropDownForm.TreeItem.Click();
					comm.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					comm.SearchCriteria.PnlBase.txtValue.PressKeys(lastDayOfMonth.ToShortDateString());
					Report.Success("Last Day of Month is entered");
					comm.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(comm.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(comm.SearchItemSelectForm.Panel1.tbSelection,"Email Date","Field Selection Table");
						comm.SearchItemSelectForm.Panel1.tbAdd.Click();
						comm.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					comm.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				
				}
				comm.Search.Toolbar1.btnFindNow.Click();
				
				if(comm.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.AttributeContains(comm.SearchResult.PnlBase.txtShowingFieldInfo,"Text","Email","Showing Fields is displayed correctly");
					Validate.AttributeContains(comm.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
//					Validate.AttributeContains(comm.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(comm.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					comm.SearchResult.Toolbar1.btnClose.Click();
					
					
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
			Communication_search_Advanced();
			cmn.ClosePrompt();
		}
	}
}
