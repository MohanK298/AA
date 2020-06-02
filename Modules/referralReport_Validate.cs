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
        
        private void RetrieveFiles()
    	{
    		bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
  		   	file.MainForm.btnFiles.Click();
  		   	file.MainForm.FilesIndexForm.btnQuickFind.Click();
  		   	
  		   	file.
  		   	
        
        
        
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
        }
    }
}
