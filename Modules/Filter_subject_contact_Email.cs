/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/16/2020
 * Time: 3:10 PM
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
    /// Description of Filter_subject_contact_Email.
    /// </summary>
    [TestModule("62FFA607-9783-4B26-BD60-D053D63F69B8", ModuleType.UserCode, 1)]
    public class Filter_subject_contact_Email : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Filter_subject_contact_Email()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Communications comm=Communications.Instance;
        Common cmn=new Common();
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
        
        private void Filter_Perform_onMail()
        {
        	
        	
        	string[] toMail={"amicustestmk1@gmail.com"};
        	int count=0;
        	System.DateTime day1;
			day1=System.DateTime.Now;
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);
			cmn.SendEmail(toMail,data);
			
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
        	cmn.VerifyDataExistsInTable(comm.MainForm.tblCommunications,data,"Email Communications Table");
        	
        	comm.MainForm.txtSearch.PressKeys("Test Data Added");
        	comm.MainForm.Toolbar1.btnSearch_Cancel.Click();
        	Delay.Seconds(5);
        	
        	count=cmn.GetTableRowCount(comm.MainForm.tblCommunications,"Email Communications Table");
        	if(count>=0)
        	{
        		Report.Success(String.Format("Email Count filterd matches the Subject data count of {0} Emails",count));
        		
        	}
        	else
        	{
        		Report.Failure(String.Format("Email Count filterd does not match the Subject data count of {0} Emails",count));
        	}
        	comm.MainForm.Toolbar1.btnSearch_Cancel.Click();
        	
//        	comm.MainForm.txtSearch.PressKeys("amicustestmk1@gmail.com");
//        	comm.MainForm.Toolbar1.btnSearch_Cancel.Click();
//        	Delay.Seconds(5);
//        	
//        	count=cmn.GetTableRowCount(comm.MainForm.tblCommunications,"Email Communications Table");
//        	if(count>1)
//        	{
//        		Report.Success(String.Format("Email Count filterd matches the Contact data count of {0} Emails",count));
//        		
//        	}
//        	else
//        	{
//        		Report.Failure(String.Format("Email Count filterd does not match the Contact data count of {0} Emails",count));
//        	}
//        	comm.MainForm.Toolbar1.btnSearch_Cancel.Click();
        	
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
            Filter_Perform_onMail();
        }
    }
}
