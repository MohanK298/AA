/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/18/2020
 * Time: 11:24 AM
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
    /// Description of billingStatusSelectionValidation.
    /// </summary>
    [TestModule("52F7D34C-BBB9-47EF-BDAB-0067B1632AFA", ModuleType.UserCode, 1)]
    public class billingStatusSelectionValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public billingStatusSelectionValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

          
        BillingTE te=BillingTE.Instance;
        
        Common cmn=new Common();
        string activityName="Attend trial";
        string activityDescription ="Unposted Time Entries: "+ System.DateTime.Now.ToString();
        string activityDescription2 ="Non-Billable Time Entries: "+ System.DateTime.Now.ToString();
        int rowCount=0;
         private void billing_Select_Validate()
         {
         	
         	te.MainForm.Self.Activate();
         	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");

			createTimeEntry();
        	
        	
			
			te.MainForm.LeftPanel.rdoStatusAll.Select();
			te.MainForm.LeftPanel.rdoTypeAll.Select();
			Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Status All Dropdown Selected is {0}",rowCount.ToString()));
        	
        	te.MainForm.LeftPanel.rdoUnbilled.Select();
        	te.MainForm.LeftPanel.cbUnpostedEntries.Check();
        	te.MainForm.LeftPanel.cbNonBillable.Check();
        	Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Status Unbilled Dropdown Selected is {0}",rowCount.ToString()));
        	cmn.VerifyCorrespondingDataExistsInTable(te.MainForm.tblTimeEntry,activityDescription,"Unposted","Time entry Table");
        	
        	cmn.VerifyCorrespondingDataExistsInTable(te.MainForm.tblTimeEntry,activityDescription2,"Unposted","Time entry Table");
			
        	
        	
        	te.MainForm.LeftPanel.rdoBilled.Select();
        	Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Status Billed Rate Dropdown Selected is {0}",rowCount.ToString()));
        	cmn.VerifyCorrespondingDataExistsInTable(te.MainForm.tblTimeEntry,System.DateTime.Now.ToShortDateString(),"Billed","Time entry Table");
        	te.MainForm.LeftPanel.rdoStatusAll.Select();
			        	
         }
         
         
         
         private void createTimeEntry()
    	{
    		
    		te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
//        	te.FileSelectForm.btnQuickFind.Click();
//        	te.FindFilesForm.txtFind.TextValue = fileName;
//        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName;
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	
        	te.TimeEntryDetailsForm.cmbbxActivityCodes.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	te.var="Normal";
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	te.DropDownForm.TreeItem.Click();
        	       	
        	te.var="Bill";
        	te.TimeEntryDetailsForm.cmbbxBillBehavior.Click();
        	te.DropDownForm.TreeItem.Click();
        	        	
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(activityDescription);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	if(te.PromptForm.SelfInfo.Exists(3000))
        	{
        		te.PromptForm.btnNo.Click();
        	}
        	Report.Success("Time Entry 1 successfully created and unposted");
        	
        	
        	
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
//        	te.FileSelectForm.btnQuickFind.Click();
//        	te.FindFilesForm.txtFind.TextValue = fileName;
//        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName;
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	
        	te.TimeEntryDetailsForm.cmbbxActivityCodes.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	te.var="Flat Rate";
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	te.DropDownForm.TreeItem.Click();
        	       	
        	te.var="Bill";
        	te.TimeEntryDetailsForm.cmbbxBillBehavior.Click();
        	te.DropDownForm.TreeItem.Click();
        	        	
        	
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(activityDescription);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	if(te.PromptForm.SelfInfo.Exists(3000))
        	{
        		te.PromptForm.btnNo.Click();
        	}
        	Report.Success("Time Entry 2 successfully created and unposted.");
        	
        	
        	
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
//        	te.FileSelectForm.btnQuickFind.Click();
//        	te.FindFilesForm.txtFind.TextValue = fileName;
//        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName;
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	
        	te.TimeEntryDetailsForm.cmbbxActivityCodes.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	te.var="Non-Billable";
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	te.DropDownForm.TreeItem.Click();
        	       	
        	te.var="Bill";
        	te.TimeEntryDetailsForm.cmbbxBillBehavior.Click();
        	te.DropDownForm.TreeItem.Click();
        	        	
        	
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(activityDescription2);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	if(te.PromptForm.SelfInfo.Exists(3000))
        	{
        		te.PromptForm.btnNo.Click();
        	}
        	Report.Success("Time Entry 3 successfully created fro Non Billable and unposted.");
        	
        	
    		
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
            billing_Select_Validate();
        }
    }
}
