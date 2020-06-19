/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/17/2020
 * Time: 12:54 PM
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
    /// Description of file_type_filter_content_Validation.
    /// </summary>
    [TestModule("95314E49-D88C-413B-B876-C6113C11E5A5", ModuleType.UserCode, 1)]
    public class file_type_filter_content_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public file_type_filter_content_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        BillingTE te=BillingTE.Instance;
        
        Common cmn=new Common();
        string[] fileTypes={"File Type","Client","Responsible Lawyer","File","Billing Category"};
        string [] typesOfLaw={"All Types of Law","Administrative Law","Agency","Civil Litigation","Litigation","Commercial","Corporate","Criminal","Directorship"};
        string[] billingCategory={"All Billing Categories","Billable","Fixed Fee","Contingency","Non-bill.- Client Dev.","Non-bill.- Firm Admin.","Non-bill.- Prof Dev.","Non-bill.- Other","Vacation","Personal"};
        int rowCount=0;
        private void file_Type_Filter_Content_Validate()
        {
       		te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");
        	
        		
        	te.MainForm.LeftPanel.cbIncludeOnlyFilesWhere.Check();
        	te.MainForm.LeftPanel.cmbbxFileType.Click();
        	
        	te.var="File Type";
        	Delay.Milliseconds(500);
        	te.DropDownForm.TreeItem.Click();
        	
        	te.MainForm.LeftPanel.cmbbxTypeOfLaw.Click();
        	
        	for(int i=0;i<typesOfLaw.Length;i++)
			{
				te.var=typesOfLaw[i];
				Delay.Milliseconds(500);
				Validate.Exists(te.DropDownForm.TreeItemInfo,String.Format("Types of Law Dropdown has the value {0} in the list",typesOfLaw[i]));
			}
        	
        	te.MainForm.LeftPanel.cmbbxTypeOfLaw.Click();
        	
        	te.MainForm.LeftPanel.cmbbxFileType.Click();
        	
        	te.var="Client";
        	Delay.Milliseconds(500);
        	te.DropDownForm.TreeItem.Click();
        	
        	te.MainForm.LeftPanel.btnClients.Click();
        	
        	if(te.PeopleSelectForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("People Selector Form is displayed successfully");
        		te.PeopleSelectForm.listFirstValue.DoubleClick();
        		
        		rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        		Report.Success(String.Format("Row Count for the current Client-People Selected is {0}",rowCount.ToString()));
        	}
        	
        	
        	
        	te.MainForm.LeftPanel.cmbbxFileType.Click();
        	
        	te.var="Responsible Lawyer";
        	Delay.Milliseconds(500);
        	te.DropDownForm.TreeItem.Click();
        	
        	te.MainForm.LeftPanel.btnRespLawyer.Click();
        	
        	if(te.PeopleSelectForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("People Selector Form is displayed successfully");
        		te.PeopleSelectForm.listFirstValue.DoubleClick();
        		
        		rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        		Report.Success(String.Format("Row Count for the current Responsible Lawyer Selected is {0}",rowCount.ToString()));
        	}
        	
        	
        	
        	te.MainForm.LeftPanel.cmbbxFileType.Click();
        	
        	te.var="File";
        	Delay.Milliseconds(500);
        	te.DropDownForm.TreeItem.Click();
        	
        	te.MainForm.LeftPanel.btnFile.Click();
        	
        	if(te.FileSelectForm.SelfInfo.Exists(3000))
        	{
        			Report.Success("File Selector Form is displayed successfully");	
        			
        			te.FileSelectForm.btnQuickFind.Click();
        			if(te.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				te.FindFilesForm.txtFind.PressKeys(System.DateTime.Now.ToShortDateString());
        				te.FindFilesForm.btnOK.Click();
        			}
        			te.FileSelectForm.listFirstFound.DoubleClick();
        			rowCount=cmn.GetTableRowCount(te.MainForm.tblTimeEntry,"Time Entry Table");
        			Report.Success(String.Format("Row Count for the current Responsible Lawyer Selected is {0}",rowCount.ToString()));
        	}
        	
        	
        	
        	te.MainForm.LeftPanel.cmbbxFileType.Click();
        	
        	te.var="Billing Category";
        	Delay.Milliseconds(500);
        	te.DropDownForm.TreeItem.Click();
        	
     	
        	te.MainForm.LeftPanel.cmbbxBillingCategory.Click();
        	
        	for(int i=0;i<billingCategory.Length;i++)
			{
				te.var=billingCategory[i];
				Delay.Milliseconds(500);
				Validate.Exists(te.DropDownForm.TreeItemInfo,String.Format("Billing Category Dropdown has the value {0} in the list",billingCategory[i]));
			}
        	
        	te.MainForm.LeftPanel.cmbbxBillingCategory.Click();
     	
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
            file_Type_Filter_Content_Validate();
        }
    }
}
