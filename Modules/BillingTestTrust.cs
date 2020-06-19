/*
 * Created by Ranorex
 * User: HPatel
 * Date: 8/5/2015
 * Time: 9:44 AM
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

using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;



namespace SmokeTest.Modules
{
    [TestModule("6B76598E-13C4-4478-A35E-72566B6DCC24", ModuleType.UserCode, 1)]
    public class BillingTestTrust : ITestModule
    {
    	//Repository Variable
    	Bill bill = Bill.Instance;
    	Common cmn=new Common();
    	//Variables
    	BillingTestGeneralRetainer btgr = new BillingTestGeneralRetainer();
    	
        string _trustReceiptAmount = "";
        [TestVariable("BAFBDB47-014D-49A8-9A42-49BC5B258D37")]
        public string trustReceiptAmount
        {
        	get { return _trustReceiptAmount; }
        	set { _trustReceiptAmount = value; }
        }
        
        string _trustDescription = "";
        [TestVariable("9F7C7B9B-BB98-4149-A6EC-0E91F0160BD5")]
        public string trustDescription
        {
        	get { return _trustDescription; }
        	set { _trustDescription = value; }
        }
        
        string _lastName = "";
        [TestVariable("B5A98BDF-23B0-44BD-9CF5-D279B14131BE")]
        public string lastName
        {
        	get { return _lastName; }
        	set { _lastName = value; }
        }
        
        string _time = "";
        [TestVariable("BC5A72AF-FC4C-40A0-8AEF-1CCCF15075B8")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        string _trustCheckAmount = "";
        [TestVariable("15D8F693-0F57-4CAB-8E8C-3C7C4F8CA5C1")]
        public string trustCheckAmount
        {
        	get { return _trustCheckAmount; }
        	set { _trustCheckAmount = value; }
        }
        
        string _difference = "";
        [TestVariable("81BA8561-E778-4E10-B729-6E1D0B897556")]
        public string difference
        {
        	get { return _difference; }
        	set { _difference = value; }
        }
        
        public BillingTestTrust()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void PerformTrustReceipt(){
        	bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
//        	bill.AmicusAttorneyXWin.optionTrust.Click();
        	
        	Report.Info("Check Trust Receipt Form Exist? " + bill.AmicusAttorneyXWin1.TrustInfo.Exists());
//        	bill.AmicusAttorneyXWin1.Trust.Select();
        	bill.AmicusAttorneyXWin1.Trust.Click();
        	
        	Report.Info("Check Trust Receipt MenuItem Exist? " + bill.AmicusAttorneyXWin2.optionTrustReceiptInfo.Exists());
//        	bill.AmicusAttorneyXWin2.optionTrustReceipt.Select();
        	bill.AmicusAttorneyXWin2.optionTrustReceipt.Click();
//        	bill.AmicusAttorneyXWin2.optionTrustReceipt.Select();
        	//bill.TrustDetailBaseForm.PnlBase.txtAmount.PressKeys(trustReceiptAmount);
        	bill.TrustDetailBaseForm.PnlBase.txtAmount.PressKeys("35.00");
        	bill.TrustDetailBaseForm.PnlBase.txtDescription.PressKeys(trustDescription);
        	bill.TrustDetailBaseForm.btnSaveClose.Click();
        	Delay.Seconds(3);
        	//bill.OutputPromptForm.OutputPrompt.Click();
        	//bill.OutputPromptForm.btnOk1.Click();
        	Delay.Seconds(5);
        	
        	//Validate.Attribute(bill.MainForm.FilesIndexForm.cellTrustInfo, "Text", trustReceiptAmount);
        	Validate.Equals(bill.MainForm.FilesIndexForm.cellTrust2.TextValue, trustReceiptAmount);
        }
        
        public void PerformTrustCheck(){
        	bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	bill.ContextMenu.optionTrust.Click();
        	bill.AmicusAttorneyXWin2.optionTrustCheck.Click();
        	bill.TrustDetailBaseForm.PnlBase.btnAddContact.Click();
        	bill.PeopleSelectForm.btnQuickFind.Click();
        	bill.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	bill.FindContactsForm.btnOK.Click();
        	bill.PeopleSelectForm.listFirstFound.DoubleClick();
        	
        	bill.TrustDetailBaseForm.PnlBase.txtAmount.PressKeys(trustCheckAmount);
        	bill.TrustDetailBaseForm.PnlBase.txtDescription.PressKeys(trustDescription);
        	try{
        		if (bill.TrustDetailBaseForm.PnlBase.PrintInfo.Exists()){
        			if(bill.TrustDetailBaseForm.PnlBase.Print.Checked){
        				bill.TrustDetailBaseForm.PnlBase.Print.Click();
        			}
        		}
        	} catch(Exception ex){
        		Report.Log(ReportLevel.Warn, "(Could Not Find Print Checkbox) " + ex.Message);
        	}
        	bill.TrustDetailBaseForm.btnSaveClose.Click();
        	
        	//Validate.Attribute(bill.MainForm.FilesIndexForm.cellTrustInfo, "Text", difference);
        	Validate.Equals(bill.MainForm.FilesIndexForm.cellTrust2.TextValue, difference);
        }
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            PerformTrustReceipt();
            PerformTrustCheck();
            cmn.ClosePrompt();
        }
    }
}
