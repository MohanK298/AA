/*
 * Created by Ranorex
 * User: qa
 * Date: 6/6/2019
 * Time: 10:54 AM
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of CheckCache.
    /// </summary>
    [TestModule("CCAF2AA4-5385-4D93-BF01-8068B00A91B5", ModuleType.UserCode, 1)]
    public class CheckCache : ITestModule
    {
    	FileDetails fd = FileDetails.Instance;
    	Communications cm = Communications.Instance;
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckCache()
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
            cm.MainForm.LeftPanel.Files.Click();
            
        }
        
        private void AddSummary()
        {
        	
        }
    }
}
