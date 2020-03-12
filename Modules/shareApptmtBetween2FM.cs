/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/9/2020
 * Time: 4:55 PM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of shareApptmtBetween2FM.
    /// </summary>
    [TestModule("6788A635-78B4-4927-BA28-4E197F3AAF92", ModuleType.UserCode, 1)]
    public class shareApptmtBetween2FM : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public shareApptmtBetween2FM()
        {
            // Do not delete - a parameterless constructor is required!
        }
    	Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
           static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData); 
		string curuser="";
        	string user="";
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
        private void shareApptmntBetweenFM()
        {
        	
        	
        	
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	curuser=datasource.Rows[0].Values[1].ToString();
        	user=datasource.Rows[1].Values[1].ToString();
        	cmn.switchUser(curuser);
        	       	
        	
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	string strtTime=System.DateTime.Now.ToShortTimeString();
			string endTime=System.DateTime.Now.AddHours(1).ToShortTimeString();
        	//Add data to create an appointment
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(strtTime);
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(endTime);
        	Delay.Seconds(1);
       	
        	calendar.EventDetailForm.PnlBase.btnAddFile.Click();
        	Delay.Seconds(1);

        	
        	Delay.Seconds(1);
     	

        	calendar.FileSelectForm.listFirstFoundFile.Click();
        	calendar.FileSelectForm.btnAddToRight.Click();
        	calendar.FileSelectForm.btnOK.Click();
        	Delay.Seconds(1);
        	
        	calendar.EventDetailForm.PnlBase.btnAddFirmMember.Click();
        	
        	calendar.PeopleSelectForm.ComboBox.Click();
        	cmn.SelectItemDropdown(calendar.tblDpdwnList.Self,"All");
        	
        	cmn.SelectItemFromTableSingleClick(calendar.PeopleSelectForm.Panel1.tbSelection,user,"People Selection Table");
        	calendar.PeopleSelectForm.btnAddToRight.Click();
        	calendar.PeopleSelectForm.btnOK.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        	       	
        	
        	
      
        	cmn.switchUser(user);
        	
        	
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        	
        	
        	
        	
        	
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
            shareApptmntBetweenFM();
        }
    }
}
