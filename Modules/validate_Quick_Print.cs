/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 6:19 PM
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
    /// Description of validate_Quick_Print.
    /// </summary>
    [TestModule("2FC9E4A1-87CD-454E-B1B2-37F586651AC1", ModuleType.UserCode, 1)]
    public class validate_Quick_Print : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_Quick_Print()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
         Bill bill=Bill.Instance;
        private void Quick_Print()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	if(!bill.MainForm.cbFirstRow.Checked)
        	{
        		bill.MainForm.cbFirstRow.Click();
        	}
        	else
        	{
        		bill.MainForm.cbFirstRow.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbFirstRow.Click();
        	}
        	
        	
        	Delay.Seconds(2);
        	bill.MainForm.btnReprintBills.Click();
        	if(bill.OutputPromptForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Output form is displayed as expected");
        		bill.OutputPromptForm.chkScreen.Uncheck();
        		bill.OutputPromptForm.chkPrinter.Check();
        		Validate.AttributeEqual(bill.OutputPromptForm.chkQuickPrintDefaultPrinterInfo,"Checked","False","Quick Printer is unchecked as expected");
        		bill.OutputPromptForm.btnOk.Click();
        	
        		if(bill.Print.SelfInfo.Exists(3000))
        		{
        			Report.Success("Print Form is displayed as expected");
        			bill.Print.btnCancel.Click();
        		}
        		
        	if(bill.MainForm.cbFirstRow.Checked)
        	{
        		bill.MainForm.cbFirstRow.Click();
        	}
        	else
        	{
        		bill.MainForm.cbFirstRow.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbFirstRow.Click();
        	}
        	
        	
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
            Quick_Print();
        }
    }
}
