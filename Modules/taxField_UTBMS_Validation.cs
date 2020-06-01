/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/26/2020
 * Time: 2:34 PM
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
    /// Description of taxField_UTBMS_Validation.
    /// </summary>
    [TestModule("5F814254-880F-4E73-8669-65EC82E3EAC2", ModuleType.UserCode, 1)]
    public class taxField_UTBMS_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public taxField_UTBMS_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingClient bclient=BillingClient.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        
         private void activityCodeUTBMS_TaxValidate()
        {
       
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	frm.var="Task based Billing Codes";
        	frm.MainForm.FirmSettingsForm.lnkActivityCodes.Click();
        	frm.TimeFirmSettingsForm.PnlBase.cmbxActivityCodes.Click();
        	frm.DropDownForm.treeItem.Click();
        	
        	frm.TimeFirmSettingsForm.PnlBase.rdoActivityCode.Select();
        	
        	frm.TimeFirmSettingsForm.PnlBase.treeA101PlanAndPrepareFor.Click();
        	
        	frm.TimeFirmSettingsForm.PnlBase.btnEditActivityCode.Click();
        	
        	Validate.AttributeContains(frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityNameInfo,"UIAutomationValueValue","A101 Plan and Prepare for");
        	Validate.AttributeContains(frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityCodeInfo,"UIAutomationValueValue","A101");
        	Validate.Exists(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax1,"Sales Tax 1 is present as expected");
        	Validate.Exists(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax2,"Sales Tax 2 is present as expected");
        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax1.Check();
        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax2.Check();
        	Validate.AttributeEqual(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax1Info,"Checked","True","Sales Tax 1 checkbox is checked.");
        	Validate.AttributeEqual(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax2Info,"Checked","True","Sales Tax 2 checkbox is checked.");
        	frm.TaskBasedActivityCodeDetailsForm.Toolbar1.btnSave.Click();
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
            activityCodeUTBMS_TaxValidate();
        }
    }
}
