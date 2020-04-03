/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/3/2020
 * Time: 11:47 AM
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
    /// Description of VerifyAddtoFile_MultiSelectMails.
    /// </summary>
    [TestModule("EADF9548-D7DA-4A10-91C7-B05A40259440", ModuleType.UserCode, 1)]
    public class VerifyAddtoFile_MultiSelectMails : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyAddtoFile_MultiSelectMails()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        Files file=Files.Instance;
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
        
        private void ValidateAddtoFileButton_MultiSelectMails()
        {
        	string mailsub="";
        	OpenApp();
        	mailsub=cmn.MultiSelectEmail(3,true);
        	outlook.Outlook.tabAmicusTasks.Click();
    		Report.Success("Amicus Tasks Tab is opened successfully");
    		Delay.Seconds(2);

    		Report.Success("Add to File Button is clicked successfully");
    		outlook.Outlook.AmicusAttorneyTasks1.btnAddToFile.Click();
    		if(file.FileSelectForm.SelfInfo.Exists(3000))
    		{
    			file.FileSelectForm.listFirstFoundFile.DoubleClick();
    			Report.Success("File Added Successfully for the E-Mail");
    		}
   			Report.Info(mailsub);
   			outlook.Outlook.Self.Close();
   			ValidateMailsInFile(mailsub);
   			
        }
        
        private void ValidateMailsInFile(string sub)
        {
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles1.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(1);
        	file.FileDetailForm.Communications.Click();
        	Delay.Seconds(3);
        	file.FileDetailForm.MyEMails.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[0],"My Email Communications Table");
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[1],"My Email Communications Table");
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[2],"My Email Communications Table");
        	file.FileDetailForm.btnSaveClose.Click();
        	
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
            ValidateAddtoFileButton_MultiSelectMails();
        }
    }
}
