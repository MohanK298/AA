/*
 * Created By Qiao
 * User: Administrator
 * Date: 2019-02-12
 * Time: 11:23 AM
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

namespace SmokeTest.Modules.Utilities
{
    /// <summary>
    /// Description of Constants.
    /// </summary>
    [TestModule("B2424334-CCFF-4130-B4C2-8C7A6556EE0A", ModuleType.UserCode, 1)]
    public class Constants : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Constants()
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
        }
        
        public static Duration customWaitTime = new Duration(3000);
    }
}
