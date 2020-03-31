/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/8/2020
 * Time: 2:22 PM
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
    /// Description of Create_TE_Past_Current_Future.
    /// </summary>
    [TestModule("2D199031-C8B7-4C9B-B496-4A8A73CC729A", ModuleType.UserCode, 1)]
    public class Create_TE_Past_Current_Future : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Create_TE_Past_Current_Future()
        {
            // Do not delete - a parameterless constructor is required!
        }

        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        
       
        private void createTimeEntries()
        {
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(1);
        	// Create Unposted Time Entry for the Past date
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.txtDate.PressKeys(System.DateTime.Now.AddDays(-1).ToShortDateString());
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Past Date - {0}",System.DateTime.Now.AddDays(-1).ToShortDateString()));
        	
        	// Create Unposted Time Entry for the Today
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Current Date - {0}",System.DateTime.Now.ToShortDateString()));
        	
        	// Create Unposted Time Entry for the Tomorrow
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.txtDate.PressKeys(System.DateTime.Now.AddDays(1).ToShortDateString());
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Future Date - {0}",System.DateTime.Now.AddDays(1).ToShortDateString()));
        }
        private void CheckTimeEntries()
        {
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(10);
        	Report.Info("Waiting for 10 seconds");
        	ts.MainForm.cmbbxUnpostedDates.Click();
        	Delay.Seconds(1);
        	cmn.VerifyDataExistsInTable(ts.DropDownForm.tblDropdown,"Today","Unposted Dropdown");
        	cmn.VerifyDataExistsInTable(ts.DropDownForm.tblDropdown,System.DateTime.Now.AddDays(-1).ToString("ddd MMMM dd, yyyy"),"Unposted Dropdown");
        	cmn.VerifyDataExistsInTable(ts.DropDownForm.tblDropdown,System.DateTime.Now.AddDays(1).ToString("ddd MMMM dd, yyyy"),"Unposted Dropdown");
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
            createTimeEntries();
            CheckTimeEntries();
            cmn.ClosePrompt();
        }
    }
}
