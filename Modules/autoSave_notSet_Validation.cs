/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/21/2020
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
using SmokeTest.Modules;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of autoSave_notSet_Validation.
    /// </summary>
    [TestModule("DBF35E5B-83B9-4A00-A992-256C7CA651EA", ModuleType.UserCode, 1)]
    public class autoSave_notSet_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public autoSave_notSet_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Communications comm=Communications.Instance;
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
        
		
		private void AutoSave_notSet_Validate()
        {
        	
        	
        	string[] toMail={"qaabacusnext@outlook.com"};
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
        	Delay.Seconds(15);
        	cmn.SelectItemFromTableSingleClick(comm.MainForm.tblCommunications,data,"Email Communications Table");
        	if(comm.MainForm.imgSavedMailInfo.Exists(10000))
        	{
        		Report.Success("Mail is not saved and is the expected Result");
        	}
        	else
        	{
        		Report.Failure("Mail is saved and is not the expected Result");
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
            AutoSave_notSet_Validate();
        }
    }
}
