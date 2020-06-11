/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 3:47 PM
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
    /// Description of add_checkbox_validate.
    /// </summary>
    [TestModule("0F389B8D-CE1B-4105-BCDC-4F66A6E78707", ModuleType.UserCode, 1)]
    public class add_checkbox_validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public add_checkbox_validate()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
          Bill bill=Bill.Instance;
        
        private void add_Check_Validate()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	Validate.Exists(bill.MainForm.cbFirstRowInfo,"First Row Checkbox Exists as expected");
        	bill.MainForm.cbFirstRow.Check();
        	Validate.AttributeEqual(bill.MainForm.cbFirstRowInfo,"Checked","True","First Row Checkbox is Checked as expected");
        	bill.MainForm.cbFirstRow.Uncheck();
        	Validate.AttributeEqual(bill.MainForm.cbFirstRowInfo,"Checked","False","First Row Checkbox is Unchecked as expected");
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
            add_Check_Validate();
        }
    }
}
