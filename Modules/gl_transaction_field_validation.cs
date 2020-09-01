/*
 * Created by Ranorex
 * User: qa
 * Date: 7/23/2020
 * Time: 5:04 PM
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
    /// Description of gl_transaction_field_validation.
    /// </summary>
    [TestModule("3779257C-A8DA-4CBC-A6FD-56BB88DEC0E4", ModuleType.UserCode, 1)]
    public class gl_transaction_field_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public gl_transaction_field_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void gl_Transaction_Report_Fields_Validation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"GL Transaction Report","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("GL Transaction Report Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txt_GL_TransactionStartDateInfo,"Transaction Start Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txt_GL_TransactionEndDateInfo,"Transaction End Date is displayed as expected");
        	
        		Validate.Exists(report.SQLReportForm.PnlBase.txt_GL_PostingStartDateInfo,"Posting Start Date is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txt_GL_PostingEndDateInfo,"Posting End Date is displayed as expected");
        		
        		
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
            gl_Transaction_Report_Fields_Validation();
        }
    }
}
