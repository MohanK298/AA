/*
 * Created by Ranorex
 * User: qa
 * Date: 6/14/2019
 * Time: 3:31 PM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories.Premium;

namespace SmokeTest.Modules.Premium
{
    /// <summary>
    /// Description of OpenTutorial.
    /// </summary>
    [TestModule("4427E132-D9BC-430D-B162-0652B0111DDE", ModuleType.UserCode, 1)]
    public class OpenTutorial : ITestModule
    {
    	Communications cm = Communications.Instance;
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenTutorial()
        {
            // Do not delete - a parameterless constructor is required!
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
            
            cm.MainForm.AttorneyOrBilling.Attorney.Click();
            cm.MainForm.SCMenu.Open_Tutorial.Click();
        }
    }
}
