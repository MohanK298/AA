/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/8/2020
 * Time: 11:49 AM
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
using SmokeTest.Modules;
using SmokeTest.Repositories;
using SmokeTest.Modules.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateAdvancedToolbars.
    /// </summary>
    [TestModule("86B482D4-8709-461D-AB9D-54E0331AA206", ModuleType.UserCode, 1)]
    public class validateAdvancedToolbars : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateAdvancedToolbars()
        {
            // Do not delete - a parameterless constructor is required!
        }
		Files files=Files.Instance;
        
        private void validateAdvancedTbar()
        {
        	files.MainForm.Self.Activate();
        	files.MainForm.btnFiles1.Click();
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	files.MainForm.Advanced.Click();
        	
        	
        	Validate.NotExists(files.MainForm.FilesIndexForm.btnNewFileInfo,"Add New File Button should not be displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.btnQuickFindInfo,"Quick Find Button is displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.btnGenerateDocumentInfo,"Generate Document Button is displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.FileAdvanceMenuItemInfo,"File Menu Item is displayed as expected");
        	files.MainForm.FilesIndexForm.FileAdvanceMenuItem.Click();
        	Delay.Seconds(1);
        	Validate.Exists(files.MainForm.FilesIndexForm.NewFileInfo,"New File Menu Item is displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.TimeEntryInfo,"Time Entry Menu Item is displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.EventInfo,"Event Menu Item is displayed as expected");
        	Validate.Exists(files.MainForm.FilesIndexForm.NoteInfo,"Note Menu Item is displayed as expected");
        	
        	files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	files.MainForm.Standard.Click();
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
            validateAdvancedTbar();
        }
    }
}
