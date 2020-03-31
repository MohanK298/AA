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
using SmokeTest.Modules.Utilities;
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
    	Common cmn=new Common();
    	string _editDescriptionTimeEntry = "";
    	[TestVariable("6D094B3B-C333-4039-A2F9-19F4E147D93A")]
    	public string editDescriptionTimeEntry
    	{
    		get { return _editDescriptionTimeEntry; }
    		set { _editDescriptionTimeEntry = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("3e424b5f-ec90-4c79-9d7e-331dcd879e13")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("d4c4a8c2-2431-40c4-a0b1-a1fc206865b1")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _activityDescription = "";
    	[TestVariable("5a5dc04b-19f2-42db-875f-692a4bd7b0c0")]
    	public string activityDescription
    	{
    		get { return _activityDescription; }
    		set { _activityDescription = value; }
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
        	string actdes=fileName+ time;
        	Report.Info(actdes);
        	te.MainForm.rdbtnTimeFees.Click();
        	Delay.Seconds(3);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,actdes,"Time Entry Table");
        	//te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.TimeEntryDetailsForm.txtActivityDescription.PressKeys("{Back}");
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(editDescriptionTimeEntry+ time);
        	te.TimeEntryDetailsForm.btnOK.Click();
        }
        
        public void PerformForTimeExpense(){
        	string actdes=fileName+ time;
        	Report.Info(actdes);
        	te.MainForm.rdbtnClientExpenses.Click();
        	Delay.Seconds(3);
        	//te.MainForm.listFirstTimeExpenseFile.DoubleClick();
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,actdes,"Time Entry Table");
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.ExpenseXtraDetailsForm1.txtDescription.PressKeys("{Back}");
        	te.ExpenseXtraDetailsForm1.txtDescription.PressKeys(editDescriptionTimeExpense+ time);
        	te.ExpenseXtraDetailsForm1.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformForTimeEntry();
            PerformForTimeExpense();
            cmn.ClosePrompt();
        }
    }
}
