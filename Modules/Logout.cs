/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 1:56 PM
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
using Ranorex.AutomationHelpers.Modules;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("D10246F4-AF1F-4921-AC63-4F462998C5D5", ModuleType.UserCode, 1)]
    public class Logout : ITestModule
    {
    	//Repository variable
        SmokeTestRepository str = SmokeTestRepository.Instance;
        
        public Logout()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
//        private SendReport()
//        {
//        	EmailModule em=new EmailModule();
//        	em.SendPdfReportOnComplete();
//        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            str.MainForm.btnCloseApp.Click();
            Report.Success("Log out passed");
        }
    }
}
