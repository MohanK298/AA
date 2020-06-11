/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 4:00 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateNoBillPrint.
    /// </summary>
    [TestModule("6708A0A8-3588-4B41-8955-A1CE4EA44DD6", ModuleType.UserCode, 1)]
    public class validateNoBillPrint : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateNoBillPrint()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
         Bill bill=Bill.Instance;
        
        private void print_nobill_Validate()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	
        	bill.MainForm.btnReprintBills.Click();
        	if(bill.PromptForm.SelfInfo.Exists(3000))
        	{
        		Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text","There are no Bills selected.","No Bills selected prompt is shown as expected");
        		bill.PromptForm.btnOk.Click();
        	}
        }
        
        
        
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            print_nobill_Validate();
        }
    }
}
