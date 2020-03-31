﻿/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/27/2020
 * Time: 2:41 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of VerifyAddtoFile_Outlook_AddIn.
    /// </summary>
    [TestModule("400B6CB5-71FC-4154-98E5-61398F7C09AB", ModuleType.UserCode, 1)]
    public class VerifyAddtoFile_Outlook_AddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyAddtoFile_Outlook_AddIn()
        {
            // Do not delete - a parameterless constructor is required!
        }
		string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Communications comm=Communications.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        
           
        private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(10000);
        	
        }
        
        
        private void AddtoFile_Outlook()
        {
        	string txt="";
        	int indx1,indx2=0;
        	string txt2="";
        	OpenApp();
        	if(outlook.Outlook.tabAmicusTasksInfo.Exists(3000))
        	{
        		Report.Success("Amicus Tasks Tab is opened successfully");
        		outlook.Outlook.tabAmicusTasks.Click();
        	}
        	txt=outlook.Outlook.FirstMail.Element.GetAttributeValueText("Name");
			indx1=txt.IndexOf("Subject ")+8;
			indx2=txt.IndexOf(", Received");
			txt2=txt.Substring(indx1,indx2-indx1);

			Report.Success(String.Format("Mail Subject - {0} opened successfully",txt2));
			outlook.mailSub=txt2;
        	outlook.Outlook.FirstMail.DoubleClick();
        	outlook.DetailedView.tabAmicusTasks.Click();
        	if(outlook.DetailedView.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(3000))
        	{
        		Report.Success("Add to File Button is clicked successfully");
        		outlook.DetailedView.AmicusAttorneyTasks1.btnAddToFile.Click();
        		if(comm.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			comm.FileSelectForm.listFirstFoundFile.DoubleClick();
        			Report.Success("File Added Successfully for the E-Mail");
        			if(comm.EmailDetailForm.SelfInfo.Exists(3000))
        			{
        				Report.Success("Email Details Form opened successfully");
        			}
        			comm.EmailDetailForm.Toolbar1.btnOk.Click();
        			if(comm.PromptForm.SelfInfo.Exists(3000))
        			{
        				comm.PromptForm.btnNo.Click();
        			}
        			outlook.DetailedView.Self.Close();
        			Report.Success("Detailed Email is closed successfully");
        			
        		}
        		
        	}
        	
        	else if(outlook.DetailedView.AmicusAttorneyTasks1.btnViewAddToRelatedFileInfo.Exists(3000))
        	{
        		Report.Success("Mail is already added to File and View/Add to Related File Button is clicked successfully");
        		outlook.DetailedView.AmicusAttorneyTasks1.btnDetails.Click();
        		if(comm.EmailDetailForm.SelfInfo.Exists(3000))
    			{
    				Report.Success("Email Details Form opened successfully");
    			}
    			comm.EmailDetailForm.Toolbar1.btnOk.Click();
    			if(comm.PromptForm.SelfInfo.Exists(3000))
    			{
    				comm.PromptForm.btnNo.Click();
    			}
    			outlook.DetailedView.Self.Close();
    			Report.Success("Detailed Email is closed successfully");
        		
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
            AddtoFile_Outlook();
        }
    }
}