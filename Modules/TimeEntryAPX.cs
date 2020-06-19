/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-15
 * Time: 11:14 AM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of TimeEntryAPX.
    /// </summary>
    [TestModule("9AF72657-DB2A-4E86-8B5E-9F63B308A550", ModuleType.UserCode, 1)]
    public class TimeEntryAPX : ITestModule
    {
        //Repository Variable
    	BillingTE te = BillingTE.Instance;
    	Common cmn=new Common();
    	string _activityDescription = "";
    	[TestVariable("1A44F55D-ECB2-441A-925C-C7B93D366BD8")]
    	public string activityDescription
    	{
    		get { return _activityDescription; }
    		set { _activityDescription = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("AEC9779D-92EB-4BA6-8CAF-DF4EE77E0618")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        	
    	
    	string _fileName = "";
    	[TestVariable("4E2E0A93-425C-44B3-8A61-3A50431C47D3")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
    	
        public TimeEntryAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformTimeEntry()
        {
        	PopupWatcher timeEntryCombine = new PopupWatcher();
        	timeEntryCombine.WatchAndClick(te.PromptForm, te.PromptForm.btnYesInfo);
        	timeEntryCombine.Start();
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuItemNewItemsMenuItemIndex.Click();
//        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	
        	
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(activityDescription);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	
        	//Verify
        	te.MainForm.rdbtnTimeFees.Click();
        	te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	Report.Success("Create Time Entry for Billing passed");
        	te.TimeEntryDetailsForm.btnPost.Click();
        	timeEntryCombine.Stop();
        	//te.TimeEntryDetailsForm.btnOK.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformTimeEntry();
            cmn.ClosePrompt();
        }
    }
}
