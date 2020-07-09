/*
 * Created by Ranorex
 * User: qa
 * Date: 6/24/2020
 * Time: 11:46 AM
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
    /// Description of firmSettingsEmailBills.
    /// </summary>
    [TestModule("F6D64C75-D47E-4531-B763-7B11843137BD", ModuleType.UserCode, 1)]
    public class firmSettingsEmailBills : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public firmSettingsEmailBills()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingClient bclient=BillingClient.Instance;
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        
        private void FirmSettingsEmailBills()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.Self.Activate();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	frm.MainForm.FirmSettingsForm.txtBillingEmailingBills.Click();
        	
        	if(frm.BillingFirmSettingsForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Billing Abacus Payment Exchange form is displayed successfully.");
        		Validate.AttributeContains(frm.BillingFirmSettingsForm.PnlBase.cmbbxEmailBehaviourInfo,"Text","Send Bill E-mails to Draft Folder","Email Behaviour Dropdown has the value Send Bill E-mails to Draft Folder");
        		
        		Validate.Exists(frm.BillingFirmSettingsForm.PnlBase.cbAPXRequestTurnedOnForNewFilesInfo," APX Request turned ON for new files is displayed as expected");
        		Validate.Exists(frm.BillingFirmSettingsForm.PnlBase.cbEMailBillsTurnedOnForNewFiles,"Email Bills turned ON for new files is displayed as expected");
        		frm.BillingFirmSettingsForm.PnlBase.cbEMailBillsTurnedOnForNewFiles.Check();
        		frm.BillingFirmSettingsForm.PnlBase.cbAPXRequestTurnedOnForNewFiles.Check();
        		frm.BillingFirmSettingsForm.PnlBase.tabAPXURLFormat.Click();
        		
        		Validate.AttributeContains(frm.BillingFirmSettingsForm.PnlBase.txtBodyEmailInfo,"Text","<<Billed Amount>>","APX Email Template Text Body has the value <<Billed Amount>>");
        		Validate.AttributeContains(frm.BillingFirmSettingsForm.PnlBase.txtBodyEmailInfo,"Text","<<PayNow URL>>","APX Email Template Text Body has the value <<PayNow URL>>");
        		
        		
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
            FirmSettingsEmailBills();
        }
    }
}
