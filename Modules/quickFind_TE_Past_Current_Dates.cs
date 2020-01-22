/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/13/2020
 * Time: 9:38 AM
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
    /// Description of quickFind_TE_Past_Current_Dates.
    /// </summary>
    [TestModule("E3AD07DA-DECF-40FD-A302-E52B3F76FF3C", ModuleType.UserCode, 1)]
    public class quickFind_TE_Past_Current_Dates : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public quickFind_TE_Past_Current_Dates()
        {
            // Do not delete - a parameterless constructor is required!
        }

        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();        
        Files file=new Files();
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        string data = "Test_Data_Time_Entry "+System.DateTime.Now.ToString();
        
        private void quickfind()
        {
        	
        	
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(5);
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(1);
        	// Create Unposted Time Entry for the Past date
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue=data;
        	ts.TimeEntryDetailsForm.txtDate.PressKeys(System.DateTime.Now.AddDays(-1).ToShortDateString());
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnNo.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Past Date - {0}",System.DateTime.Now.AddDays(-1).ToShortDateString()));
        	
        	// Create Unposted Time Entry for the Today
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue=data;
        	ts.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnNo.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Current Date - {0}",System.DateTime.Now.ToShortDateString()));
        
        
        	//Quick Find Time Entries
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(3);
        	ts.MainForm.Toolbar.btnQuickFind.Click();
        	ts.TimeFindForm.SelfInfo.WaitForExists(3000);
        	
        	//Sets the Check box for Current Date 
        	ts.TimeFindForm.cbDated.Check();
        	ts.TimeFindForm.txtDate.PressKeys(System.DateTime.Now.ToShortDateString());
        	ts.TimeFindForm.btnOk.Click();
        	Delay.Seconds(1);
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,data,String.Format("Time Entries Table for the date - {0}",System.DateTime.Now.ToShortDateString()));
        
        
        	
        	//Quick Find Time Entries
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(3);
        	ts.MainForm.Toolbar.btnQuickFind.Click();
        	ts.TimeFindForm.SelfInfo.WaitForExists(3000);
        	
        	//Sets the Check box for Past Date 
        	ts.TimeFindForm.cbDated.Check();
        	ts.TimeFindForm.txtDate.PressKeys(System.DateTime.Now.AddDays(-1).ToShortDateString());
        	ts.TimeFindForm.btnOk.Click();
        	Delay.Seconds(1);
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,data,String.Format("Time Entries Table for the date - {0}",System.DateTime.Now.AddDays(-1).ToShortDateString()));
        }
        
        private void Verify_TE_FileBrad()
        {
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles1.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	
        	file.FileDetailForm.TimeSpent.Click();
        	file.FileDetailForm.tblFileDetailsBradInfo.WaitForExists(10000);
        	cmn.VerifyCorrespondingDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,System.DateTime.Now.ToString("MMM dd/yy"),data,"Time Entries Table");
        	file.FileDetailForm.btnSaveClose.Click();
        	
        }
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            quickfind();
            Verify_TE_FileBrad();
            Utilities.Common.ClosePrompt();
        }
    }
}
