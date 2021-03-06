﻿/*
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
using SmokeTest.Modules.Utilities;
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
    	Common cmn=new Common();
        public BillingCreateBill()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	Delay.Seconds(1);
        	bill.ContextMenu.optionBill.Click();
        	Delay.Seconds(2);
        	if(bill.PromptForm.SelfInfo.Exists(3000))
        	{
        		//bill.PromptForm.btnYes.Click();
        		if(bill.PromptForm.btnOkInfo.Exists(3000))
        		{bill.PromptForm.btnOk.Click();}
        	}
        	
        	if(bill.PromptForm.SelfInfo.Exists(3000))
        	{
        		if(bill.PromptForm.btnYesInfo.Exists(3000))
        		{bill.PromptForm.btnYes.Click();}
        	}
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
            cmn.ClosePrompt();
        }
    }
}
