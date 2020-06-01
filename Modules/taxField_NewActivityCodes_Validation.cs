/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/27/2020
 * Time: 9:28 AM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of taxField_NewActivityCodes_Validation.
    /// </summary>
    [TestModule("CCF1C2CF-1C4A-4B8D-9A1C-40626141A85F", ModuleType.UserCode, 1)]
    public class taxField_NewActivityCodes_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public taxField_NewActivityCodes_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingClient bclient=BillingClient.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        
        string activityCodeName="Test Activity Codes";
        string activityCode="A001";
         private void activityCodeNew_TaxValidate()
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
        	
        	
        	if(frm.TimeFirmSettingsForm.PnlBase.treeTestActivityCodesInfo.Exists(3000))
        	{
        		frm.TimeFirmSettingsForm.PnlBase.treeTestActivityCodes.Click();
        		frm.TimeFirmSettingsForm.PnlBase.btnRemoveActivityCode.Click();
        	}
        	
	        	frm.TimeFirmSettingsForm.PnlBase.btnNewActivityCode.Click();
	        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityName.PressKeys(activityCodeName);
	        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityCode.PressKeys(activityCode);
	        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax1.Check();
	        	frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax2.Check();
	        	frm.TaskBasedActivityCodeDetailsForm.Toolbar1.btnSave.Click();
        	
        	frm.TimeFirmSettingsForm.PnlBase.treeTestActivityCodes.Click();
        	frm.TimeFirmSettingsForm.PnlBase.btnEditActivityCode.Click();
        	Validate.AttributeContains(frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityNameInfo,"UIAutomationValueValue",activityCodeName,String.Format("Text {0} is present in the Activity Name as expected",activityCodeName));
        	Validate.AttributeContains(frm.TaskBasedActivityCodeDetailsForm.PnlBase.txtActivityCodeInfo,"UIAutomationValueValue",activityCode,String.Format("Text {0} is present in the Activity Code as expected",activityCode));
        	Validate.Exists(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax1,"Sales Tax 1 is present as expected");
        	Validate.Exists(frm.TaskBasedActivityCodeDetailsForm.PnlBase.cbSalesTax2,"Sales Tax 2 is present as expected");
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
            activityCodeNew_TaxValidate();
        }
    }
}
