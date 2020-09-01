/*
 * Created by Ranorex
 * User: qa
 * Date: 7/17/2020
 * Time: 12:02 PM
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
    /// Description of time_fee_journal_report_Validation.
    /// </summary>
    [TestModule("8A75537E-BEC9-4A0D-972C-9D0BCE513228", ModuleType.UserCode, 1)]
    public class time_fee_journal_report_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public time_fee_journal_report_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] columnNames={"Client","Client Matter ID","Resp Lyr","File Typ","File","Date","Audit ID","Tmk","Type","Code","Description","Hrs","Rate","Value","Inv","Billing Behavior"};
        string[] summaryDetails={"Summary by Responsible Lawyer","Summary by Timekeeper","Summary by Activity Code","Summary by Task Code","Summary by File Type","Summary by Billing Category","Summary by Billing Behaviour"};
        private void timeFeeJorunalReportViewer()
        {
        	string todayDate="";
			todayDate=System.DateTime.Now.ToString("dd MMMM, yyyy");
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
        		report.SQLReportForm.Toolbar1.btnOK.Click();
        		
        		if(report.ReportViewerForm.SelfInfo.Exists(10000))
        		{
        			Report.Success("Report Viewer is displayed as expected");
        			Report.Success(String.Format("Firm Name of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtFirmName.GetAttributeValue<String>("Text")));
        			Report.Success(String.Format("Title of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtReportName.GetAttributeValue<String>("Text")));
        			Validate.AttributeContains(report.ReportViewerForm.Header.txtTodayDateInfo,"Text",todayDate,String.Format("Today's Date in the Repot Viewer Form is {0}.",todayDate));
        			
        			for(int i=0;i<columnNames.Length;i++)
        			{
        				Delay.Milliseconds(300);
        				report.txtmsg=columnNames[i];
        				Delay.Milliseconds(300);
        				Validate.Exists(report.ReportViewerForm.txtValueInfo,String.Format("{0} column is present in the Report Viewer",columnNames[i]));
        			}
        			
        			report.ReportViewerForm.ToolStrip1.btnLastPage.Click();
        			Report.Success("Moved to Last page of the Report Form");
        			Delay.Milliseconds(300);
        			
        			for(int i=0;i<summaryDetails.Length;i++)
        			{
        				Delay.Milliseconds(300);
        				report.txtmsg=summaryDetails[i];
        				Delay.Milliseconds(300);
        				Validate.Exists(report.ReportViewerForm.txtValueInfo,String.Format("{0} Value is present in the Report Viewer",summaryDetails[i]));
        			}
        			
        			report.ReportViewerForm.ToolStrip1.btnFirstPage.Click();
        			Report.Success("Moved to First page of the Report Form");
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.txtCurrentPageInfo,"Text","1",String.Format("Current Page of the report should be - {0}.",report.ReportViewerForm.ToolStrip1.txtCurrentPage.GetAttributeValue<String>("Text")));
        			
        			report.ReportViewerForm.Self.Close();
        			
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
            timeFeeJorunalReportViewer();
        }
    }
}
