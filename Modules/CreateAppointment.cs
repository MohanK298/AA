/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/24/2015
 * Time: 2:47 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
	
	
    [TestModule("6728A950-D997-404D-8F86-8CDD7D13E83F", ModuleType.UserCode, 1)]
    public class CreateAppointment : ITestModule
    {
    	//Repository variable
    	Calendar calendar = Calendar.Instance;
    	Common cmn=new Common();
    	//Local variables
    	
    	string _time = "";
    	[TestVariable("DB79ED1A-83F4-4C60-B5E9-3AD8AD537739")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("A9402F55-5961-48AA-98E9-5A1B9AD90D47")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _location = "";
    	[TestVariable("2FD6A740-3027-465C-BE04-39B89B143757")]
    	public string location
    	{
    		get { return _location; }
    		set { _location = value; }
    	}
    	
    	string _endTime = "";
    	[TestVariable("EEFB8C30-3E7F-4E9E-8084-25D9E4DADF81")]
    	public string endTime
    	{
    		get { return _endTime; }
    		set { _endTime = value; }
    	}
    	
    	string _startTime = "";
    	[TestVariable("13CAD6CC-DBEF-4F78-B57E-192AE4706F30")]
    	public string startTime
    	{
    		get { return _startTime; }
    		set { _startTime = value; }
    	}
    	
    	string _date = "";
    	[TestVariable("C3A33B9F-F1F4-4EDF-8278-70E90143B6C2")]
    	public string date
    	{
    		get { return _date; }
    		set { _date = value; }
    	}
    	
    	
    	string _allDayListing = "";
    	[TestVariable("24A617F9-D345-4AE8-B31E-A72E21EEFDEB")]
    	public string allDayListing
    	{
    		get { return _allDayListing; }
    		set { _allDayListing = value; }
    	}
    	
    	string _appointmentTitle = "";
    	[TestVariable("3BB3E009-32E8-49CD-9D47-AAEEB6AF0C07")]
    	public string appointmentTitle
    	{
    		get { return _appointmentTitle; }
    		set { _appointmentTitle = value; }
    	}
    	
        public CreateAppointment()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        public void CheckUI(){
        	//calendar.EventDetailForm.ToolbarOptions.Click();
        	try{
        		calendar.MainForm.btnCalendar.Click();
        		calendar.MainForm.btnNewAppointment.Click();
           		calendar.EventDetailForm.btnCancel.Click();
           }catch(Exception ex){
           		Report.Error("(Could Not Find Cancel button on events window) " + ex.Message);
           }
        }
        
        public void AddFileToEvent(){
        	//Add file to the the appointment
        	calendar.FileSelectForm.btnQuickFind.Click();
        	calendar.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	calendar.FindFilesForm.btnOK.Click();
        	calendar.FileSelectForm.listFirstFoundFile.Click();
        	calendar.FileSelectForm.btnAddToRight.Click();
        	calendar.FileSelectForm.btnOK.Click();
        	Delay.Seconds(1);
        }
        
        public void Appointment(){

        	//Open window to add an appointment
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	
        	//Add data to create an appointment
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(appointmentTitle + time);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(startTime);
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(endTime);
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtLocation.PressKeys(location);
        	
        	if(allDayListing == "1"){
        		calendar.EventDetailForm.PnlBase.radiobtnAllDayLasting.Select();
        	}
        	
        	Delay.Seconds(1);
        	
        	calendar.EventDetailForm.PnlBase.btnAddFile.Click();
        	Delay.Seconds(1);
        	
        	AddFileToEvent();
        	
        	//Save the appointment
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(5);
        	
        	//Change calender view to list view
        	calendar.MainForm.btnViewMenu.Click();
        	Delay.Seconds(1);
        	calendar.AmicusAttorneyXWin.menuPopup.Click("68;127");

        	//Verify Create Appointment
        	calendar.MainForm.listItemTitle.Click();
        	
        		if(calendar.MainForm.listItemTitle.Text == appointmentTitle + time)
        		{
        			calendar.MainForm.listItemTitle.DoubleClick();	
        			Delay.Seconds(3);
        			calendar.EventDetailForm.btnOK.Click();
        			Report.Success("Create Appointment passed");
        		}else{
        		 Report.Error("Create Appointment failed");
        		}
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            //CheckUI();
            Appointment();
            cmn.ClosePrompt();
        }
    }
}
