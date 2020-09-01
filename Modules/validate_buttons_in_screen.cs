/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 10:05 AM
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
    /// Description of validate_buttons_in_screen.
    /// </summary>
    [TestModule("68ADD10B-5163-4823-A99A-00F7497A3A1C", ModuleType.UserCode, 1)]
    public class validate_buttons_in_screen : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_buttons_in_screen()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        string txtDescription="This profile allows access to most of the Billing side modules: Files; Clients; Time, Fees & Expenses; and Reports. They can enter expense entries, create bills, receive client payments, and perform Trust transactions, etc. for the Files and Clients they may access. (The Attorney Security Profile determines access to Firm Files and Firm Contacts, not just those to which they are explicitly assigned.)";
        private void ValidateButtonsInSecurityProfile()
        {
        	sec.MainForm.Self.Activate();
        	sec.MainForm.PLeft.txtBILLING.Click();
        	sec.MainForm.PLeft.btnOffice.Click();
        	sec.MainForm.PLeft.lnkSecurityProfiles.Click();
        	
        	Delay.Seconds(1);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.rdoAttorneyProfileInfo,"Enabled","True","Attroney Profile Radio Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.rdoBillingProfileInfo,"Enabled","True","Billing Profile Radio Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnNewInfo,"Enabled","True","New Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnCopyInfo,"Enabled","True","Copy Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnDeleteInfo,"Enabled","True","Delete Button exists and enabled as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.btnEditInfo,"Enabled","True","Edit Button exists and enabled as expected");
        	
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cmbbxProfileInfo,"Text","Billing User","Billing User Default value is seen as expected in Profile Dropdown");
        	
        	sec.MainForm.SecurityProfileManagementForm.rdoBillingProfile.Select();
        	Report.Success("Billing Profile Radio button is selected");
        	
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue="Billing User";
        	Delay.Milliseconds(300);
        	sec.DropDownForm.txtdpdwnitem.Click();
        	
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.txtDescriptionInfo,"Text",txtDescription,"Description Textbox is seen as expected for Billing Profile Selected");
        	
        	
        	
        	
        	
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
            ValidateButtonsInSecurityProfile();
        }
    }
}
