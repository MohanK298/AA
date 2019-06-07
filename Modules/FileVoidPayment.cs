/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-15
 * Time: 12:18 PM
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
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of FileVoidPayment.
    /// </summary>
    [TestModule("9E7A85C9-75FE-4F92-A6D7-E860B491133A", ModuleType.UserCode, 1)]
    public class FileVoidPayment : ITestModule
    {
        Files file = Files.Instance;
        Bill bill = Bill.Instance;
        
        //Variables
    	string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	
    	string _lastName = "";
    	[TestVariable("EEAB8051-D07D-447A-972F-314EAB0ECD9C")]
    	public string lastName
    	{
    		get { return _lastName; }
    		set { _lastName = value; }
    	}
    	
    	
    	string _firstName = "";
    	[TestVariable("EAB5AE1D-EA6C-476A-9C0D-9A83926A1A9E")]
    	public string firstName
    	{
    		get { return _firstName; }
    		set { _firstName = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("DDE10115-729E-4144-AAC6-425EAF372517")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
        
        public FileVoidPayment()
        {
            // Do not delete - a parameterless constructor is required!
        }

	    public void FindFile()
	    {
	     	//Find file
	     	file.MainForm.btnFiles.Click();
	       	file.MainForm.FilesIndexForm.btnQuickFind.Click();
	       	//file.FindFilesForm.txtFindFile.TextValue = fileName + time;
	       	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
	       	file.FindFilesForm.btnOK.Click();
	    	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
	    	file.FileDetailForm.Payment.DoubleClick();
	    	Validate.Exists(bill.ReceivePaymentForm.PayAmountInfo);
	    	Report.Success("Payment Amount Validated");
	    	bill.ReceivePaymentForm.btnVoid.Click();
	    	bill.PromptForm.btnYes1.Click();
	    	bill.PromptForm.btnOk.Click();
	    	//bill.OutputPromptForm.OutputPrompt.Click();
	    	//bill.OutputPromptForm.btnOk.Click();
	    	//bill.ReportViewerForm.btnClose.Click();
	    	Validate.Exists(file.FileDetailForm.VoidPaymentInfo);
	    	file.FileDetailForm.btnSaveClose.Click();
        
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            FindFile();
        }
    }
}
