/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/9/2020
 * Time: 11:10 AM
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
    /// Description of timentries_monthlyview_navigatebtwdays.
    /// </summary>
    [TestModule("414365F1-94C4-4BA3-BBFB-0765284D23FD", ModuleType.UserCode, 1)]
    public class timentries_monthlyview_navigatebtwdays : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public timentries_monthlyview_navigatebtwdays()
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
        private void monthly_navigate_view()
        {
        	string strday1,strweek,strday2;
			System.DateTime day1;
			day1=System.DateTime.Now;
			strday1=day1.ToString("MMMM d, yyyy");
			strday2=day1.ToString("ddd, MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	ts.curwkday1=strday2;
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkMonthly.Click();
        	Delay.Seconds(1);
        	//Validating current day
        	ts.MainForm.PnlWhole.txtcurrentday.Click();
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		Validate.AttributeContains(ts.MainForm.shrtDayInfo,"AccessibleState","Selected, Focused,",String.Format("Currently Focused on the current Date - {0}",strday1));
        	}
        	
        	
        	//Navigating to previous day
        	day1=System.DateTime.Now.AddDays(-1);
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
        	ts.MainForm.PnlWhole.prevDay.Click();
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		Validate.AttributeContains(ts.MainForm.shrtDayInfo,"AccessibleState","Selected, Focused,",String.Format("Currently Focused on the Date after navigating to previous day - {0}",strday1));
        	}
        	
        	//Navigating to future day
        	day1=System.DateTime.Now.AddDays(1);
			strday1=day1.ToString("MMMM d, yyyy");
			strweek="Week "+Int32.Parse(cmn.GetWeekOfYear(day1).ToString());
			ts.curwk=strweek;
        	ts.curwkday=strday1;
			ts.MainForm.PnlWhole.nxtDay.Click();
        	Delay.Seconds(1);
        	ts.MainForm.PnlWhole.nxtDay.Click();
        	if(ts.MainForm.shrtDayInfo.Exists(5000))
        	{
        		Validate.AttributeContains(ts.MainForm.shrtDayInfo,"AccessibleState","Selected, Focused,",String.Format("Currently Focused on the Date after navigating to next day - {0}",strday1));
        	}
        	ts.MainForm.PnlWhole.prevDay.Click();

        	
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            monthly_navigate_view();
        }
    }
}
