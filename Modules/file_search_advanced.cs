/*
 * Created by Ranorex
 * User: qa
 * Date: 9/24/2020
 * Time: 12:04 PM
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
	/// Description of file_search_advanced.
	/// </summary>
	[TestModule("D64A5952-89D2-43C6-96FB-F5CE13BB45BE", ModuleType.UserCode, 1)]
	public class file_search_advanced : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public file_search_advanced()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		Files file=Files.Instance;
		Common cmn=new Common();
		
		string type="Files";
		int count=0;
		
		private void file_search_Advanced()
		{
			
			
			System.DateTime date = System.DateTime.Now;
			var firstDayOfMonth = new System.DateTime(date.Year, date.Month, 1);
			var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
			Report.Info(firstDayOfMonth.ToShortDateString());
			Report.Info(lastDayOfMonth.ToShortDateString());
			
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
				
				file.Search.PnlBase.btnType.Click();
				file.var=type;
				Delay.Milliseconds(500);
				file.DropDownForm.TreeItem.Click();
				
				
				file.Search.PnlBase.rdoAdvanced.Select();
				Report.Success("Advance Radio Button is selected");	
//				
				file.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(file.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					file.SearchCriteria.PnlBase.btnType.Click();
					file.var="Date";
					Delay.Milliseconds(500);
					file.DropDownForm.TreeItem.Click();
					
					file.SearchCriteria.PnlBase.btnCondition.Click();
					file.var="Greater Than";
					Delay.Milliseconds(500);
					file.DropDownForm.TreeItem.Click();
					file.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					file.SearchCriteria.PnlBase.txtValue.PressKeys(firstDayOfMonth.ToShortDateString());
					Report.Success("First Day of Month is entered");
					file.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(file.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(file.SearchItemSelectForm.Panel1.tbSelection,"Open Date","Field Selection Table");
						file.SearchItemSelectForm.Panel1.tbAdd.Click();
						file.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					file.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				}
				file.Search.PnlBase.btnAddSearchCondition.Click();
				Report.Success("Add Search Condition Button is clicked");	
				
				if(file.SearchCriteria.SelfInfo.Exists(5000))
				{
					Report.Success("Search Criteria Window is opened");
					file.SearchCriteria.PnlBase.btnType.Click();
					file.var="Date";
					Delay.Milliseconds(500);
					file.DropDownForm.TreeItem.Click();
					
					file.SearchCriteria.PnlBase.btnCondition.Click();
					file.var="Less Than";
					Delay.Milliseconds(500);
					file.DropDownForm.TreeItem.Click();
					
					file.SearchCriteria.PnlBase.btnLogicalOperator.Click();
					file.var="And";
					Delay.Milliseconds(500);
					file.DropDownForm.TreeItem.Click();
					file.SearchCriteria.PnlBase.txtValueOutside.DoubleClick();
					Delay.Milliseconds(200);
					Keyboard.Press("{Back}");
					file.SearchCriteria.PnlBase.txtValue.PressKeys(lastDayOfMonth.ToShortDateString());
					Report.Success("Last Day of Month is entered");
					file.SearchCriteria.PnlBase.btnAddRemoveFields.Click();
					Report.Success("Add/Remove Fields Button is clicked");	
					if(file.SearchItemSelectForm.SelfInfo.Exists(4000))
					{
						Report.Success("Select Search Fields Window is opened");
						cmn.SelectItemFromTableSingleClick(file.SearchItemSelectForm.Panel1.tbSelection,"Open Date","Field Selection Table");
						file.SearchItemSelectForm.Panel1.tbAdd.Click();
						file.SearchItemSelectForm.Toolbar1.btnOk.Click();
						Report.Success("Ok Button is clicked");	
						
						
					}
					file.SearchCriteria.Toolbar1.btnOK.Click();
					Report.Success("Ok Button is clicked");	
					
				
				}
				file.Search.Toolbar1.btnFindNow.Click();
				
				if(file.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.AttributeContains(file.SearchResult.PnlBase.txtShowingFieldInfo,"Text",type,"Showing Fields is displayed correctly");
					Validate.AttributeContains(file.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
//					Validate.AttributeContains(file.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
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
			file_search_Advanced();
			cmn.ClosePrompt();
		}
	}
}
