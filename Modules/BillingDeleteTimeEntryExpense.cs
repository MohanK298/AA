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
using SmokeTest.Modules.Utilities;
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
    	Common cmn=new Common();
    	string _time = "";
    	[TestVariable("de994c62-f9cf-4ec2-901c-9b494fa57427")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        string _fileName = "";
        [TestVariable("ff1bf688-fd6b-4f61-8534-a37820c4e5a0")]
        public string fileName
        {
        	get { return _fileName; }
        	set { _fileName = value; }
        }
        
        public BillingDeleteTimeEntryExpense()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformForTimeEntry(){
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.rdbtnTimeFees.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,fileName+time,"Time Entry Table");
        	//te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	te.TimeEntryDetailsForm.btnDelete.Click();
        	te.PromptForm.btnYes.Click();
        }
        
        public void PerformForTimeExpense(){
        	te.MainForm.rdbtnClientExpenses.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,fileName+time,"Time Expense Table");
        	//te.MainForm.listFirstTimeExpenseFile.DoubleClick();
        	te.ExpenseXtraDetailsForm.btnDelete.Click();
        	Delay.Seconds(2);
        	te.PromptForm.btnYes.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformForTimeEntry();
            PerformForTimeExpense();
            Utilities.Common.ClosePrompt();
        }
    }
}
