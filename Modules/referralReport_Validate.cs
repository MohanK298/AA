/*
 * Created by Ranorex
 * User: qa
 * Date: 6/2/2020
 * Time: 12:49 PM
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
    /// Description of referralReport_Validate.
    /// </summary>
    [TestModule("C93A3CFC-E378-46FB-A3B7-D2717FD312C5", ModuleType.UserCode, 1)]
    public class referralReport_Validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public referralReport_Validate()
        {
            // Do not delete - a parameterless constructor is required!
        }

        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
    	Common cmn=new Common();
        
    	string fileNames="";
    	string[] files;
        private void RetrieveFiles()
    	{
    		//bclient.MainForm.Self.Activate();
        	//bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.txtAttorney.Click();
		   	file.MainForm.btnFiles.Click();
  		   	
  		   	file.MainForm.FilesIndexForm.btnQuickFind.Click();
  		   	
  		   	file.FindFilesForm.txtFindFile.PressKeys(System.DateTime.Now.ToShortDateString());
  		   	file.FindFilesForm.btnOK.Click();
  		   	Delay.Seconds(3);
  		   	fileNames=cmn.RetrieveCurrentSelectionFromTable(file.MainForm.FilesIndexForm.tblFiles,1,"File Index Table");
  		   	Delay.Seconds(2);
  		   	cmn.SelectItemDropdown(file.MainForm.cmbbxFileStatus,"All","File Status");
  		   	Report.Success(fileNames);
        }
        
        private void ValidateReferralReport()
        {
        	frm.MainForm.Office.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.lnkMenuFirmReports.Click();
        	frm.MainForm.RoundedPanelControl.treeBusinessPlanning.Click();
        	
        	cmn.SelectItemFromTableSingleClick(frm.MainForm.RoundedPanelControl.tblAdvancedReports,"Referral Report","Advanced Reports Table");
			
        	frm.MainForm.RoundedPanelControl.btnRunReport.Click();
        	
        	if(frm.SQLReportForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("SQL Report Form is displayed successfully");
        		frm.SQLReportForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.ToShortDateString());
        		frm.SQLReportForm.PnlBase.txtEndDate.PressKeys(System.DateTime.Now.ToShortDateString());
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.txtStartDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"),"Start Date displayed is Today's Date");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.txtEndDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"),"End Date displayed is Today's Date");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"Text","All","File Type is set as All in the dropdown box");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.cmbbxCameToUsInfo,"Text","All","Came to Us dropdown box is set as All.");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.imgContactSelectorInfo,"Visible","True","Contact Selector is displayed successfully");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.rdoIncludeClosedFilesNoInfo,"Checked","True","Include Closed Files Radio Buton is set as No.");
        		Validate.AttributeContains(frm.SQLReportForm.PnlBase.rdoIncludeSummaryNoInfo,"Checked","True","Summary Radio Buton is set to No.");
        		
        		frm.SQLReportForm.Toolbar1.btnOK.Click();
        		
        	}
        	
        	
        	if(frm.ReportViewerForm.SelfInfo.Exists(5000))
        	{
        		Report.Success("Referral Report Form View is displayed successfully");
        		Validate.AttributeContains(frm.ReportViewerForm.txtHeaderInfo,"Text","Referral Report","Referral Report Header is displayed successfully in the Referral Report Viewer");
        		files=fileNames.Split('~');
        		for(int i=0;i<files.Length;i++)
        		{
        			frm.filedetailsdata=files[i];
        			Delay.Seconds(1);
        			Validate.Exists(frm.ReportViewerForm.txtFileDataInfo,String.Format("File Name {0} is present in the File Details report.",files[i]));
        		}
        		
        		frm.lawyersummarydata="Responsible Lawyer Summary";
        		Validate.Exists(frm.ReportViewerForm.txtReferenceSummaryDataInfo,"Responsible laywer is present in the Referral Report Viewer.");

        		frm.filetypesummarydata="File Type Summary";
        		Validate.Exists(frm.ReportViewerForm.txtReferenceSummaryDataInfo,"File Type Summary	 is present in the Referral Report Viewer.");

        		frm.refsummarydata="Reference Summary";
        		Validate.Exists(frm.ReportViewerForm.txtReferenceSummaryDataInfo,"Reference Summary is present in the Referral Report Viewer.");
        		
        		frm.ReportViewerForm.Self.Close();
        		
        		Report.Success("Referral Report Form View is closed successfully");
        	}
        	  
			
        }
        
        private void referralReportSummary()
        {
        	frm.MainForm.Office.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.lnkMenuFirmReports.Click();
        	frm.MainForm.RoundedPanelControl.treeBusinessPlanning.Click();
        	
        	cmn.SelectItemFromTableSingleClick(frm.MainForm.RoundedPanelControl.tblAdvancedReports,"Referral Report","Advanced Reports Table");
			
        	frm.MainForm.RoundedPanelControl.btnRunReport.Click();
        	
        	if(frm.SQLReportForm.SelfInfo.Exists(3000))
        	{
        		frm.SQLReportForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.ToShortDateString());
        		frm.SQLReportForm.PnlBase.txtEndDate.PressKeys(System.DateTime.Now.ToShortDateString());
        		frm.SQLReportForm.PnlBase.rdoIncludeSummaryYes.Select();
        		frm.SQLReportForm.Toolbar1.btnOK.Click();
        	}
        	
        	if(frm.ReportViewerForm.SelfInfo.Exists(5000))
        	{
        		Report.Success("Referral Report Form View is displayed successfully");
        		Validate.AttributeContains(frm.ReportViewerForm.txtHeaderInfo,"Text","Referral Report","Referral Report Header is displayed successfully in the Referral Report Viewer");
//        		files=fileNames.Split('~');
//        		for(int i=0;i<files.Length;i++)
//        		{
//        			frm.filedetailsdata=files[i];
//        			Validate.NotExists(frm.ReportViewerForm.txtFileDataInfo,String.Format("File Name {0} is not present in the File Details report.",files[i]));
//        		}
        		
        		frm.filedetailsdata="Responsible Lawyer Summary";
        		Validate.Exists(frm.ReportViewerForm.txtFileDataInfo,"Responsible laywer is present in the Referral Report Viewer.");

        		frm.lawyersummarydata="File Type Summary";
        		Validate.Exists(frm.ReportViewerForm.txtresplawyerInfo,"File Type Summary	 is present in the Referral Report Viewer.");

        		frm.filetypesummarydata="Reference Summary";
        		Validate.Exists(frm.ReportViewerForm.txtFileTypeSummaryInfo,"Reference Summary is present in the Referral Report Viewer.");
        		
        		frm.ReportViewerForm.Self.Close();
        		
        		Report.Success("Referral Report Form View is closed successfully");
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
            RetrieveFiles();
            ValidateReferralReport();
            referralReportSummary();
        }
    }
}
