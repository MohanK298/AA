/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 1:57 PM
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
    [TestModule("1384C5E1-4A8E-4126-8A66-43C88B3D1768", ModuleType.UserCode, 1)]
    public class BillingCreateTimeEntryExpense : ITestModule
    {
    	//Repository Variable
    	BillingTE te = BillingTE.Instance;
    	Common cmn=new Common();
    	string _activityDescription = "";
    	[TestVariable("1A44F55D-ECB2-441A-925C-C7B93D366BD8")]
    	public string activityDescription
    	{
    		get { return _activityDescription; }
    		set { _activityDescription = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("AEC9779D-92EB-4BA6-8CAF-DF4EE77E0618")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _timeExpenseDescription = "";
    	[TestVariable("2666B24C-E898-4991-8DC8-DCF717D800FB")]
    	public string timeExpenseDescription
    	{
    		get { return _timeExpenseDescription; }
    		set { _timeExpenseDescription = value; }
    	}
    	
    	
    	string _fileName = "";
    	[TestVariable("4E2E0A93-425C-44B3-8A61-3A50431C47D3")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
    	string _unit = "";
    	[TestVariable("61B3FAC1-9AD1-4CF7-9F46-9887279026F0")]
    	public string unit
    	{
    		get { return _unit; }
    		set { _unit = value; }
    	}
    	
    	string _quantity = "";
    	[TestVariable("765B6909-DF63-495D-8099-276CE900334C")]
    	public string quantity
    	{
    		get { return _quantity; }
    		set { _quantity = value; }
    	}
    	
        public BillingCreateTimeEntryExpense()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformTimeEntry(){
        	string actdes=activityDescription+ time;
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFindContact.TextValue = fileName + time;
        	te.FindFilesForm.btnOK.Click();
        	
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	te.TimeEntryDetailsForm.txtActivityDescription.PressKeys(actdes);
        	te.TimeEntryDetailsForm.btnOK.Click();
        	
        	//Verify
        	//te.MainForm.listFirstTimeEntryFile.DoubleClick();
        	te.MainForm.rdbtnTimeFees.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,fileName + time,"Time Entry Table");
        	//Report.Success(String.Format("Create Time Entry for Billing passed with Activity Description {0}",actdes));
        	te.TimeEntryDetailsForm.btnOK.Click();
        }
        
        public void PerformTimeExpense(){
        	string actdes=activityDescription+ time;
        	te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("67;38");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFindContact.TextValue = fileName + time;
        	te.FindFilesForm.btnOK.Click();
        	
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	//te.ExpenseXtraDetailsForm1.btnDropDown.Click();
        	//te.AmicusAttorneyXWin1.ScrollingRegion.Click("53;11");
        	te.ExpenseXtraDetailsForm1.ExpenseCode.TextValue = "E101 Copying";
        		
        	te.ExpenseXtraDetailsForm.PnlBase.txtQuantity.TextValue = quantity;
        	te.ExpenseXtraDetailsForm.PnlBase.txtUnit.TextValue = unit;
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            te.ExpenseXtraDetailsForm1.txtDescription.PressKeys("{Back}");
        	te.ExpenseXtraDetailsForm1.txtDescription.PressKeys(actdes);
        	te.ExpenseXtraDetailsForm1.btnOK.Click();
        	
        	//Verify
        	te.MainForm.rdbtnClientExpenses.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(te.MainForm.tblTimeEntry,fileName + time,"Time Expense Table");
        //	Report.Success(String.Format("Create Time Expense for Billing passed with Activity Description {0}",actdes));
        	te.ExpenseXtraDetailsForm1.btnOK.Click();
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
        	
            PerformTimeEntry();
            PerformTimeExpense();
            cmn.ClosePrompt();
        }
    }
}
