/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/13/2020
 * Time: 7:27 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of emptySearchValidation.
    /// </summary>
    [TestModule("F12AFDBB-CA2A-40B1-BE89-0047B68F26DC", ModuleType.UserCode, 1)]
    public class emptySearchValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public emptySearchValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Files files=Files.Instance;
        Common cmn=new Common();
        
        
        private void EmptyCheckValidate()
        {
        
			string search="";
			
        	files.MainForm.Self.Activate();
        	files.MainForm.btnFiles1.Click();
        	
        	files.MainForm.Actions.Click();
        	Delay.Seconds(1);
        	files.MainForm.CheckConflicts.Click();
        	Delay.Seconds(1);
        
        	files.ConflictCheckForm.SelfInfo.WaitForExists(3000);
        	Validate.Exists(files.ConflictCheckForm.SelfInfo,"Conflict Check Form are displayed successfully");
        	
        	files.ConflictCheckForm.Search1.rdoBasicSearch.Select();
        	
        	files.ConflictCheckForm.PnlBase.txtAdvanceConflictSearch.TextValue=search;
        	Delay.Seconds(1);
        	files.ConflictCheckForm.Toolbar1.CheckNow.Click();
        	
        	Validate.AttributeContains(files.PromptForm.txtMsgInfo,"Text","Not enough information has been supplied to complete a Conflict Check.  Please ensure that a Name has been entered and one or more Fields selected.","Prompt Message shows the correct message for an empty Conflict Search");
        	files.PromptForm.ButtonOK.Click();
        	files.ConflictCheckForm.Toolbar1.Cancel.Click();
        	
         
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
            EmptyCheckValidate();
        }
    }
}
