/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/16/2020
 * Time: 9:13 AM
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
    /// Description of createMultiplePhoneCalls_TimeSaverRightClick.
    /// </summary>
    [TestModule("0AEFC2AC-8CF5-47A2-A514-E294A3522B82", ModuleType.UserCode, 1)]
    public class createMultiplePhoneCalls_TimeSaverRightClick : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public createMultiplePhoneCalls_TimeSaverRightClick()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        Communications phoneCall = Communications.Instance;
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        static string rndData=System.DateTime.Now.ToString();
		string curdata=String.Format("Test Data Added {0}",rndData);
		string[] strData=new string[3];
		string[] strData1=new string[3];
        private void PhoneCallTimeSaver()
        {
        	int initial_count,final_count=0;
        	
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	initial_count=cmn.GetTableRowCount(ts.MainForm.tblTimeSheet,"Time Entry Table");
        	
        	for(int i=0;i<3;i++)
        	{
        		phoneCall.MainForm.Self.Activate();
	        	phoneCall.MainForm.btnCommunications.Click();
	        	Keyboard.Press(System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnAddFile.Click();
	        	phoneCall.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.rdoOutstanding.Select();
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys(curdata+"_"+i);
	        	strData[i]=curdata+"_"+i;
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        	}
        	Array.Reverse(strData);
        	cmn.SelectItemFromTableSingleClick(phoneCall.MainForm.tblCommunications,strData[0],"Phone Call Table");
        	cmn.MultipleSelection(phoneCall.MainForm.tblCommunications,strData);
        	cmn.OpenContextMenuItemFromTable(phoneCall.MainForm.tblCommunications,curdata+"_"+0,"Phone call Table");
        	Delay.Seconds(2);
        	phoneCall.ContextMenu.TimeSaver.Click();
        	Delay.Seconds(3);
        	phoneCall.PromptForm.btnNo.Click();
        	Delay.Seconds(2);
        	phoneCall.PromptForm.btnOK.Click();
        	
        	
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	final_count=cmn.GetTableRowCount(ts.MainForm.tblTimeSheet,"Time Entry Table");
        	
        	if(initial_count+3==final_count)
        	{
        		Report.Success(String.Format("Initial Record Count of Time Entries was {0} and after adding 3 records the count is {1}",initial_count,final_count));
        	}
        	else
        	{
        		Report.Failure(String.Format("Initial Record Count of Time Entries - {0} and final count of records {1} are mismatching after adding 3 records",initial_count,final_count));        		
        	}
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            PhoneCallTimeSaver();
            cmn.ClosePrompt();
        }
    }
}
