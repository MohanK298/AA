/*
 * Created by Ranorex
 * User: qa
 * Date: 6/23/2020
 * Time: 3:38 PM
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
    /// Description of firmSettingsAPX.
    /// </summary>
    [TestModule("6B5BF349-B34A-46E2-9648-CAC354BD94C3", ModuleType.UserCode, 1)]
    public class firmSettingsAPX : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public firmSettingsAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        

        BillingClient bclient=BillingClient.Instance;
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        
        private void FirmSettingsAPX()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.Self.Activate();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	frm.MainForm.FirmSettingsForm.txtBillingAPX.Click();
        	
        	if(frm.BillingFirmSettingsForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Billing Abacus Payment Exchange form is displayed successfully.");
        		Validate.AttributeContains(frm.BillingFirmSettingsForm.PnlBase.cmbbxOperatingAccountInfo,"Text","1 - General","Operating Account  Dropdown has the value 1 - General Selected");
        		Validate.AttributeContains(frm.BillingFirmSettingsForm.PnlBase.cmbbxTrustAccountInfo,"Text","1 - Trust","Trust Account  Dropdown has the value 1 - Trust Selected");
        		Validate.Exists(frm.BillingFirmSettingsForm.PnlBase.btnAPXChargebacksReportInfo," APX ChargeBack Report Button is displayed as expected");
        		Validate.Exists(frm.BillingFirmSettingsForm.PnlBase.btnAPXTransactionReportInfo," APX Transactions Report Button is displayed as expected");
        		frm.BillingFirmSettingsForm.Toolbar1.btnOK.Click();
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
            FirmSettingsAPX();
        }
    }
}
