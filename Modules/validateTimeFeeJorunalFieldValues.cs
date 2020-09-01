/*
 * Created by Ranorex
 * User: qa
 * Date: 7/16/2020
 * Time: 6:39 PM
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
    /// Description of validateTimeFeeJorunalFieldValues.
    /// </summary>
    [TestModule("BB95D259-58A4-4D45-A968-489FB7F261D1", ModuleType.UserCode, 1)]
    public class validateTimeFeeJorunalFieldValues : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTimeFeeJorunalFieldValues()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void timeFeeJorunalFieldsValidation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Time and Fee Journal","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Time and Fees Jorunal Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.txtFromDateInfo,"UIAutomationValueValue","","From Date Value is empty as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.txtEndDateInfo,"UIAutomationValueValue","","End Date Value is empty as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.cmbbxBillingCategoryInfo,"Text","All","Billing Category Combobox default values is set to All as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"Text","All","File Type Combobox default values is set to All as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.cmbbxBillingRateInfo,"Text","All","Billing Rate Combobox default values is set to All as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.cmbbxBillingBehaviourInfo,"Text","All","Billing Behaviour Combobox default values is set to All as expected");
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
            timeFeeJorunalFieldsValidation();
        }
    }
}
