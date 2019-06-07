/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-09
 * Time: 1:31 PM
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

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AddTimeEntryAPX.
    /// </summary>
    [TestModule("2F867F25-29F5-403B-A71B-D076C0809167", ModuleType.UserCode, 1)]
    public class AddTimeEntryAPX : ITestModule
    {
    //Repository Variable
    	BillingTE te = BillingTE.Instance;
    	TimeSheets timeEntry = TimeSheets.Instance;
    	    	
    	string _activityDescription = "";
    	[TestVariable("1A44F55D-ECB2-441A-925C-C7B93D366BD8")]
    	public string activityDescription
    	{
    		get { return _activityDescription; }
    		set { _activityDescription = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
      	
    	
   		string _fileName = "";
    	[TestVariable("DDE10115-729E-4144-AAC6-425EAF372517")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
   
        public AddTimeEntryAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

       public void PerformTimeEntry()
       {
       		te.MainForm.Billing.Click();
       		te.MainForm.btnTimeFeesExpenses.Click();
       		te.MainForm.rdbtnTimeFees.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	//Find file
        	timeEntry.FileSelectForm.btnQuickFind.Click();
        	timeEntry.FindFilesForm.txtFindFile.TextValue = fileName;
        	timeEntry.FindFilesForm.btnOK.Click();
        	//te.FindFilesForm.txtFindContact.TextValue = fileName + time;
        	//te.FindFilesForm.btnOK.Click();
        	//timeEntry.FileSelectForm.listFirstFoundFile.DoubleClick();
        	
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(activityDescription);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	
        	//Verify
        	te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	Report.Success("Create Time Entry for APX Billing passed");
        	te.TimeEntryDetailsForm.btnPost.Click();
        	//te.TimeEntryDetailsForm.btnOK.Click();
        }
        
      void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformTimeEntry();
         }
    }
}
