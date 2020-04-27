/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/24/2015
 * Time: 8:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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

using SmokeTest.Repositories;
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;

namespace SmokeTest
{
    /// <summary>
    /// Description of LoginM.
    /// </summary>
    [TestModule("86270BF4-CE4D-42E6-99FD-39A39E59D33D", ModuleType.UserCode, 1)]
    public class LoginM : ITestModule
    {
    	//Repository Variable
    	SmokeTestRepository str = SmokeTestRepository.Instance;
    	Login login=Login.Instance;
    	Duration customWaitTime = new Duration(300000);
    	
    	string _password = "";
    	[TestVariable("11780AF6-1CBD-4BB8-B064-12B28C206E17")]
    	public string password
    	{
    		get { return _password; }
    		set { _password = value; }
    	}
    	
    	string _userID = "";
    	[TestVariable("E34AE3EA-C5DF-4861-91C7-AB3D9C953C93")]
    	public string userID
    	{
    		get { return _userID; }
    		set { _userID = value; }
    	}
    	
    	string _serverName = "";
    	[TestVariable("50675DA4-DCB6-4140-A803-31586A63A5C0")]
    	public string serverName
    	{
    		get { return _serverName; }
    		set { _serverName = value; }
    	}
    	
    	string _firmID = "";
    	[TestVariable("87461984-FC83-4FC3-8D22-67C0F70E9E62")]
    	public string firmID
    	{
    		get { return _firmID; }
    		set { _firmID = value; }
    	}
    	
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LoginM()
        {
            // Do not delete - a parameterless constructor is required!
        }
       
        	
        //Launch application and login
        public void LoginUser(){
        	
        	 var datasource=Ranorex.DataSources.Get("LoginData");
        datasource.Load();

//        	str.LoginForm.txtFirmID.TextValue = firmID;
//        	Delay.Seconds(1);
//        	
//        	str.LoginForm.txtUserID.TextValue = userID;
//        	Delay.Seconds(1);
//        	
//        	str.LoginForm.txtPassword.TextValue = password;
//        	Delay.Seconds(1);
//        	
//        	str.LoginForm.txtServerName.TextValue = serverName;
//        	Delay.Seconds(1);
//        	
//        	str.LoginForm.btnLogin.Click();
        	
        	
        	login.LoginForm.FirmId.TextValue=datasource.Rows[0].Values[0].ToString();//"QA Toronto 10";
        	login.LoginForm.UserId.TextValue=datasource.Rows[0].Values[1].ToString();//="admin user";
        	login.LoginForm.Pwd.TextValue=datasource.Rows[0].Values[2].ToString();//"password";
        	login.LoginForm.ServerName.TextValue=datasource.Rows[0].Values[3].ToString();//"J4-Mohanss";
        	login.LoginForm.btnLogin.Click();
        	Delay.Seconds(10);
        
        	
        	
        }

        public void update()
        {
        	Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
        	
        	if(!login.Update.SelfInfo.Exists(30000)&& !login.LoginForm.SelfInfo.Exists(30000))
        	{
        		CloseProcess();
        		Keyboard.Press(System.Windows.Forms.Keys.Enter, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
        		Report.Info("Warning message was closed successfully and Amicus Attorney Exe File Opened");
        	}
        	
        	if(login.Update.SelfInfo.Exists(30000))
        	{
        		if(login.Update.btnContinueInfo.Exists(3000))
        		{
        			login.Update.btnContinue.Click();
        		}
        		login.Update.btnFinishInfo.WaitForExists(240000);
        		if(login.Update.btnFinishInfo.Exists(3000))
        		{
        			login.Update.btnFinish.Click();
        			Report.Success("Amicus Attorney Updated Successfully");
        		}
        			
        	}
        	else
        	{
        	
//        		Keyboard.Press(System.Windows.Forms.Keys.Enter, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//        		Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
//        		Report.Info("Warning message was closed successfully and Amicus Attorney Exe File Opened");
//        	
        	Report.Success("Amicus Attorney opened Successfully");
        	}
        }
        
        
        private void CloseProcess()
        {
        	foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			{
			if (myProc.ProcessName == "OUTLOOK")
			{
				myProc.Kill();
				Report.Success("Outlook proccess is closed successfully");
			}
			if (myProc.ProcessName == "WINWORD")
			{
				myProc.Kill();
				Report.Success("Word proccess is closed successfully");
			}
			
			if (myProc.ProcessName == "AmicusAttorney.XWin")
			{
				myProc.Kill();
				Report.Success("Amicus Attorney proccess is closed successfully");
			}
			
			}
        	Delay.Seconds(10);
        }
        
        
        
        //This part will handle billing setup on the first login of the day
        public void BillingSetup(){
        	for(int i=0; i<7; i++){
        		str.BillingStartupForm.btnNext.Click();	
        	}
        	str.BillingStartupForm.btnFinish.Click();
        	str.StickyDetails.btnClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CloseProcess();
            update(); 
            LoginUser();
//           
           /*try{
           		BillingSetup();
           }catch(Exception ex){
           		Report.Log(ReportLevel.Warn, "(Could Not Find Billing Setup Window) " + ex.Message);
           }*/
        //   Delay.Seconds(180);
           //str.MainForm.SelfInfo.WaitForExists(customWaitTime);
        }
    }
}