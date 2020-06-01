/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/7/2020
 * Time: 3:02 PM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of setupAccountingSystem_add2ActivityCodes.
    /// </summary>
    [TestModule("9D8BD697-3506-4ED2-A5B7-B1628682B05D", ModuleType.UserCode, 1)]
    public class setupAccountingSystem_add2ActivityCodes : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public setupAccountingSystem_add2ActivityCodes()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Common cmn=new Common();
        FirmSettings firm=FirmSettings.Instance;
        Repositories.Premium.Preferences pf=Repositories.Premium.Preferences.Instance;
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void SetupAccountingSystem_Verify()
        {
        	firm.MainForm.Self.Activate();
        	firm.MainForm.Office.Click();
        	Delay.Seconds(2);
			firm.MainForm.View.Click();
			Delay.Seconds(2);
			firm.MainForm.FirmSettings1.Click();
			Delay.Seconds(1);
			firm.MainForm.FirmSettingsForm.lnkAccounting.Click();
			if(firm.TimeFirmSettingsForm.cmbbxAccountingSystemInfo.Exists(3000))
			{
				Validate.AttributeEqual(firm.TimeFirmSettingsForm.cmbbxAccountingSystemInfo,"Text","Manual Entry",String.Format("Accounting System is set to {0} ",firm.TimeFirmSettingsForm.cmbbxAccountingSystem.Text));
			}
			firm.TimeFirmSettingsForm.Toolbar1.Cancel.Click();
			
        }
        
        private void Add2ActivityCodes()
        {
        	int rcount=0;
        	string activityname="";
        	pf.MainForm.Self.Activate();
        	pf.MainForm.OfficeModule.Click();
			pf.MainForm.View.Click();
			Delay.Seconds(2);
			pf.MainForm.Preferences1.Click();
			Delay.Seconds(1);
			pf.MainForm.PreferencesForm.ActivityCodes.Click();
			if(pf.GeneralPreferencesForm.SelfInfo.Exists(3000))
			{
			 	pf.GeneralPreferencesForm.btnActivityCodes.Click();
			}
			if(pf.ActivityCodeSelectForm.SelfInfo.Exists(3000))
			{
				rcount=cmn.GetTableRowCount(pf.ActivityCodeSelectForm.PnlBase.tbActivityCodeSelected,"Activity Codes Selected");
				pf.ActivityCodeSelectForm.PnlBase.cbSelectDoubleClick.Uncheck();
				if(rcount==2)
			    {
					
					Report.Success("Activity Codes has already been added to the list");
			    }
				if(rcount==0)
				{
						activityname="Attend discovery";
						pf.activityname=activityname;
						pf.ActivityCodeSelectForm.PnlBase.treeitemActivity.DoubleClick();
						activityname="Attend trial";
						pf.activityname=activityname;
						pf.ActivityCodeSelectForm.PnlBase.treeitemActivity.DoubleClick();
						
						activityname="Brief witness";
						pf.activityname=activityname;
						pf.ActivityCodeSelectForm.PnlBase.treeitemActivity.DoubleClick();
						
						
						Report.Success("3 Activity Codes has been added to the list");
						
				}
				if(rcount==1)
				{
					activityname="Attend trial";
					pf.activityname=activityname;
					if(pf.ActivityCodeSelectForm.PnlBase.treeitemActivityInfo.Exists(2000))
					{
					   	pf.ActivityCodeSelectForm.PnlBase.treeitemActivity.DoubleClick();
					}
					else
					{
					activityname="Brief witness";
					pf.activityname=activityname;					   	
					}
					Report.Success("1 Activity Codes has been added to the list");
					
				}
				pf.ActivityCodeSelectForm.PnlBase.cbSelectDoubleClick.Check();
				pf.ActivityCodeSelectForm.Toolbar1.btnOK.Click();
					
				}
			
			pf.GeneralPreferencesForm.ButtonOK.Click();
			        	
        }
        
        

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            SetupAccountingSystem_Verify();
            Add2ActivityCodes();
            cmn.ClosePrompt();
        }
    }
}
