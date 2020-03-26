/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/26/2020
 * Time: 12:44 PM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateMergeTemplates.
    /// </summary>
    [TestModule("FAF66008-8BDE-4BB0-9A2B-FCCD49D4E972", ModuleType.UserCode, 1)]
    public class validateMergeTemplates : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateMergeTemplates()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        MergeTemplates mtemp=MergeTemplates.Instance; 
		Common cmn=new Common();
        
        private void ValidateMergeTemplates()
        {
        	int count=0;
        	mtemp.MainForm.MergeTemplates.Click();
        	
        	if(mtemp.DocumentTemplateManagementForm.SelfInfo.Exists(3000))
        	{
        		mtemp.DocumentTemplateManagementForm.PnlBase.lnkStandardTemplates.Click();
        		Delay.Seconds(2);
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnNewGroupInfo,"Text","New Group","New Group button is displayed successfully");
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnNewTemplateInfo,"Text","New Template","New Template button is displayed successfully");
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnEditInfo,"Text","Edit","Edit button is displayed successfully");
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnDeleteInfo,"Text","Delete","Delete button is displayed successfully");
        		
        		Validate.Exists(mtemp.DocumentTemplateManagementForm.PnlBase.treeOutline,"Standard Templates are displayed successfully");
        		
        		mtemp.DocumentTemplateManagementForm.PnlBase.lnkHotDocsAdvanceTemplates.Click();
        		Delay.Seconds(2);
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnLaunchHotDocsAuthorInfo,"Text","Launch HotDocs Author","Launch HotDocs Author button is displayed successfully");
        		Validate.AttributeEqual(mtemp.DocumentTemplateManagementForm.PnlBase.btnEditHotDocsTemplateInfo,"Text","Edit HotDocs Template","Edit HotDocs Template button is displayed successfully");
        		count=cmn.GetTableRowCount(mtemp.DocumentTemplateManagementForm.PnlBase.tblHotDocsAdvanceTemplates,"Merge Templates");
        		Report.Success(String.Format("The number of templates present for HotDocs Advance Templates are {0}",count));
        		
        		mtemp.DocumentTemplateManagementForm.Toolbar1.btnClose.Click();
        		
        		
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
            ValidateMergeTemplates();
        }
    }
}
