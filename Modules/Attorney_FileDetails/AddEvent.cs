/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/27/2016
 * Time: 10:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    [TestModule("A3D17DD1-970E-48EF-AD79-E72A334A90D3", ModuleType.UserCode, 1)]
    public class AddEvent : ITestModule
    {
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	SmokeTest.Repositories.Calendar calendar = new SmokeTest.Repositories.Calendar();
    	
        public AddEvent()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _startTime = "";
        [TestVariable("75904198-39F1-4CB4-83CB-F550E31ABCFD")]
        public string startTime
        {
        	get { return _startTime; }
        	set { _startTime = value; }
        }
        
        string _endTime = "";
        [TestVariable("348C5E59-EC39-405E-9055-584F124DB04B")]
        public string endTime
        {
        	get { return _endTime; }
        	set { _endTime = value; }
        }
        
        string _location = "";
        [TestVariable("36A9567B-0556-43B0-8BED-067381B5D4D4")]
        public string location
        {
        	get { return _location; }
        	set { _location = value; }
        }
        
        public void Action(){
        	//PopupWatcher eventReminderPrompt = new PopupWatcher();
        	//eventReminderPrompt.WatchAndClick(calendar.EventReminderForm, calendar.EventReminderForm.btnIllBeThereInfo);
        	//eventReminderPrompt.Start();
        	Delay.Seconds(3);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	file.FileDetailForm.btnNew.Click();
        	Delay.Seconds(3);
        	
        	//Add data to create an appointment
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys("Test for Precedents App");
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(startTime);
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(endTime);
        	calendar.EventDetailForm.PnlBase.txtLocation.PressKeys(location);
        	
        	//Save the appointment
        	//PopupWatcher appointmentOverlapDialog = new PopupWatcher();
        	//appointmentOverlapDialog.WatchAndClick(calendar.AppointmentOverlapDialog, calendar.AppointmentOverlapDialog.btnOkInfo);
        	//appointmentOverlapDialog.Start();
        	
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(5);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	file.FileDetailForm.btnSaveClose.Click();
        	//appointmentOverlapDialog.Stop();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	Validate.Attribute(file.FileDetailForm.TitleInfo, "Text", "Test for Precedents App");
        	file.FileDetailForm.btnSaveClose.Click();
        	//eventReminderPrompt.Stop();
        	ValidateEventRemainderPopup();
           	
        }
           public void ValidateEventRemainderPopup()
        {
        	if(calendar.EventReminderForm.SelfInfo.Exists(70000))
        	{
        		calendar.EventReminderForm.btnIllBeThere.Click();
        	}
        }
              public void AppointmentOverlapPrompt()
       {
       	if(calendar.AppointmentOverlapDialog.SelfInfo.Exists(3000))
       	{
       		calendar.AppointmentOverlapDialog.btnOk.Click();
       	}
       }
		
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
        }
    }
}
