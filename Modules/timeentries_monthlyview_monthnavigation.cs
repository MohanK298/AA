/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/9/2020
 * Time: 11:52 AM
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
    /// Description of timeentries_monthlyview_monthnavigation.
    /// </summary>
    [TestModule("594B7BEC-F506-4652-B8DD-F0DFE5E2A9D0", ModuleType.UserCode, 1)]
    public class timeentries_monthlyview_monthnavigation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public timeentries_monthlyview_monthnavigation()
        {
            // Do not delete - a parameterless constructor is required!
        }
		TimeSheets ts=TimeSheets.Instance;
		Common cmn=new Common();
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        private void CreateTE_MonthlyNavigation()
		{
			string strday1,strweek,strfrstdaymonthprev,strfrstdaymonthnxt;
			System.DateTime day1,frstdayMonthprev,firstdayMonthnxt;
			day1=System.DateTime.Now;
			frstdayMonthprev=new System.DateTime(day1.AddMonths(-1).Year, day1.AddMonths(-1).Month, 1);
			strfrstdaymonthprev= frstdayMonthprev.ToShortDateString();
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkMonthly.Click();
        	Delay.Seconds(1);
        	
        	
        	
        	// Created Time for current month
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Current Month and Day - {0}",System.DateTime.Now.ToShortDateString()));
        	
        	
        	
        	// Created Time for previous month
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.txtDate.PressKeys(strfrstdaymonthprev);
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Past Month - {0}",strfrstdaymonthprev));
        	
        	firstdayMonthnxt=new System.DateTime(day1.AddMonths(1).Year, day1.AddMonths(1).Month, 1);
			strfrstdaymonthnxt= firstdayMonthnxt.ToShortDateString();
        	
			
			// Created Time for future month
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.txtDate.PressKeys(strfrstdaymonthnxt);
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Next Month - {0}",strfrstdaymonthnxt));
        	
			
			//check time entries exist for current month		
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;

        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the current date and month -{0}",strday1));
        		}
        	}
        	
			//check time entries exist for first day of previous month
			ts.MainForm.PnlWhole.prevMonth.Click();
			Delay.Seconds(1);
			strday1=frstdayMonthprev.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(frstdayMonthprev).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;

        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the previous month first day -{0}",strday1));
        		}
        	}
        	
        	//check time entries exist for first day of next month
        	ts.MainForm.PnlWhole.nxtMonth.Click();
			Delay.Seconds(1);
			ts.MainForm.PnlWhole.nxtMonth.Click();
			Delay.Seconds(1);
        	strday1=firstdayMonthnxt.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(firstdayMonthnxt).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;

        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the next month first day -{0}",strday1));
        		}
        	}
        	ts.MainForm.PnlWhole.prevMonth.Click();
			Delay.Seconds(1);
        	
		}
        private void ClickTEinMonthlyView()
        {
        	string strday1,strweek;
			System.DateTime day1;
			day1=System.DateTime.Now;
        	strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	ts.MainForm.shrtDay.Click(Location.UpperCenter);
        	Delay.Seconds(2);
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,"Test","Time Sheet Entries");
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateTE_MonthlyNavigation();
            ClickTEinMonthlyView();
        }
    }
}
