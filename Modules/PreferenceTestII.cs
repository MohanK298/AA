/*
 * Created by Ranorex
 * User: Administrator
 * Date: 11/5/2018
 * Time: 3:19 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of PreferenceTestII.
    /// </summary>
    [TestModule("48520123-515D-49D3-945C-12E4D882C59C", ModuleType.UserCode, 1)]
    public class PreferenceTestII : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PreferenceTestII()
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
            
            SmokeTest.Recordings.PreferenceTestII.Start();
        }
    }
}
