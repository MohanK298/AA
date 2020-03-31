/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/5/2015
 * Time: 9:43 AM
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
    [TestModule("CEA06717-C74D-47C4-9E32-018F25EA9467", ModuleType.UserCode, 1)]
    public class BillingTestGeneralRetainer : ITestModule
    {
    	//Repository Variable
    	Bill bill = Bill.Instance;
    	Common cmn=new Common();
    	
    	string _fileName = "";
    	[TestVariable("9DCAEDD1-2837-4DAE-98E9-E6E5B3C84EA3")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _amountReceived = "";
    	[TestVariable("44B59F15-C3CD-4264-A366-CA11A8321CC6")]
    	public string amountReceived
    	{
    		get { return _amountReceived; }
    		set { _amountReceived = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("1AFC3A09-784E-408B-BB71-2424FC806E55")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        public BillingTestGeneralRetainer()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void FindFile(){
        	bill.MainForm.btnFiles.Click();
        	Delay.Seconds(2);
        	bill.MainForm.FilesIndexForm.btnQuickFind.Click();
        	Delay.Seconds(2);
        	bill.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	bill.FindFilesForm.btnOK.Click();	
        }
        
        public void Perform(){
        	FindFile();
        	bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	bill.AmicusAttorneyXWin.optionReceivePayment.Click();
        	bill.ReceivePaymentForm.txtAmount.PressKeys(amountReceived);
        	bill.ReceivePaymentForm.btnSaveClose.Click();
        	//bill.OutputPromptForm.OutputPrompt.Click();
        	//bill.OutputPromptForm.btnOk1.Click();
        	Validate.Attribute(bill.MainForm.FilesIndexForm.cellGenRetainerInfo, "Text", amountReceived);
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            cmn.ClosePrompt();
        }
    }
}
