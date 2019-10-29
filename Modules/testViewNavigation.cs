/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-24
 * Time: 3:54 PM
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
    /// Description of testViewNavigation.
    /// </summary>
    [TestModule("A50C2C9B-E677-4477-8C5E-570D20D59E2B", ModuleType.UserCode, 1)]
    public class testViewNavigation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Common cmn=new Common();
        Calendar calendar=Calendar.Instance;
        public testViewNavigation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void viewNavigation()
        {
        	calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.Toolbar.btnWeek.Click();
        	/*if(calendar.MainForm.PnlViews.PnlWeekView.Visible)
        	{
        		Report.Success("Successfully navigated to Weekly View");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Weekly View");
        	}
        	calendar.MainForm.Toolbar.btnMonth.Click();
        	if(calendar.MainForm.PnlViews.PnlMonthView.Visible)
        	{
        		Report.Success("Successfully navigated to Monthly View");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Monthly View");
        	}
        	calendar.MainForm.Toolbar.btnDay.Click();
        	if(calendar.MainForm.PnlViews.PnlDayView.Visible)
        	{
        		Report.Success("Successfully navigated to Daily View");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Daily View");
        	}
        	calendar.MainForm.Toolbar.btnYear.Click();
        	if(calendar.MainForm.PnlViews.PnlYearView.Visible)
        	{
        		Report.Success("Successfully navigated to Yearly View");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Yearly View");
        	}
        	calendar.MainForm.Toolbar.btnRange.Click();
        	if(calendar.MainForm.PnlViews.PnlDayView.Visible)
        	{
        		Report.Success("Successfully navigated to Weekly View");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Weekly View");
        	}*/
        	
        	cmn.SelectItemDropdown(calendar.MainForm.Toolbar.cbbxListsMenu,"All My Events","Events Dropdown");
        	if(calendar.MainForm.tblCalendar.Visible && calendar.MainForm.txtLabelInfo.Name.Equals("All My Events"))
        	{
        		Report.Success("Successfully navigated to All My Events");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to All My Events");
        	}
        	
        	cmn.SelectItemDropdown(calendar.MainForm.Toolbar.cbbxListsMenu,"Holidays","Events Dropdown");
        	if(calendar.MainForm.tblCalendar.Visible && calendar.MainForm.txtLabelInfo.Name.Equals("Holidays"))
        	{
        		Report.Success("Successfully navigated to Holidays");
        	}
        	else
        	{
        		Report.Failure("Failed to navigate to Holidays");
        	}
        
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            viewNavigation();
        }
    }
}
