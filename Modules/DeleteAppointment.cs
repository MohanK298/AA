/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/27/2015
 * Time: 11:25 AM
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
   
    [TestModule("929656B3-117C-43D1-8203-FC268BCF37C2", ModuleType.UserCode, 1)]
    public class DeleteAppointment : ITestModule
    {
    	//Repository Variable
    	Calendar calendar = Calendar.Instance;
    	
    	string _time = "";
    	[TestVariable("582FB0C6-7A30-4E06-AC00-79698351EF65")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _editAppointmentTitle = "";
    	[TestVariable("5F963FAB-6F2C-4841-9C38-94BC69C303FD")]
    	public string editAppointmentTitle
    	{
    		get { return _editAppointmentTitle; }
    		set { _editAppointmentTitle = value; }
    	}
    	
        public DeleteAppointment()
        {
            // Do not delete - a parameterless constructor is required!
        }
				
        
        public void DeleteAppointmentFromList(){
        		
        	//Open the appointment
        	calendar.MainForm.listItemTitle.DoubleClick();
        	
        	//Delete the appointment
        	calendar.EventDetailForm.btnDelete.Click();
        	calendar.PromptForm.btnYes.Click();
        	Report.Success("Delete Appointment passed");
        	
        }
        
			
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteAppointmentFromList();
        }
    }
}
