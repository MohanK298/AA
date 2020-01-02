/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-22
 * Time: 2:00 PM
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
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
using Ranorex.AutomationHelpers.UserCodeCollections;
namespace SmokeTest
{
    /// <summary>
    /// Description of createRedLetterDay.
    /// </summary>
    [TestModule("F579159E-B184-4BCB-9325-0375B5F921B9", ModuleType.UserCode, 1)]
    public class createRedLetterDay : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
		Calendar calendar = Calendar.Instance;
        Common cmn=new Common();
        
        public createRedLetterDay()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Red Letter Day Added {0}",rndData);
		private void CreateRedLetterDayWithDragNDrop()
        {
			//calendar.MainForm.Self.Activate();
			System.DateTime day1;
			System.DateTime day2;
			string strday1,strday2;
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	cmn.SelectItemDropdown(calendar.EventDetailForm.PnlBase.SelectEvent,"Red Letter Day","Event Type Dropdown");
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");

        	calendar.MainForm.Toolbar.btnWeek.Click();
        	day1=System.DateTime.Now;
			day2=day1.AddDays(1);
			strday1=day1.ToString("MMMM d, yyyy");
			strday2=day2.ToString("MMMM d, yyyy");
			calendar.curwkday=strday1;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			//calendar.MainForm.PnlViews.txtappointment;
			Delay.Seconds(2);
			Ranorex.Text sourceappt=calendar.MainForm.PnlViews.txtappointment;
			calendar.curwkday=strday2;
			DragNDropLibrary.DragAndDrop(sourceappt,calendar.MainForm.PnlViews.shrtDay);
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateRedLetterDayWithDragNDrop();
            Common.ClosePrompt();
        }
    }
}
