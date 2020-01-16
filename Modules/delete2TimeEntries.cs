/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/9/2020
 * Time: 3:26 PM
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
    /// Description of delete2TimeEntries.
    /// </summary>
    [TestModule("900D7878-C5DA-45A4-9A3D-A18E048D05B8", ModuleType.UserCode, 1)]
    public class delete2TimeEntries : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public delete2TimeEntries()
        {
            // Do not delete - a parameterless constructor is required!
        }
		TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void Create_Delete2TE()
        {
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
        	   	ts.PromptForm.btnNo.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Current Date - {0}",System.DateTime.Now.ToShortDateString()));
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
        	   	ts.PromptForm.btnNo.Click();
        	}
        	Report.Success(String.Format("Time Entries has been created for Current Date - {0}",System.DateTime.Now.ToShortDateString()));
        	Delay.Seconds(2);
        	//cmn.MultipleDocSelection(ts.MainForm.tblTimeSheet,2);
        	Keyboard.Press("{Down}");
        	Keyboard.Press("{LShiftKey down}{Up}{Up}");
        	Keyboard.Press("{LShiftKey up}");
        	Keyboard.Press("{Delete}");
        	if(ts.PromptForm.SelfInfo.Exists(3000))
        	   {
        	   	ts.PromptForm.btnYes.Click();
        	   }
        	   	Report.Success("2 Time Entries are deleted");
        	   
        	
        	
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 1000;
            Delay.SpeedFactor = 1.0;
            Create_Delete2TE();
            Utilities.Common.ClosePrompt();
        }
    }
}
