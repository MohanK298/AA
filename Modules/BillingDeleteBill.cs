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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("6CED7C3C-8293-4FA9-8383-43013E0DA093", ModuleType.UserCode, 1)]
    public class BillingDeleteBill : ITestModule
    {
        //Repository Variable
        Bill bill = Bill.Instance;
        Common cmn=new Common();
        public BillingDeleteBill()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform()
        {
        	bill.MainForm.optionPlus.Click("8;11");
        	
        	cmn.OpenContextMenuItemFromTable(bill.MainForm.tblHistoryList,"Payment","History List Table");
        	//bill.MainForm.Payment.Click(System.Windows.Forms.MouseButtons.Right);
           	bill.AmicusAttorneyXWin.optionDelete.Click();
            bill.PromptForm.btnYes.Click();
            
        	bill.MainForm.optionPlus.Click("8;11");
            try{
        	cmn.OpenContextMenuItemFromTable(bill.MainForm.tblHistoryList,"Bill","History List Table");
        		//bill.MainForm.listPayment.Click(System.Windows.Forms.MouseButtons.Right, "159;15");
            bill.AmicusAttorneyXWin.optionDelete.Click();
            bill.PromptForm.btnYes.Click();	
        	} catch(Exception ex){
        		Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message);
        	}
            
//            bill.MainForm.optionPlus.Click(System.Windows.Forms.MouseButtons.Right);
//            bill.AmicusAttorneyXWin.optionDelete.Click();
//            bill.PromptForm.btnYes.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            Utilities.Common.ClosePrompt();
        }
    }
}
