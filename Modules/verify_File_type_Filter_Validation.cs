/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/17/2020
 * Time: 12:06 PM
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
    /// Description of verify_File_type_Filter_Validation.
    /// </summary>
    [TestModule("CD1E1335-D70C-4314-9152-8918A6D15548", ModuleType.UserCode, 1)]
    public class verify_File_type_Filter_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verify_File_type_Filter_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingTE te=BillingTE.Instance;
        
        Common cmn=new Common();
        string[] fileTypes={"File Type","Client","Responsible Lawyer","File","Billing Category"};
        
        private void file_Type_Filter_Validate()
        {
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");

        	te.MainForm.LeftPanel.cbIncludeOnlyFilesWhere.Uncheck();
        	
        	Validate.AttributeEqual(te.MainForm.LeftPanel.cmbbxFileTypeInfo,"Enabled","False","File Type combo box is disabled and is the expected result");
        	Validate.AttributeEqual(te.MainForm.LeftPanel.cmbbxTypeOfLawInfo,"Enabled","False","Type of Law combo box is disabled and is the expected result");
        	
        	
        	
        	te.MainForm.LeftPanel.cbIncludeOnlyFilesWhere.Check();
        	Validate.AttributeEqual(te.MainForm.LeftPanel.cmbbxFileTypeInfo,"Enabled","True","File Type combo box is enabled and is the expected result");
        	Validate.AttributeEqual(te.MainForm.LeftPanel.cmbbxTypeOfLawInfo,"Enabled","True","Type of Law combo box is enabled and is the expected result");
        	
			te.MainForm.LeftPanel.cmbbxFileType.Click();
			for(int i=0;i<fileTypes.Length;i++)
			{
				te.var=fileTypes[i];
				Delay.Milliseconds(500);
				Validate.Exists(te.DropDownForm.TreeItemInfo,String.Format("File Type Dropdown has the value {0} in the list",fileTypes[i]));
			}
			 
			te.MainForm.LeftPanel.cmbbxFileType.Click();
			
			

        	
        	
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
            file_Type_Filter_Validate();
        }
    }
}
