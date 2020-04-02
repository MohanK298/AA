/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/9/2020
 * Time: 1:47 PM
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
    /// Description of createTE_ValidateActivityCodes.
    /// </summary>
    [TestModule("45D4FA9C-A392-42BE-8380-CF516C2A6F37", ModuleType.UserCode, 1)]
    public class createTE_ValidateActivityCodes : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public createTE_ValidateActivityCodes()
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
        
        private void CreateTE_ValidateActivitycodes()
        {
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	Delay.Seconds(1);
        	
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.TextValue="Test";
        	ts.TimeEntryDetailsForm.cmbbxActivityCodes.Click();
        	Delay.Seconds(2);
        	cmn.VerifyDataExistsInTable(ts.DropDownForm.tblDropdown,"Attend trial","Activity Code Dropdown");
        	cmn.VerifyDataExistsInTable(ts.DropDownForm.tblDropdown,"Attend discovery","Activity Code Dropdown");
        	ts.TimeEntryDetailsForm.MenubarFillPanel.Self.Click();
        	ts.TimeEntryDetailsForm.MenubarFillPanel.Cancel.Click();
        	if(ts.PromptForm.txtPromptInfo.Exists(3000))
        	{
        	   	ts.PromptForm.btnYes.Click();
        	}
        	//Report.Success(String.Format("Time Entries has been created for Current Date - {0}",System.DateTime.Now.ToShortDateString()));
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateTE_ValidateActivitycodes();
            cmn.ClosePrompt();
        }
    }
}
