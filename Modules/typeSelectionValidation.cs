/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/18/2020
 * Time: 10:40 AM
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
    /// Description of typeSelectionValidation.
    /// </summary>
    [TestModule("75550B55-6D90-4C04-838F-BBF58C11BBAD", ModuleType.UserCode, 1)]
    public class typeSelectionValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public typeSelectionValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingTE te=BillingTE.Instance;
        
        Common cmn=new Common();
         
         
         string activityName="Attend discovery";
        int rowCount=0;
         private void type_Select_Validate()
         {
         	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");

			createTimeEntry();
        	
        	
			
			te.MainForm.LeftPanel.rdoStatusAll.Select();
			Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Type All Dropdown Selected is {0}",rowCount.ToString()));
        	
        	te.MainForm.LeftPanel.rdoTime.Select();
        	Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Type Time Dropdown Selected is {0}",rowCount.ToString()));
        	
        	te.MainForm.LeftPanel.rdoFlatFee.Select();
        	Delay.Milliseconds(500);
			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        	Report.Success(String.Format("Row Count for the current Type Flat Rate Dropdown Selected is {0}",rowCount.ToString()));
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
        	        	
        	
        	te.TimeEntryDetailsForm.btnPost.Click();
        	if(te.PromptForm.SelfInfo.Exists(3000))
        	{
        		te.PromptForm.btnNo.Click();
        	}
        	
        	
        	Report.Success("Time Entry successfully created and posted for Normal Rate .");
        	
        	
        	
        	
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
        	        	
        	
        	te.TimeEntryDetailsForm.btnOK.Click();
        	if(te.PromptForm.SelfInfo.Exists(3000))
        	{
        		te.PromptForm.btnNo.Click();
        	}
        	Report.Success("Time Entry successfully created and but not posted.");
        	
    		
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
            type_Select_Validate();
        }
    }
}
