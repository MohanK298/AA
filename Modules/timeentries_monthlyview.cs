/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/9/2020
 * Time: 9:55 AM
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
    /// Description of timeentries_monthlyview.
    /// </summary>
    [TestModule("0F714CAE-91ED-42E0-BD42-BF4770F05F61", ModuleType.UserCode, 1)]
    public class timeentries_monthlyview : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public timeentries_monthlyview()
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
		
        private void TimeEntryExists_MonthlyView()
        {
        	
        	string strday1,strweek;
			System.DateTime day1;
			day1=System.DateTime.Now;
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkMonthly.Click();
        	Delay.Seconds(1);
        	
        	//Time Entry exists in current day
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the date -{0}",strday1));
        		}
        	}
        	
        	
        	//Time Entry exists in past  day
        	day1=System.DateTime.Now.AddDays(-1);
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the date -{0}",strday1));
        		}
        	}
        	
        	
        	//Time Entry exists in future  day
        	day1=System.DateTime.Now.AddDays(1);
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		if(ts.MainForm.txtappointmentInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Time Entry Exists for the date -{0}",strday1));
        		}
        	}
        	
        	
        }
		
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            TimeEntryExists_MonthlyView();
        }
    }
}
