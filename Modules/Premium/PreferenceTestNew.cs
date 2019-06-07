/*
 * Created by Ranorex
 * User: Administrator
 * Date: 11/6/2018
 * Time: 3:02 PM
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

namespace SmokeTest.Modules.Premium
{
    /// <summary>
    /// Description of PreferenceTestNew.
    /// </summary>
    [TestModule("B716090A-A578-469C-BC4E-AF3FA3B4AD44", ModuleType.UserCode, 1)]
    public class PreferenceTestNew : ITestModule
    {
    	
    	Repositories.Premium.PreferencesNew pref = new SmokeTest.Repositories.Premium.PreferencesNew();
    	Duration customWaitTime = new Duration(3000);
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PreferenceTestNew()
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
            
            action();
        }
        
        private void action()
        {
        	foreach (var element in Repositories.Premium.PreferencesNew.Instance.MainForm.PreferencesForm1.SelfInfo.Children) {
        		
        		Report.Log(ReportLevel.Info, "Element in the folder: " + element.Path);
        	}
        }
    }
}
