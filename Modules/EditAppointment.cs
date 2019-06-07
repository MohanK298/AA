/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/24/2015
 * Time: 4:32 PM
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

using SmokeTest.Modules;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("B3FFC711-82C2-4E91-AD11-A4624EA90570", ModuleType.UserCode, 1)]
    public class EditAppointment : ITestModule
    {
    	Calendar calendar = Calendar.Instance;
    	Duration customWaitTime = new Duration(3000);
    	string _time = "";
    	[TestVariable("A7066AAE-08F0-4B8F-881D-A22E28143DCF")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _editAppointmentTitle = "";
    	[TestVariable("A2EDE178-5BFB-4AFD-BC56-FED48E90CD6D")]
    	public string editAppointmentTitle
    	{
    		get { return _editAppointmentTitle; }
    		set { _editAppointmentTitle = value; }
    	}
    	
    	//Repository variable
    	Calendar calender = Calendar.Instance;
    	
        public EditAppointment()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditAppointmentData(){
        	
        	//Open the appointment
        	calendar.MainForm.listItemTitle.DoubleClick();
        	
        	//Edit data to create an appointment
        	calendar.EventDetailForm.EmbeddableTextBoxWithUIPermissionsInfo.WaitForExists(customWaitTime);
        	calendar.EventDetailForm.EmbeddableTextBoxWithUIPermissions.Click();        	
            Keyboard.PrepareFocus(calender.EventDetailForm.EmbeddableTextBoxWithUIPermissions);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            calender.EventDetailForm.EmbeddableTextBoxWithUIPermissions.PressKeys("{Back}");
            
        	calendar.EventDetailForm.EmbeddableTextBoxWithUIPermissions.PressKeys(editAppointmentTitle + time);
        	
        	//Save the appointment
        	calendar.EventDetailForm.btnOK.Click();
        	
        	//Verify edit appointment
        		if(calender.MainForm.listItemTitle.Text == editAppointmentTitle + time)
        		{
        			calender.MainForm.listItemTitle.DoubleClick();	
        			Delay.Seconds(3);
        			calendar.EventDetailForm.btnOK.Click();
        			Report.Success("Edit Appointment passed");
        		}else{
        		Report.Error("Verify Appointment failed");
        		}
        	
        }
        
     void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditAppointmentData();
        }
    }
}
