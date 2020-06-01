/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/27/2020
 * Time: 10:22 AM
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
    /// Description of taxField_Disabled_NonBillable_ActivityCode.
    /// </summary>
    [TestModule("1F7C7050-608E-4B58-9240-37C5CB2D7253", ModuleType.UserCode, 1)]
    public class taxField_Disabled_NonBillable_ActivityCode : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public taxField_Disabled_NonBillable_ActivityCode()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingClient bclient=BillingClient.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        
        private void activityCodeTaxValidate_NonBillable()
        {
       
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	frm.MainForm.FirmSettingsForm.lnkActivityCodes.Click();
        	
        	
        	frm.TimeFirmSettingsForm.PnlBase.treeAttendDiscovery.Click();
        	
        	frm.TimeFirmSettingsForm.PnlBase.btnEditActivityCode.Click();
        	
        	frm.ActivityCodeDetailsForm.PnlBase.rdoNonBillable.Select();
        	
        	
        	Validate.AttributeContains(frm.ActivityCodeDetailsForm.PnlBase.txtActivityNameInfo,"Text","Attend discovery");
        	Validate.Exists(frm.ActivityCodeDetailsForm.PnlBase.cbSalesTax1,"Sales Tax 1 is present as expected");
        	Validate.Exists(frm.ActivityCodeDetailsForm.PnlBase.cbSalesTax2,"Sales Tax 2 is present as expected");
        	Validate.AttributeEqual(frm.ActivityCodeDetailsForm.PnlBase.cbSalesTax1Info,"Enabled","False","Sales Tax 1 is disabled and is the expected result");
        	Validate.AttributeEqual(frm.ActivityCodeDetailsForm.PnlBase.cbSalesTax2Info,"Enabled","False","Sales Tax 2 is disabled and is the expected result");
        	frm.ActivityCodeDetailsForm.Toolbar1.btnSave.Click();
        	frm.TimeFirmSettingsForm.Toolbar1.ButtonOK.Click();
        	
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
            activityCodeTaxValidate_NonBillable();
        }
    }
}
