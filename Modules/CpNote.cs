/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-04-06
 * Time: 11:28 AM
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

using SmokeTest.Repositories.Browser;
using SmokeTest.Modules.Utilities;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CpNote.
    /// </summary>
    [TestModule("7E9B3968-9695-4B83-B574-929D264F1A61", ModuleType.UserCode, 1)]
    public class CpNote : ITestModule
    {
    	SmokeTest.Repositories.Note note = new SmokeTest.Repositories.Note();
        SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
        SmokeTest.Repositories.Browser.ClientPortal cp = new SmokeTest.Repositories.Browser.ClientPortal();
        
        
        public CpNote()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action()
        {
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Notes.Click();
        	Delay.Milliseconds(350);
        	file.FileDetailForm.MyNotes.Click();
        	Delay.Milliseconds(1500);
        	file.FileDetailForm.btnNewNote.Click();
        	Delay.Milliseconds(2000);
//        	file.FileDetailForm.txtMainNote.PressKeys("Testing Note for Client Portal.");
        	note.NoteDetail.MenubarFillPanel.txtNoteBoxEdit.PressKeys("Testing Note for Client Portal.");
        	Delay.Seconds(2);
        	note.NoteDetail.MenubarFillPanel.btnOK.Click();
        	Delay.Milliseconds(1000);
        	Validate.Exists(file.FileDetailForm.MyNote);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(2);
   		}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
//            Action();
			BrowserVerify();
        }
        
        void BrowserVerify()
        {
//        	Host.Local.RunApplication("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
        	
//			Host.Local.ClearBrowserCache("chrome");
			Host.Local.OpenBrowser("https://test.amicusanywhere.com/Portal");
			cp.AmicusAttorney.Self.EnsureVisible();
			cp.AmicusAttorney.LoginPage.TbEmailInfo.WaitForExists(Utilities.Constants.customWaitTime);
			cp.AmicusAttorney.LoginPage.TbEmail.PressKeys("frien1992@einrot.com");
			cp.AmicusAttorney.LoginPage.TbPwd.PressKeys("Password123$$");
			cp.AmicusAttorney.LoginPage.BtLogin.Click();
			
			PopupWatcher activeSessionDialog = new PopupWatcher();
			activeSessionDialog.WatchAndClick(cp.AmicusAttorney.LoginPage.ContinueToLoginAnywayInfo, cp.AmicusAttorney.LoginPage.ContinueToLoginAnywayInfo);
			activeSessionDialog.Start();
			try {
				cp.AmicusAttorney.Main.UserNameInfo.WaitForExists(Utilities.Constants.customWaitTime * 10);
				Report.Log(ReportLevel.Info, "Client Portal Login Successfully for client: " + cp.AmicusAttorney.Main.UserName.GetAttributeValue<String>("InnerText").ToString());
				Report.Log(ReportLevel.Info, "Client Portal build number under curent test is " + cp.AmicusAttorney.Main.BuildNumber.GetAttributeValue<String>("InnerText").ToString());
			} catch (Exception) {
				Report.Log(ReportLevel.Error, "Failed to login Client Portal within 30 seconds, terminating the Client Portal test case");
			}
			activeSessionDialog.Stop();
			cp.AmicusAttorney.Main.LkLogout.Click();
			Delay.Seconds(5);
			
			Host.Local.KillBrowser("chrome");
        }
    }
}
