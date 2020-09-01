/*
 * Created by Ranorex
 * User: qa
 * Date: 7/22/2020
 * Time: 4:36 PM
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
    /// Description of trust_bank_journal_default_Values_Validation.
    /// </summary>
    [TestModule("1E309293-F3D7-4AC6-8C1F-372E1572D6FF", ModuleType.UserCode, 1)]
    public class trust_bank_journal_default_Values_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_bank_journal_default_Values_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] trustaccount={"All","1 - Trust"};
        private void trust_bank_journal_default_values()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Trust Bank Journal","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Trust Bank Journal Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.cmbbxTrustBankAccountInfo,"Text","All","Trust Bank Account Combobox default values is set to All as expected");
        		
        		
        		report.SQLReportForm.PnlBase.cmbbxTrustBankAccount.Click();
        		Delay.Milliseconds(500);
        		cmn.VerifyListItemsInDropdown(report.ListTrustAccount.Self,trustaccount,"Trust Bank Account Dropdown");
        		report.SQLReportForm.PnlBase.cmbbxTrustBankAccount.Click();
        		Delay.Milliseconds(500);
        		
        		report.SQLReportForm.Toolbar1.btnCancel.Click();
        		
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
            trust_bank_journal_default_values();
        }
    }
}
