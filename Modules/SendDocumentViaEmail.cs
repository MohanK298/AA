/*
 * Created by Ranorex
 * User: qa
 * Date: 6/4/2019
 * Time: 1:58 PM
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
    /// Description of SendDocumentVisEmail.
    /// </summary>
    [TestModule("C6563AE3-58E0-48D6-8BA5-46266FC9D395", ModuleType.UserCode, 1)]
    public class SendDocumentViaEmail : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendDocumentViaEmail()
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
    }
}
