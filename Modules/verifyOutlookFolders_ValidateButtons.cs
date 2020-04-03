/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/2/2020
 * Time: 3:35 PM
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
    /// Description of verifyOutlookFolders_ValidateButtons.
    /// </summary>
    [TestModule("DCF5C849-F374-4EAC-A917-7706F079ED7F", ModuleType.UserCode, 1)]
    public class verifyOutlookFolders_ValidateButtons : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyOutlookFolders_ValidateButtons()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
        
        private void CheckFolderButtonValidationInOutlook()
        {
        	OpenApp();
        	
        	if(outlook.Outlook.TreeItemGmailInfo.Exists(3000))
        	{
        		outlook.Outlook.TreeItemGmail.DoubleClick();
        	}
        	if(outlook.Outlook.MailFolders.DraftsInfo.Exists(3000))
        	{
        		outlook.Outlook.MailFolders.Drafts.Click();
        		Report.Success("Drafts Folders is opened successfully");
        		outlook.Outlook.tabAmicusTasks.Click();
        		Report.Success("Amicus Tasks Tab is opened successfully");
        		if(outlook.Outlook.AmicusAttorneyTasks1.SelfInfo.Exists(3000))
        		{
        			if(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(3000))
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo,"Enabled","False","Details button disabled as expected");
 				}
        			else
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnViewAddToRelatedFileInfo,"Enabled","False","View/Add Related to File Button is disabled as expected");}
        				
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToPeopleInfo,"Enabled","False","Add to People Button is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnDetailsInfo,"Enabled","False","Details is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.txtSearchTextInfo,"Enabled","True","Search Query is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnSearchAmicusInfo,"Enabled","True","Search Button is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAboutInfo,"Enabled","True","About Button is enabled as expected");
        		}
        	}
        	
        	
        	if(outlook.Outlook.MailFolders.BinInfo.Exists(3000))
        	{
        		outlook.Outlook.MailFolders.Bin.Click();
        		Report.Success("Bin Folders is opened successfully");
        		outlook.Outlook.tabAmicusTasks.Click();
        		Report.Success("Amicus Tasks Tab is opened successfully");
        		if(outlook.Outlook.AmicusAttorneyTasks1.SelfInfo.Exists(3000))
        		{
        			if(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(3000))
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo,"Enabled","False","Details button disabled as expected");
 				}
        			else
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnViewAddToRelatedFileInfo,"Enabled","False","View/Add Related to File Button is disabled as expected");}
        				
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToPeopleInfo,"Enabled","False","Add to People Button is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnDetailsInfo,"Enabled","False","Details is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.txtSearchTextInfo,"Enabled","True","Search Query is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnSearchAmicusInfo,"Enabled","True","Search Button is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAboutInfo,"Enabled","True","About Button is enabled as expected");
        		}
        	}
        	
        	
        	if(outlook.Outlook.MailFolders.SpamInfo.Exists(3000))
        	{
        		outlook.Outlook.MailFolders.Spam.Click();
        		Report.Success("Spam Folders is opened successfully");
        		outlook.Outlook.tabAmicusTasks.Click();
        		Report.Success("Amicus Tasks Tab is opened successfully");
        		if(outlook.Outlook.AmicusAttorneyTasks1.SelfInfo.Exists(3000))
        		{
        			if(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(3000))
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo,"Enabled","False","Details button disabled as expected");
 				}
        			else
        			{Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnViewAddToRelatedFileInfo,"Enabled","False","View/Add Related to File Button is disabled as expected");}
        				
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAddToPeopleInfo,"Enabled","False","Add to People Button is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnDetailsInfo,"Enabled","False","Details Button is disabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.txtSearchTextInfo,"Enabled","True","Search Query is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnSearchAmicusInfo,"Enabled","True","Search Button is enabled as expected");
        			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnAboutInfo,"Enabled","True","About Button is enabled as expected");
        		}
        	}
        	
        	
        	outlook.Outlook.Self.Close();
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
            CheckFolderButtonValidationInOutlook();
        }
    }
}
