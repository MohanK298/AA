/*
 * Created by Ranorex
 * User: kumar
 * Date: 12/19/2019
 * Time: 2:12 PM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of closeExistingPrompts.
    /// </summary>
    [TestModule("FDD2E606-D9D7-4EEE-A27D-DC862A5293A3", ModuleType.UserCode, 1)]
    public class closeExistingPrompts : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public closeExistingPrompts()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        /// 
        
        private void ClosePrompt()
        {
        	
        	List<Element> all = (List<Element>)Host.Local.Find(new RxPath("/form"));
			
			foreach(Element e in all)
			{
				Form f = new Form(e);
			//	Report.Info(f.Title);
			//	Report.Info(f.FlavorName);
			if(f.FlavorName.Equals("winforms"))
				   if(f.Title!="Amicus Attorney")
				   {
				Report.Info(String.Format("{0} Prompt/Dialog Closed after Test Case Failure",f.Title));
				   	f.Close();
				   }

			}
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ClosePrompt();
        }
    }
}
