﻿/*
 * Created by Ranorex
 * User: qa
 * Date: 7/22/2020
 * Time: 5:48 PM
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
    /// Description of trust_bank_journal_report_validation.
    /// </summary>
    [TestModule("062CEB14-DD8E-4316-95D1-79D0FCA0D7B6", ModuleType.UserCode, 1)]
    public class trust_bank_journal_report_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_bank_journal_report_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] columnNames={"Date","Audit #","To/From","Description","Acct #","Check/ Receipt #","Daily Total","Client/Matter ID","Resp. Lwyr.","File Type","File","Receipt","Check"};
        string[] summaryDetails={"Firm Total Summary","Bank Account","Receipt","Check","Balance","Responsible Lawyer Totals","Lawyer","File Summary","Client Matter - File Name","Account"};
        
        private void trust_Bank_Journal_report_Validation()
        {
        	string todayDate="";
        	string enabled="";
			todayDate=System.DateTime.Now.ToString("dd MMMM, yyyy");
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
        		report.SQLReportForm.Toolbar1.btnOK.Click();
        		
        		        		
        		if(report.ReportViewerForm.SelfInfo.Exists(10000))
        		{
        			Report.Success("Report Viewer is displayed as expected");
        			Report.Success(String.Format("Firm Name of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtFirmName.GetAttributeValue<String>("Text")));
        			Report.Success(String.Format("Title of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtTodayDate.GetAttributeValue<String>("Text")));
        			Validate.AttributeContains(report.ReportViewerForm.Header.txtReportNameInfo,"Text",todayDate,String.Format("Today's Date in the Repot Viewer Form is {0}.",todayDate));
        			
        			for(int i=0;i<columnNames.Length;i++)
        			{
        				Delay.Milliseconds(300);
        				report.txtmsg=columnNames[i];
        				Delay.Milliseconds(300);
        				Validate.Exists(report.ReportViewerForm.txtValueInfo,String.Format("{0} column is present in the Report Viewer",columnNames[i]));
        			}
        			enabled=report.ReportViewerForm.ToolStrip1.btnLastPage.GetAttributeValue<String>("Enabled");
        			if(enabled=="True")
        			{
        				report.ReportViewerForm.ToolStrip1.btnLastPage.Click();
        				Report.Success("Moved to Last page of the Report Form");
        			}
        			else
        			{
        				Report.Success("Already in the Last page of the Report Form");
        			}
        			Delay.Milliseconds(300);
        			
        			for(int i=0;i<summaryDetails.Length;i++)
        			{
        				Delay.Milliseconds(300);
        				report.txtmsg=summaryDetails[i];
        				Delay.Milliseconds(300);
        				Validate.Exists(report.ReportViewerForm.txtValueInfo,String.Format("{0} Value is present in the Report Viewer",summaryDetails[i]));
        			}
        			
        			enabled=report.ReportViewerForm.ToolStrip1.btnFirstPage.GetAttributeValue<String>("Enabled");
        			if(enabled=="True")
        			{
        				report.ReportViewerForm.ToolStrip1.btnFirstPage.Click();
        				Report.Success("Moved to First page of the Report Form");
        			}
        			else
        			{
        				Report.Success("Already in the First page of the Report Form");
        			}
        			
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.txtCurrentPageInfo,"Text","1",String.Format("Current Page of the report should be - {0}.",report.ReportViewerForm.ToolStrip1.txtCurrentPage.GetAttributeValue<String>("Text")));
        			
        			report.ReportViewerForm.Self.Close();
        			Report.Success("Report Closed Successfully");
        			
        		}
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
            trust_Bank_Journal_report_Validation();
        }
    }
}
