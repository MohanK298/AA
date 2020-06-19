/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/18/2020
 * Time: 8:00 PM
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
    /// Description of ContextClick_Validations.
    /// </summary>
    [TestModule("DFA77C1B-92AC-45C0-B6D8-2FFF56487E8C", ModuleType.UserCode, 1)]
    public class ContextClick_Validations : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ContextClick_Validations()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
        BillingTE te=BillingTE.Instance;
        
        Common cmn=new Common();
        string data=System.DateTime.Now.ToShortDateString();
        string availableField="Client Name";
        string activityName="Attend trial";
        string activityDescription ="Time Entries created by Context Click: "+ System.DateTime.Now.ToString();
        string actdes="Expense Entries created by Context Click: "+ System.DateTime.Now.ToString();
        private void context_Click_Validate()
        {
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");
        	cmn.OpenContextMenuItemFromTable(te.MainForm.tblTimeEntry,data,"Time Entry Table");
        	Delay.Milliseconds(500);
        	te.ContextMenu.ShowFields.Click();
        	
        	te.curAvailableFields=availableField;
        	if(te.ShowFieldsForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Show Fields Form is displayed successfully");
        		if(te.ShowFieldsForm.listAvailableFieldsInfo.Exists(3000))
        		{
        			Report.Success(String.Format("Available field {0} displayed successfully",availableField));
        			te.ShowFieldsForm.listAvailableFields.Click();
        			te.ShowFieldsForm.PnlFormControls.btnAdd.Click();
        			
        		}
        		te.ShowFieldsForm.Toolbar1.btnOK.Click();
        	}
        	
        		te.colName=availableField;
        		Delay.Seconds(1);
        		Validate.Exists(te.MainForm.colHeaderInfo,String.Format("The Column header {0} exists in the Billing Time Entry Fees & Expenses Table",availableField));
        		
        		
        	cmn.OpenContextMenuItemFromTable(te.MainForm.tblTimeEntry,data,"Time Entry Table");
        	Delay.Milliseconds(500);
        	te.ContextMenu.MenuItemNew.Click();
        	te.ContextMenu.NewTimeEntry.Click();
        	createTimeEntry();
        	cmn.VerifyDataExistsInTable(te.MainForm.tblTimeEntry,activityDescription,"Time Entry Table");
        	
        	cmn.OpenContextMenuItemFromTable(te.MainForm.tblTimeEntry,data,"Time Entry Table");
        	Delay.Milliseconds(500);
        	te.ContextMenu.MenuItemNew.Click();
        	te.ContextMenu.NewExpenseEntry.Click();
        	CreateExpenseEntry();
        		
        		
        		
        		
        		
        		
        		
        	
        }
        
        private void createTimeEntry()
        {
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
        }
        
        private void CreateExpenseEntry()
        {
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	//te.ExpenseXtraDetailsForm1.btnDropDown.Click();
        	//te.AmicusAttorneyXWin1.ScrollingRegion.Click("53;11");
        	te.ExpenseXtraDetailsForm1.ExpenseCode.TextValue = "E101 Copying";
        		
        	te.ExpenseXtraDetailsForm.PnlBase.txtQuantity.TextValue = "10";
        	te.ExpenseXtraDetailsForm.PnlBase.txtUnit.TextValue = "5";
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.ExpenseXtraDetailsForm1.txtDescription.PressKeys("{Back}");
        	te.ExpenseXtraDetailsForm1.txtDescription.PressKeys(actdes);
        	te.ExpenseXtraDetailsForm1.btnOK.Click();
        	
        	//Verify
        	te.MainForm.rdbtnClientExpenses.Click();
        	Delay.Seconds(2);
        	cmn.VerifyDataExistsInTable(te.MainForm.tblTimeEntry,actdes,"Time Expense Table");
        //	Report.Success(String.Format("Create Time Expense for Billing passed with Activity Description {0}",actdes));
        	//te.ExpenseXtraDetailsForm1.btnOK.Click();
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
            context_Click_Validate();
        }
    }
}
