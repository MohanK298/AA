/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/5/2015
 * Time: 3:03 PM
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
using SmokeTest.Recordings;

namespace SmokeTest.Modules
{
    [TestModule("114963C4-6670-42DC-9B0E-D37DDA049CFF", ModuleType.UserCode, 1)]
    public class BillingCreateDirectBill : ITestModule
    {
    	//Repository Variable
    	Bill bill = Bill.Instance;
        BillingFile file = BillingFile.Instance;
        
        
        string _fileName = "";
        [TestVariable("A35C67AF-905C-4ACA-8807-4977E8BD579C")]
        public string fileName
        {
        	get { return _fileName; }
        	set { _fileName = value; }
        }
        
        string _time = "";
        [TestVariable("643C67BA-3A46-45E1-A5A7-C4A6313947F2")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        string _lastName = "";
        [TestVariable("E7CB2C06-6BE2-407B-9566-EFC07C4EDD3C")]
        public string lastName
        {
        	get { return _lastName; }
        	set { _lastName = value; }
        }
        
        string _feesValue = "";
        [TestVariable("5367297F-4177-4438-AD8B-8A6A0CF96F55")]
        public string feesValue
        {
        	get { return _feesValue; }
        	set { _feesValue = value; }
        }
        
        string _expensesValue = "";
        [TestVariable("5C31128E-06D2-46FE-83F2-801C9F6695DB")]
        public string expensesValue
        {
        	get { return _expensesValue; }
        	set { _expensesValue = value; }
        }
        
        string _feesDescription = "";
        [TestVariable("7EF9EF24-E980-4246-A099-E1B7506A941A")]
        public string feesDescription
        {
        	get { return _feesDescription; }
        	set { _feesDescription = value; }
        }
        
    	public BillingCreateDirectBill()
        {
            // Do not delete - a parameterless constructor is required!
        }
    	
    	public void FindFile(){
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = "New" + fileName + time;
        	file.FindFilesForm.btnOK.Click();
        }
    	
    	public void PerformCreateNewFile(){
    	
        	//Open window to add a file
        	file.MainForm.switchBILLING.Click();
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	file.PromptForm.btnNo.Click();
        	
        	//Type the file name and other variables
        	file.NewFileForm.txtFileName.TextValue = "New" + fileName + time;
        	file.NewFileForm.btnAddContact.Click();
        	file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	file.FindContactsForm.btnOK.Click();
        	Delay.Seconds(1);
        	
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	//file.NewFileForm.btnNext.Click();
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	FindFile();
        	
        	//Verify File
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Validate.Equals(file.FileDetailForm.titlebarFileDetail.Text, fileName + time + "1");
        	Delay.Seconds(3);
        	file.FileDetailForm.btnSaveClose.Click();
        
    	}
        
    	public void PerformCreateBill(){
    		bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	bill.AmicusAttorneyXWin.optionBill.Click();	
        	file.BillingDetailForm.txtFees.PressKeys(feesValue);
        	file.BillingDetailForm.txtExpenses.Click();
        	
        	file.FeeAdjustmentForm.txtDescription.TextValue = feesDescription;
        	file.FeeAdjustmentForm.btnOK.Click();
        	file.BillingDetailForm.txtExpenses.PressKeys(expensesValue);
        	file.BillingDetailForm.btnSendToDraft.Click();
        	file.ExpenseAdjustmentForm.btnDropdown.Click();
        	file.List1000.E101Copying.Click();
        	file.ExpenseAdjustmentForm.btnOK.Click();
    	}
    	
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformCreateNewFile();
            PerformCreateBill();
            BillingDirectTest.Start();
            Utilities.Common.ClosePrompt();
        }
    }
}
