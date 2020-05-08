/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/7/2020
 * Time: 4:16 PM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using SmokeTest.Repositories.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateTrackChangesinTimeEntry.
    /// </summary>
    [TestModule("16DA175C-E46B-43D8-9ACC-C036AA389752", ModuleType.UserCode, 1)]
    public class validateTrackChangesinTimeEntry : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTrackChangesinTimeEntry()
        {
            // Do not delete - a parameterless constructor is required!
        }

        BillingTE te = BillingTE.Instance;
    	Common cmn=new Common();
        
    	
    	
    	private void TrackChanges()
    	{
    		string actdes="Test Data Added- "+System.DateTime.Now.ToString();
    		string billrate="150";
        	te.MainForm.btnTimeFeesExpenses.Click();
        	//cmn.SelectItemDropdown(te.MainForm.btnMenuItem,"Time Entry","Time Entry Menu");
        	te.MainForm.btnMenuItem.Click();
//        	cmn.SelectItemDropdown(te.DropDownForm.tblDpdwn.Self,"Time Entry");
			te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(actdes);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	
        	//Verify
        	//te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	te.MainForm.rdbtnTimeFees.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,actdes,"Time Entry Table");
        	te.TimeEntryDetailsForm.btnPost.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,actdes,"Time Entry Table");
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	cmn.SelectItemDropdown(te.DropDownForm.tblDpdwn.Self,"Flat Rate");
        	//cmn.SelectItemFromTableSingleClick(te.DropDownForm.tblDpdwn,"Flat Rate","Dropdown");
        	te.TimeEntryDetailsForm.txtRate.TextValue=billrate;
        	te.TimeEntryDetailsForm.btnOK.Click();
        	
        	if(te.ChangeReasonForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Change Reason Form is displayed successfully");
        		te.ChangeReasonForm.cmbxSelectionReason.Click();
        		cmn.VerifyDataExistsInTable(te.DropDownForm.tblDpdwn.Self,"Incorrect Billing Rate","Change Reason Form Table");
        		cmn.VerifyDataExistsInTable(te.DropDownForm.tblDpdwn.Self,"Time was entered on wrong date","Change Reason Form Table");
        		cmn.SelectItemDropdown(te.DropDownForm.tblDpdwn.Self,"Incorrect Billing Rate");
        		te.ChangeReasonForm.Toolbar1.btnOK.Click();
        		Delay.Seconds(2);
        		cmn.VerifyCorrespondingDataExistsInTable(te.MainForm.tblTimeEntry,actdes,billrate,"Time Entry Table");
        		
        	}
        	
        	
        	
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
            TrackChanges();
        }
    }
}
