/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/8/2020
 * Time: 3:50 PM
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
    /// Description of validateToolbarsRetain.
    /// </summary>
    [TestModule("1B4C0726-1B1D-4AC9-8051-42C59F28A19F", ModuleType.UserCode, 1)]
    public class validateToolbarsRetain : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateToolbarsRetain()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Files files=Files.Instance;
        Login login=Login.Instance;
        SmokeTestRepository str = SmokeTestRepository.Instance;
        
        
        private void OpenAmicusApp()
        {
        	Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	Delay.Seconds(2);
        	datasource.Load();
        	
        	login.SelfInfo.WaitForExists(10000);
        	
        	login.LoginForm.FirmId.TextValue=datasource.Rows[0].Values[0].ToString();//"QA Toronto 10";
        	login.LoginForm.UserId.TextValue=datasource.Rows[0].Values[1].ToString();//="admin user";
        	login.LoginForm.Pwd.TextValue=datasource.Rows[0].Values[2].ToString();//"password";
        	login.LoginForm.ServerName.TextValue=datasource.Rows[0].Values[3].ToString();//"J4-Mohanss";
        	login.LoginForm.btnLogin.Click();
        	if(files.PromptForm.SelfInfo.Exists(3000))
        	{
        		files.PromptForm.ButtonNo.Click();
        	}
        	Delay.Seconds(10);
        }
        	
        
        
        
        
        private void validateToolbarRetainExitAA()
		{
        	
        	files.MainForm.Self.Activate();
        	
        	
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
        		}
        	}
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	
        	
        	if(files.MainForm.ShowAmicusToolbarInfo.Exists(3000))
        	{
        		files.MainForm.ShowAmicusToolbar.Click();
        		if(files.ToolbarForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Amicus toolbar is seen as expected");
        		}
        	}
        	
        	str.MainForm.btnCloseApp.Click();
        	OpenAmicusApp();
        	
        	
        	if(files.MainForm.ShowTimerInfo.Exists(3000))
        	{
        		files.MainForm.ShowTimer.Click();
        		if(files.TimerToolbarForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Timer toolbar is seen as expected after reopening the application");
        		}
        	}
        	
        	if(files.MainForm.ShowAmicusToolbarInfo.Exists(3000))
        	{
        		files.MainForm.ShowAmicusToolbar.Click();
        		if(files.ToolbarForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Amicus toolbar is seen as expected  after reopening the application");
        		}
        	}
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	files.MainForm.HideAmicusToolbar.Click();
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	files.MainForm.HideTimer.Click();
        	
        	
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
            validateToolbarRetainExitAA();
        }
    }
}
