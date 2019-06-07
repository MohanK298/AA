/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 3:06 PM
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
    [TestModule("022A047E-00A0-4A69-AD96-E03DC449769C", ModuleType.UserCode, 1)]
    public class BillingEditTimeEntryExpense : ITestModule
    {
    	//Repository Variable
    	BillingTE te = BillingTE.Instance;
    	
    	string _editDescriptionTimeEntry = "";
    	[TestVariable("6D094B3B-C333-4039-A2F9-19F4E147D93A")]
    	public string editDescriptionTimeEntry
    	{
    		get { return _editDescriptionTimeEntry; }
    		set { _editDescriptionTimeEntry = value; }
    	}
    	
    	string _editDescriptionTimeExpense = "";
    	[TestVariable("5B02BBD9-66E8-470F-A61E-3302BFBA69F5")]
    	public string editDescriptionTimeExpense
    	{
    		get { return _editDescriptionTimeExpense; }
    		set { _editDescriptionTimeExpense = value; }
    	}
    	
        public BillingEditTimeEntryExpense()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformForTimeEntry(){
        	te.MainForm.rdbtnTimeFees.Click();
        	te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.TimeEntryDetailsForm.txtActivityDescription.PressKeys("{Back}");
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(editDescriptionTimeEntry);
        	te.TimeEntryDetailsForm.btnOK.Click();
        }
        
        public void PerformForTimeExpense(){
        	te.MainForm.rdbtnClientExpenses.Click();
        	te.MainForm.listFirstTimeExpenseFile.DoubleClick();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.ExpenseXtraDetailsForm1.txtDescription.PressKeys("{Back}");
        	te.ExpenseXtraDetailsForm1.txtDescription.PressKeys(editDescriptionTimeExpense);
        	te.ExpenseXtraDetailsForm1.btnOK.Click();
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
