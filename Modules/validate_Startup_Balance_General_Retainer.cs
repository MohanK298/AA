/*
 * Created by Ranorex
 * User: qa
 * Date: 7/9/2020
 * Time: 5:23 PM
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
    /// Description of validate_Startup_Balance_General_Retainer.
    /// </summary>
    [TestModule("FC13ACE5-E24A-4034-B2D4-1EF9DAB2A0CC", ModuleType.UserCode, 1)]
    public class validate_Startup_Balance_General_Retainer : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_Startup_Balance_General_Retainer()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
        
        Common cmn=new Common();
        BillingClient bclient=BillingClient.Instance;
        Files file = Files.Instance;
        FirmSettings frm=FirmSettings.Instance;
        
        Bill bill = Bill.Instance;
        People people = People.Instance;
        
        string[] methodItems={"Check","Cash","Credit Card","Electronic","Other"};
        private void validate_Startup_NoApxFields()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.btnStrtUpOpen.Click();
        	Delay.Milliseconds(500);
        	frm.dpdwnValue="- General Retainer";
        	Delay.Milliseconds(500);
        	frm.lstDropdown.lstDropdownValue.Click();
        	Report.Success("General Retainer Dropdown value Selected successfully under Office -> Startup Balance -> General Retainer UI");
        	if(file.FileSelectForm.SelfInfo.Exists(3000))
    		{
    			
    			file.FileSelectForm.listFirstFoundFile.DoubleClick();
    			Report.Success("File Selected successfully");
    		}
        	
        	Delay.Seconds(1);
        	bill.ReceivePaymentForm.cmbbxType.Click();
    		for(int i=0;i<methodItems.Length;i++)
    		{
    			bill.lstdpdwnType=methodItems[i];
    			Delay.Milliseconds(300);
    			Validate.Exists(bill.listDropdwn.SelfInfo,String.Format("Item {0} is present in the Method Dropdown as expected",methodItems[i]));
    			
    		}
    		bill.ReceivePaymentForm.cmbbxType.Click();
        	
    		bill.ReceivePaymentForm.Toolbar1.btnCancel.Click();
        	
        	
        	
        	
        	
        	
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
            validate_Startup_NoApxFields();
        }
    }
}
