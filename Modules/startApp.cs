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

string _username = "";
[TestVariable("96caed55-fd85-4c44-9534-5d329b545087")]
public string username
{
	get { return _username; }
	set { _username = value; }
}

string _password = "";
[TestVariable("d2bca0ae-b50d-43c3-824a-5717f903ef75")]
public string password
{
	get { return _password; }
	set { _password = value; }
}

string _server = "";
[TestVariable("9c23c705-7713-432f-8020-d3bf7d166b0d")]
public string server
{
	get { return _server; }
	set { _server = value; }
}

 string _firmid = "";
[TestVariable("f0a21d94-1772-4e62-ad3a-4bb55cc94183")]
public string firmid
{
	get { return _firmid; }
	set { _firmid = value; }
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
        	if(str.AnnouncementForm.SelfInfo.Exists(10000))
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

        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	
        	login.SelfInfo.WaitForExists(10000);
        	
        	login.LoginForm.FirmId.TextValue=datasource.Rows[1].Values[0].ToString();//"QA Toronto 10";
        	login.LoginForm.UserId.TextValue=datasource.Rows[1].Values[1].ToString();//="admin user";
        	login.LoginForm.Pwd.TextValue=datasource.Rows[1].Values[2].ToString();//"password";
        	login.LoginForm.ServerName.TextValue=datasource.Rows[1].Values[3].ToString();//"J4-Mohanss";
        	login.LoginForm.btnLogin.Click();
        	str.MainForm.SelfInfo.WaitForExists(20000);
        	CloseAnnoncementForm();
        	if(pref.MainForm.SbMainform.Visible.Equals(false))
        	{pref.MainForm.OfficeModule.Click();
    		pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.StatusBar.Click();
			Delay.Seconds(2);}
        }

        
			
			
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            OpenApp();
            EnterCredentials();
            cmn.ClosePrompt();

        }
    }
}
