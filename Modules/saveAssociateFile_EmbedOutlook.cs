/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/14/2020
 * Time: 12:06 PM
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
    /// Description of saveAssociateFile_EmbedOutlook.
    /// </summary>
    [TestModule("37936189-C7BB-411E-B82F-E59C5125AEB4", ModuleType.UserCode, 1)]
    public class saveAssociateFile_EmbedOutlook : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public saveAssociateFile_EmbedOutlook()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        Communications comm=Communications.Instance;
        
        private void saveAssociateFile()
        {
        	
        	string txt="";
        	int indx1,indx2=0;
        	string txt2="";
        	
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);

        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else
        	{
        		comm.MainForm.btnCommunications.Click();
        	}

        	comm.MainForm.txtOutlook.Click();
        	Delay.Seconds(2);
        	
        	txt=comm.MainForm.FirstMail.Element.GetAttributeValueText("Name");
			indx1=txt.IndexOf("Subject ")+8;
			indx2=txt.IndexOf(", Received");
			txt2=txt.Substring(indx1,indx2-indx1);

			Report.Success(String.Format("Mail Subject - {0} opened successfully",txt2));
			if(txt2.Length>91)
			{
				txt2=txt2.Substring(0,15);
			}
			comm.mailSub=txt2;
			comm.MainForm.FirstMail.Click();
			Delay.Seconds(1);
			comm.MainForm.Toolbar1.btnSaveAssociate.Click();
			
			if(comm.FileSelectForm.SelfInfo.Exists(3000))
			{
        			comm.FileSelectForm.listFirstFoundFile.DoubleClick();
        			Report.Success("File Added Successfully for the E-Mail");
        			if(comm.EmailDetailForm.SelfInfo.Exists(3000))
        			{
        				Report.Success("Email Details Form opened successfully");
        				Validate.Exists(comm.EmailDetailForm.PnlBase.txtPeopleNameInfo,String.Format("File Added to the E-mail is - {0}",comm.EmailDetailForm.PnlBase.txtFileName.TextValue));
        				comm.EmailDetailForm.Toolbar1.btnOk.Click();
        			}
        			
        			if(comm.PromptForm.SelfInfo.Exists(3000))
        			{
        				comm.PromptForm.btnNo.Click();
        			}
			}
			
			comm.MainForm.FirstMail.DoubleClick();
			if(comm.EmailDetailForm.SelfInfo.Exists(3000))
			{
				Report.Success("Email Details Form opened successfully");
				Validate.Exists(comm.EmailDetailForm.PnlBase.txtPeopleNameInfo,String.Format("File Added to the E-mail is - {0}",comm.EmailDetailForm.PnlBase.txtFileName.TextValue));
				comm.EmailDetailForm.Toolbar1.btnOk.Click();
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
            saveAssociateFile();
        }
    }
}
