/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/27/2020
 * Time: 3:26 PM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of startApp.
    /// </summary>
    [TestModule("5B05B347-E4F6-4DBD-B9A7-C588BFFBEA40", ModuleType.UserCode, 1)]
    public class startApp : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public startApp()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Login login=Login.Instance;
        Common cmn=new Common();
        Preferences pref=Preferences.Instance;
        SmokeTestRepository str = SmokeTestRepository.Instance;
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void OpenApp()
        {
        	Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
        }
        
        private void CloseAnnoncementForm()
        {
        	if(str.AnnouncementForm.SelfInfo.Exists(3000))
        	{
        		str.AnnouncementForm.Self.Activate();
        		str.AnnouncementForm.SelfInfo.WaitForExists(3000);
        		str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOKInfo.WaitForExists(3000);
        		
        		
        		
        			str.AnnouncementForm.AmicusCheckBox1.Check();   	
        			str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOK.Click();
        		   }
        		
        	
        }
        
        private void EnterCredentials()
        {
        	login.SelfInfo.WaitForExists(10000);
        	login.LoginForm.FirmId.TextValue="QA Toronto 10";
        	login.LoginForm.UserId.TextValue="admin user";
        	login.LoginForm.Pwd.TextValue="password";
        	login.LoginForm.ServerName.TextValue="J4-Mohanss";
        	login.LoginForm.btnLogin.Click();
        	str.MainForm.SelfInfo.WaitForExists(10000);
        	CloseAnnoncementForm();
        	if(pref.MainForm.SbMainform.Visible.Equals(false))
        	{pref.MainForm.OfficeModule.Click();
    		pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.StatusBar.Click();
			Delay.Seconds(2);}
        	cmn.switchUser("MKumar 298");
        	
        }

        
			
			
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            OpenApp();
            EnterCredentials();
            //cmn.switchUser("MKumar 298");

        }
    }
}
