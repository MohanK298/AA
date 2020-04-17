/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/17/2020
 * Time: 1:49 PM
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
using SmokeTest.Modules;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of EmailWithMultipleAttachments.
    /// </summary>
    [TestModule("10923A70-A419-4622-A1F7-1BFFE70091D8", ModuleType.UserCode, 1)]
    public class EmailWithMultipleAttachments : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EmailWithMultipleAttachments()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Communications comm=Communications.Instance;
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
        
		
		
		private void SaveAssociate_MultipleAttach_onMail()
        {
        	
        	
        	string toMail="amicustestmk1@gmail.com";
        	int attach=3;
        	string savedattach="";
        	System.DateTime day1;
			day1=System.DateTime.Now;
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);
			cmn.SendEmailWithAttachments(toMail,data,attach);
			
        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else
        	{
        		comm.MainForm.btnCommunications.Click();
        	}
        	
        	comm.MainForm.txtOutstanding.Click();
        	comm.MainForm.PnlRestrictions.CheckBoxCalls.Uncheck();
        	comm.MainForm.PnlRestrictions.CheckBoxMessages.Uncheck();
        	Delay.Seconds(2);
        	comm.MainForm.btnSyncNow.Click();
        	Delay.Seconds(5);
        	
        	
        	cmn.SelectItemFromTableSingleClick(comm.MainForm.tblCommunications,data,"Email Communications Table");
        	
        	comm.MainForm.Toolbar1.btnSaveAssociate.Click();
        	
        	comm.FileSelectForm.listFirstFoundFile.DoubleClick();
        	
        	if(comm.BrowseForFolder.SelfInfo.Exists(3000))
        	{
        		comm.BrowseForFolder.SavedLocation.DoubleClick();
        		comm.BrowseForFolder.btnOk.Click();
        	}
        	
        	if(comm.PromptForm.SelfInfo.Exists(3000))
        	{
        		comm.PromptForm.btnYes.Click();
        		Report.Success("Email Detail Prompt shown successfully");
        	}
        	savedattach=comm.EmailDetailForm.PnlBase.btnSavedDocuments.GetAttributeValue<String>("Text");
        	
        	if(savedattach.Contains(attach.ToString()))
    	   {
        	   	Report.Success(String.Format("{0} number of attachments saved and sent in mail are the same",attach.ToString()));
    	   }
    	   else
    	   {
    	   		Report.Failure(String.Format("{0} number of attachments saved and sent in mail are not the same",attach.ToString()));
    	   	
    	   }
    	   comm.EmailDetailForm.Toolbar1.btnOk.Click();
	    	if(comm.PromptForm.SelfInfo.Exists(3000))
	    	{
	    		comm.PromptForm.btnOK.Click();
	    		
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
            SaveAssociate_MultipleAttach_onMail();
        }
    }
}
