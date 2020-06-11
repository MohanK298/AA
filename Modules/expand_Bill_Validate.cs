/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 6:47 PM
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
    /// Description of expand_Bill_Validate.
    /// </summary>
    [TestModule("0BC6FB57-E6E7-4338-BA34-58DD339890BA", ModuleType.UserCode, 1)]
    public class expand_Bill_Validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public expand_Bill_Validate()
        {
            // Do not delete - a parameterless constructor is required!
        }

         Bill bill=Bill.Instance;
        private void expand_Validation_Bill()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.cbFirstRow.Check();
        	Delay.Seconds(2);
        	bill.MainForm.optionPlus.Click("8;11");
        	Validate.AttributeEqual(bill.MainForm.cbFirstRowInfo,"Checked","True","First Row is checked as expected");
        	bill.MainForm.cbFirstRow.Uncheck();
        	bill.MainForm.optionPlus.Click("8;11");
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
            expand_Validation_Bill();
        }
    }
}
