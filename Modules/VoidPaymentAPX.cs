/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-18
 * Time: 12:09 PM
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

using SmokeTest.Recordings;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    
    [TestModule("6CA6E008-A405-41E7-984C-EFEA6FB6490C", ModuleType.UserCode, 1)]
    public class VoidPaymentAPX : ITestModule
    {
        Bill bill = Bill.Instance;
        
        public VoidPaymentAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }
		public void Todo()
		{
			bill.MainForm.btnBilling.Click();
        	bill.MainForm.optionPlus.Click("8;11");
        	bill.MainForm.BillItem.Click(System.Windows.Forms.MouseButtons.Right);
        	bill.AmicusAttorneyXWin2.ExpandAll.Click();
           	bill.MainForm.PaymentItem.Click(System.Windows.Forms.MouseButtons.Right);        	
        	Validate.Exists(bill.ReceivePaymentForm.PayAmountInfo);
	    	Report.Success("Payment Amount Validated");
	    	bill.ReceivePaymentForm.btnVoid.Click();
	    	bill.PromptForm.btnYes1.Click();
	    	bill.PromptForm.btnOk.Click();
        	
        	       	
        	
		}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Todo();
            //VoidRec.Start();
        }
    }
}
