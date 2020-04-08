/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/8/2020
 * Time: 3:15 PM
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
using SmokeTest.Modules;
using SmokeTest.Repositories;
using SmokeTest.Modules.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateTimerToolbar.
    /// </summary>
    [TestModule("2D29BFDB-4D68-4C01-A283-20C0B05B1279", ModuleType.UserCode, 1)]
    public class validateTimerToolbar : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTimerToolbar()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Files files=Files.Instance;
        
        
        private void validateTimerTbar()
		{
			files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	if(files.MainForm.ShowTimerInfo.Exists(3000))
        	{
        		files.MainForm.ShowTimer.Click();
        		if(files.TimerToolbarForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Timer toolbar is seen as expected");
        			Validate.Exists(files.TimerToolbarForm.Toolbar.btnViewEntryDetailsInfo,"View Time Entry Details List is displayed as expected");
        			Validate.Exists(files.TimerToolbarForm.Toolbar.btnCreateNewTimeInfo,"Create New Time Entry Button is displayed as expected");
        			Validate.Exists(files.TimerToolbarForm.Toolbar.btnStartStopTimerInfo,"Start/Stop Timer Button is displayed as expected");
        			
        			files.TimerToolbarForm.Toolbar.MenuItem.Click();
        			Validate.Exists(files.TimerToolbarForm.Toolbar.HideTimerToolbarInfo,"Hide Timer Toolbar Button is displayed as expected");
        			Validate.Exists(files.TimerToolbarForm.Toolbar.ExitAmicusAttorneyInfo,"Exit Amiucs Attorney Button is displayed as expected");
        			
        			
        			
        		}
        		   
        	}
        	
        	
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	if(files.MainForm.HideTimerInfo.Exists(3000))
        	{
        		files.MainForm.HideTimer.Click();
        		files.TimerToolbarForm.SelfInfo.WaitForNotExists(3000);
        		Validate.NotExists(files.TimerToolbarForm.SelfInfo,"Timer Toolbar is not present as expected");

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
            validateTimerTbar();
        }
    }
}
