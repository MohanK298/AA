/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 11:40 AM
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
    [TestModule("4617983A-3A28-4D33-BE7A-4F2F47CC588A", ModuleType.UserCode, 1)]
    public class DeletePhoneCall : ITestModule
    {
        Communications phoneCall = Communications.Instance;
        Common cmn=new Common();
        public DeletePhoneCall()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void DeleteCall(){
        	//Open phone call
        	phoneCall.MainForm.listFirstFile.DoubleClick();
        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnDelete.Click();
        	phoneCall.PromptForm.btnYes.Click();
        	
        	Report.Success("Phone Call Delete passed");
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteCall();
            cmn.ClosePrompt();
        }
    }
}
