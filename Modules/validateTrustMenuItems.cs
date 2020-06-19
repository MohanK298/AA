/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/11/2020
 * Time: 8:15 PM
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
    /// Description of validateTrustMenuItems.
    /// </summary>
    [TestModule("43464C32-9F61-4680-BB2F-1B00590B6511", ModuleType.UserCode, 1)]
    public class validateTrustMenuItems : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTrustMenuItems()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Trust trst=Trust.Instance;
        
        
        
        private void validateTrustMenu_Items()
        {
        	trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	Validate.AttributeContains(trst.MainForm.Toolbar1.TrustReceiptInfo,"Text","Trust Receipt","Trust Receipt Item is seen under the Menu in Trust Page.");
        	Validate.AttributeContains(trst.MainForm.Toolbar1.TrustCheckInfo,"Text","Trust Check","Trust Check Item is seen under the Menu in Trust Page.");
        	Validate.AttributeContains(trst.MainForm.Toolbar1.FileToFileTransferInfo,"Text","File to File Transfer","File to File Transfer Item is seen under the Menu in Trust Page.");
        	Validate.AttributeContains(trst.MainForm.Toolbar1.TrustTransferToARInfo,"Text","Trust Transfer to AR","Trust Transfer to AR Item is seen under the Menu in Trust Page.");
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	
        	
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
            validateTrustMenu_Items();
        }
    }
}
