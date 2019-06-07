/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 3:39 PM
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
    [TestModule("3DF4173D-E05A-4B4D-A908-D7912E0D4190", ModuleType.UserCode, 1)]
    public class BillingDeleteTimeEntryExpense : ITestModule
    {
    	//Repository Variable
    	BillingTE te = BillingTE.Instance;
    	
        public BillingDeleteTimeEntryExpense()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformForTimeEntry(){
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.rdbtnTimeFees.Click();
        	te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	te.TimeEntryDetailsForm.btnDelete.Click();
        	te.PromptForm.btnYes.Click();
        }
        
        public void PerformForTimeExpense(){
        	te.MainForm.rdbtnClientExpenses.Click();
        	te.MainForm.listFirstTimeExpenseFile.DoubleClick();
        	te.ExpenseXtraDetailsForm.btnDelete.Click();
        	te.PromptForm.btnYes.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformForTimeEntry();
            PerformForTimeExpense();
        }
    }
}
