/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 12:47 PM
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
    /// Description of verifyModule_list.
    /// </summary>
    [TestModule("876E8EC3-EE87-40EC-B80C-91034C819DDA", ModuleType.UserCode, 1)]
    public class verifyModule_list : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyModule_list()
        {
            // Do not delete - a parameterless constructor is required!
        }
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        string txtProfile="Billing AdminA";
        string txtDescriptionBA="Billing AdminA Profile";
        string txtDescription="This profile allows access to most of the Billing side modules: Files; Clients; Time, Fees & Expenses; and Reports. They can enter expense entries, create bills, receive client payments, and perform Trust transactions, etc. for the Files and Clients they may access. (The Attorney Security Profile determines access to Firm Files and Firm Contacts, not just those to which they are explicitly assigned.)";
        private void ValidateModuleFilters()
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
        	Report.Success("Billing User Profile is selected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.OfficeInfo,"Office Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.ViewInfo,"View Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.ActionInfo,"Action Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.TrustInfo,"Trust Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.TimeFeesExpensesInfo,"Time Fees and Expenses Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.Billing,"Billing Link is seen as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.txtDescriptionInfo,"Text",txtDescription,"Description Textbox is seen as expected for Billing Profile Selected");
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue=txtProfile;
        	Delay.Milliseconds(300);
        	sec.DropDownForm.txtdpdwnitem.Click();
        	Delay.Milliseconds(300);
        	Report.Success("Billing AdminA Profile is selected");

        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.OfficeInfo,"Office Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.ViewInfo,"View Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.ActionInfo,"Action Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.TrustInfo,"Trust Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.TimeFeesExpensesInfo,"Time Fees and Expenses Link is seen as expected");
        	Validate.Exists(sec.MainForm.SecurityProfileManagementForm.Billing,"Billing Link is seen as expected");
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.txtDescriptionInfo,"Text",txtDescriptionBA,"Description Textbox is seen as expected for Billing Profile Selected");
        	
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
            ValidateModuleFilters();
        }
    }
}
