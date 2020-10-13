/*
 * Created by Ranorex
 * User: qa
 * Date: 9/17/2020
 * Time: 12:56 PM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validate_package_documents_menu.
    /// </summary>
    [TestModule("198B56CA-0C91-4018-B1E4-4B4DDC62C4A9", ModuleType.UserCode, 1)]
    public class validate_package_documents_menu : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_package_documents_menu()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        Files file=Files.Instance;
        
        private void Package_Documents_Menu_Exists()
        {
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	if(file.FileDetailForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("File Details form is displayed successfully");
        		
        		file.FileDetailForm.Actions.Click();
        		Report.Success("Action Menu Item is clicked");
        		Validate.Attribute(file.FileDetailForm.PackageDocumentsInfo,"Visible","True","Package Documents Menu is displayed as expected");
        		file.FileDetailForm.Actions.Click();
        		file.FileDetailForm.btnSaveClose.Click();
        		
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
            Package_Documents_Menu_Exists();
        }
    }
}
