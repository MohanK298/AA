/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/8/2020
 * Time: 10:55 AM
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
    /// Description of dateCalculatorValidation.
    /// </summary>
    [TestModule("97993A77-0162-496A-BE00-65012CDAD2FB", ModuleType.UserCode, 1)]
    public class dateCalculatorValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public dateCalculatorValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        FirmSettings frm=FirmSettings.Instance;
        
        private void DateCalculatorValidate()
        {
        	frm.MainForm.Tools.Click();
        	Delay.Seconds(1);
        	frm.MainForm.DateCalculator.Click();
        	if(frm.DateCalculatorForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Date Calculator Form is opened successfully");
        		frm.DateCalculatorForm.Toolbar1.btnOK.Click();
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
            DateCalculatorValidate();
        }
    }
}
