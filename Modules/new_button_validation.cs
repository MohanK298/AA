/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 10:36 AM
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
    /// Description of new_button_validation.
    /// </summary>
    [TestModule("3A00705E-B591-44C6-910D-A4E4E9D522FF", ModuleType.UserCode, 1)]
    public class new_button_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public new_button_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        private void NewButton_Validation()
        {
        	sec.MainForm.Self.Activate();
        	sec.MainForm.PLeft.txtBILLING.Click();
        	sec.MainForm.PLeft.btnOffice.Click();
        	sec.MainForm.PLeft.lnkSecurityProfiles.Click();
        	
        	Delay.Seconds(1);
        	
        	sec.MainForm.SecurityProfileManagementForm.rdoBillingProfile.Select();
        	Report.Success("Billing Profile Radio button is selected");
        	
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue="Billing User";
        	Delay.Milliseconds(300);
        	sec.DropDownForm.txtdpdwnitem.Click();
        	Delay.Milliseconds(300);
        	sec.MainForm.SecurityProfileManagementForm.btnNew.Click();
        	Report.Success("New Button is clicked");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnNewInfo,"Enabled","False","New Button is greyed out/disabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnCopyInfo,"Enabled","False","Copy Button is greyed out/disabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnDeleteInfo,"Enabled","False","Delete Button is greyed out/disabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnSaveInfo,"Enabled","True","Save Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnCancelInfo,"Enabled","True","Cancel Button exists and enabled as expected");
        	
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.txtProfileEditInfo,"HasFocus","True","Profile Edit Textbox is currently Focused as expected.");
        	
        	sec.MainForm.SecurityProfileManagementForm.btnCancel.Click();
        	Report.Success("Cancel Button is clicked");
        	
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnNewInfo,"Enabled","True","New Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnCopyInfo,"Enabled","True","Copy Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnDeleteInfo,"Enabled","True","Delete Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnEditInfo,"Enabled","True","Edit Button exists and enabled as expected");
        	
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cmbbxProfileInfo,"Text","Billing User","Billing User Default value is seen as expected in Profile Dropdown");
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
            NewButton_Validation();
        }
    }
}
