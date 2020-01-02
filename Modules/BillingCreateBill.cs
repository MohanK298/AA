/*
 * Created by Ranorex
 * User: Admin
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Recordings;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("2BA134CF-3728-4D05-BE50-D4E5EC0B8C8B", ModuleType.UserCode, 1)]
    public class BillingCreateBill : ITestModule
    {
    	//Variables
    	Bill bill = Bill.Instance;
    	
        public BillingCreateBill()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	bill.AmicusAttorneyXWin.optionBill.Click();
        	bill.PromptForm.btnOk.Click();
        	//bill.BillingDetailForm.btnClose.Click();
        	//bill.PromptForm.btnYes.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            BillTest.Start();
            Utilities.Common.ClosePrompt();
        }
    }
}
