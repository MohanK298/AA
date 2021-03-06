﻿/*
 * Created by Ranorex
 * User: qa
 * Date: 7/22/2020
 * Time: 3:23 PM
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
    /// Description of bill_journal_report_save.
    /// </summary>
    [TestModule("0C4A16D0-8D9F-4F01-A8A8-B2D6EBD9BD94", ModuleType.UserCode, 1)]
    public class bill_journal_report_save : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public bill_journal_report_save()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        
        private void bill_journal_reports_Save()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Bill Journal","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Bill Journal Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		report.SQLReportForm.Toolbar1.btnOK.Click();
        		
        		        		
        		if(report.ReportViewerForm.SelfInfo.Exists(10000))
        		{
        			Report.Success("Report Viewer is displayed as expected");
        			Report.Success(String.Format("Firm Name of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtFirmName.GetAttributeValue<String>("Text")));
        			Report.Success(String.Format("Title of Report Viewer Form - {0}",report.ReportViewerForm.Header.txtTodayDate.GetAttributeValue<String>("Text")));
        			
        			report.ReportViewerForm.ToolStrip1.Export.Click();
        			Report.Success("Export Button is clicked on the Toolbar in Report Viewer Form");
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.WordInfo,"Visible","True",String.Format("Word Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.ExcelInfo,"Visible","True",String.Format("Excel Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.PowerPointInfo,"Visible","True",String.Format("Powerpoint Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.PDFInfo,"Visible","True",String.Format("PDF Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.TIFFFileInfo,"Visible","True",String.Format("TIFF File Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.MHTMLWebArchiveInfo,"Visible","True",String.Format("MHTML Web Archive Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.CSVCommaDelimitedInfo,"Visible","True",String.Format("CSV Comma limited Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.XMLFileWithReportDataInfo,"Visible","True",String.Format("XML File with Report Data Menu Item is listed under Export Dropdown"));
        			Validate.AttributeContains(report.ReportViewerForm.ToolStrip1.DataFeedInfo,"Visible","True",String.Format("Data Feed Menu Item is listed under Export Dropdown"));
        			
        			report.ReportViewerForm.ToolStrip1.Word.Click();
        			Report.Success("Word Button is clicked for Export");
        			
        			if(report.ExportDialog.SelfInfo.Exists(2000))
        			{
        				Report.Success("Export Dialog is seen");
        			}
        			
        			if(report.SaveAs.SelfInfo.Exists(10000))
        			{
        				Report.Success("Save as dialog is seen");
        				Report.Success(String.Format("Document name to be saved is - {0}",report.SaveAs.txtFileNamewithPath.GetAttributeValue<String>("Text")));
        				report.SaveAs.btnSave.Click();
        				
        				if(report.ConfirmSaveAs.SelfInfo.Exists(10000))
        				{
        					Report.Success(String.Format("{0} is seen",report.ConfirmSaveAs.ConfirmSaveAs.txtMsg.GetAttributeValue<String>("Text")));
        					report.ConfirmSaveAs.ConfirmSaveAs.btnYes.Click();
        				}
        				Report.Success("Document is saved successfully.");
        				
        			}
        			
        			report.ReportViewerForm.Self.Close();
        			Report.Success("Report Viewer is closed successfully.");
        			
        			
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
            bill_journal_reports_Save();
        }
    }
}
