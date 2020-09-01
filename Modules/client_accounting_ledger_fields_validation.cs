/*
 * Created by Ranorex
 * User: qa
 * Date: 7/27/2020
 * Time: 10:46 AM
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
    /// Description of client_accounting_ledger_fields_validation.
    /// </summary>
    [TestModule("90722993-61BB-402B-81A2-BF45FEE0DFBC", ModuleType.UserCode, 1)]
    public class client_accounting_ledger_fields_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public client_accounting_ledger_fields_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void Client_Accounting_Ledger_Fields_Validation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Client Accounting Ledger","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Client Accounting Ledger Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		Validate.Exists(report.SQLReportForm.PnlBase.txtTransactionStartDateInfo,"From Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtEndDateInfo,"End Date is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.btnResponsibleLawyerInfo,"Responsible Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnClientInfo,"Client button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFilesInfo,"File button is displayed as expected");
    
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"File Type Combobox is displayed as expected");
        		
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
            Client_Accounting_Ledger_Fields_Validation();
        }
    }
}
