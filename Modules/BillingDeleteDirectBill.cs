/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/5/2015
 * Time: 2:09 PM
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
    [TestModule("C32E5CBF-1425-4402-9D38-023EA2F05792", ModuleType.UserCode, 1)]
    public class BillingDeleteDirectBill : ITestModule
    {
        //Repository Variable
        Bill bill = Bill.Instance;
        
        public BillingDeleteDirectBill()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	Delay.Seconds(2);
        	bill.MainForm.optionPlus.Click("8;11");
        	
        	//bill.MainForm.Payment.Click(System.Windows.Forms.MouseButtons.Right);
           	//bill.AmicusAttorneyXWin.optionDelete.Click();
            //bill.PromptForm.btnYes.Click();
            
        	//bill.MainForm.optionPlus.Click("8;11");
            try{
        	bill.MainForm.listPayment.Click(System.Windows.Forms.MouseButtons.Right, "159;15");
            bill.ContextMenu.optionDelete.Click();
            bill.PromptForm.btnYes.Click();	
        	} catch(Exception ex){
        		Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message);
        	}
            
            bill.MainForm.optionPlus.Click(System.Windows.Forms.MouseButtons.Right);
            bill.ContextMenu.optionDelete.Click();
            bill.PromptForm.btnYes.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
          //  Utilities.Common.ClosePrompt();
        }
    }
}
