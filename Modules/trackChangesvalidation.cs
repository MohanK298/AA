/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/7/2020
 * Time: 1:44 PM
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
    /// Description of trackChangesvalidation.
    /// </summary>
    [TestModule("4E6F31A9-9A49-4DCD-A73C-0A40081A773D", ModuleType.UserCode, 1)]
    public class trackChangesvalidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trackChangesvalidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

		Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;        
        BillingClient client = BillingClient.Instance;
        
        
        private void TrackChangesValidate()
        {
        	
        	
        	client.MainForm.sideBILLING.Click();
        	
        	frm.MainForm.Self.Activate();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	frm.MainForm.FirmSettingsForm.lnkTrackChanges.Click();
        	
        	if(frm.TimeFirmSettingsForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Track Changes Window is opened successfully");
        		Validate.AttributeEqual(frm.TimeFirmSettingsForm.PnlBase.txtTitleInfo,"Text","Time - Track Changes","Time - Track Changes text is displayed successfully");
        		cmn.VerifyDataExistsInTable(frm.TimeFirmSettingsForm.PnlBase.tblReason,"Incorrect Billing Rate","Track Changes Table");
        		if(cmn.ValidateDatainTable(frm.TimeFirmSettingsForm.PnlBase.tblReason,"Time was entered on wrong date","Track Changes Table"))
        		{
        			Report.Success("Time was entered on wrong date - Reason is present as expected in the Track Changes Table");	
        		}
        		else
        		{
        			if(frm.TimeFirmSettingsForm.PnlBase.btnNewInfo.Exists(3000))
        			{
        				frm.TimeFirmSettingsForm.PnlBase.btnNew.Click();
        				frm.TimeFirmSettingsForm.PnlBase.txtReasonDetail.TextValue="Time was entered on wrong date";
        				frm.TimeFirmSettingsForm.PnlBase.btnApply.Click();
        				
        			}
        			
        		}
        		frm.TimeFirmSettingsForm.PnlBase.cbTrckChanges.Check();
        		frm.TimeFirmSettingsForm.Toolbar1.ButtonOK.Click();
        		
        	}
        	else
        	{
        		Report.Failure("Track Changes Window was not opened successfully");
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
            TrackChangesValidate();
        }
    }
}
