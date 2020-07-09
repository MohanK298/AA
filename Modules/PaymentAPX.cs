/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-15
 * Time: 11:48 AM
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

using SmokeTest.Recordings;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of PaymentAPX.
    /// </summary>
    [TestModule("BE0C556A-A60E-4803-A426-DBDE17C7E9B3", ModuleType.UserCode, 1)]
    public class PaymentAPX : ITestModule
    {
      	Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        Common cmn=new Common();
        People people = People.Instance;
        
        public PaymentAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform()
        {
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.ToolbarBill.Click();
        	bill.MainForm.ReceivePayment.Click();
        	bill.ReceivePaymentForm.btnSelectFile.Click();
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	bill.ReceivePaymentForm.cmbbxType.Click();
        	bill.ListItem.selectCCapx.Click();
        	bill.ReceivePaymentForm.linkAdd.Click();
        	bill.PromptForm.btnYes1.Click();
        	people.apxtestabacusnext.ccNumber.PressKeys("375987654321004");
        	people.apxtestabacusnext.selectMonth.Click();
        	people.apxtestabacusnext.MonthValue.Click();
			people.apxtestabacusnext.selectYear.Click();
            people.apxtestabacusnext.YearValue.Click();
            people.apxtestabacusnext.selectState.Click();
            people.apxtestabacusnext.StateValue.Click();
            people.apxtestabacusnext.billingAddress.PressKeys("1 Yonge St");
            people.apxtestabacusnext.city.PressKeys("Toronto");
//            people.apxtestabacusnext.txtZip.PressKeys("12345");
            people.apxtestabacusnext.btnSubmit.Click();
            Validate.Exists(bill.ReceivePaymentForm.ccAMEXInfo);
            bill.ReceivePaymentForm.enterAmount.PressKeys("2.30");
        	bill.ReceivePaymentForm.btnPayNow.Click();
        	Validate.Exists(bill.PromptForm.AmountTxtInfo);
        	bill.PromptForm.btnYes1.Click();
        	Delay.Seconds(3);
        	if(bill.PromptForm.ConfirmationInfo.Exists())
        	{
        		bill.PromptForm.btnOk.Click();
        	}
        	else
        	{
        		Report.Info("Generating confirmation by more than 3sec");
        	}
        	Delay.Milliseconds(300);
        	
            	
        	
        	
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
