/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 1:03 PM
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
    /// Description of print_icon_Validate.
    /// </summary>
    [TestModule("1B2CADB0-9A3B-4C73-AA4A-2D8645701465", ModuleType.UserCode, 1)]
    public class print_icon_Validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public print_icon_Validate()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Bill bill=Bill.Instance;
        
        private void validate_Print()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	Validate.Exists(bill.MainForm.btnReprintBillsInfo,"Print Bills Button Exists as expected");
        	Validate.AttributeEqual(bill.MainForm.btnReprintBillsInfo,"Enabled","True","Print Bills Button is Enabled as expected");
        	
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
            validate_Print();
        }
        
    }
}
