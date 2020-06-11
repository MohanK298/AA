/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 7:04 PM
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
    /// Description of bill_format_Validate.
    /// </summary>
    [TestModule("5223F88F-8375-4A7D-B37E-BE714089E38D", ModuleType.UserCode, 1)]
    public class bill_format_Validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public bill_format_Validate()
        {
            // Do not delete - a parameterless constructor is required!
        }
			Bill bill=Bill.Instance;
        private void expand_Validation_Bill()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.optionPlus.DoubleClick();
        	
        	if(bill.PdfBillImage.SelfInfo.Exists(3000))
        	{
        		Report.Success("PDF Document is opened for the Bill and is the expected Result");
        		bill.PdfBillImage.Self.Close();
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
            expand_Validation_Bill();
        }
    }
}
