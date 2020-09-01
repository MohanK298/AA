/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 6:01 PM
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
    /// Description of all_Bills_checkbox_Validate.
    /// </summary>
    [TestModule("C008C736-37B1-47C9-8A70-619B2FFFB4B4", ModuleType.UserCode, 1)]
    public class all_Bills_checkbox_Validate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public all_Bills_checkbox_Validate()
        {
            // Do not delete - a parameterless constructor is required!
        }

             Bill bill=Bill.Instance;
        	 
        private void all_Check_Validate()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	Delay.Seconds(5);
        	bill.MainForm.txtAllCheckbox.Click();
        	Report.Success("All Bill Checkbox is Checked");
        	
        	Delay.Seconds(4);
        	for(int i=0;i<3;i++)
        	{
        		bill.index=i.ToString();
        		Validate.AttributeContains(bill.MainForm.cbGeneralRowInfo,"Checked","True",String.Format("Row {0} Checkbox is Checked as expected",i+1));
        		Delay.Milliseconds(500);
        	}
        	
        	bill.MainForm.txtAllCheckbox.Click();
        	Delay.Seconds(1);
        	Report.Success("All Bill Checkbox is unchecked");
        	for(int i=0;i<3;i++)
        	{
        		bill.index=i.ToString();
        		Validate.AttributeContains(bill.MainForm.cbGeneralRowInfo,"Checked","False",String.Format("Row {0} Checkbox is Unchecked as expected",i+1));
        		Delay.Milliseconds(500);
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
            all_Check_Validate();
        }
    }
}
