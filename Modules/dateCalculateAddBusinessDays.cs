/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/8/2020
 * Time: 12:41 PM
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
    /// Description of dateCalculateAddBusinessDays.
    /// </summary>
    [TestModule("54ADCAA0-ED9E-48F1-ABD2-79D32B4F46E6", ModuleType.UserCode, 1)]
    public class dateCalculateAddBusinessDays : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public dateCalculateAddBusinessDays()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        
        private void DateCalcAddBusinessDays()
        {
        	System.DateTime curdate,result;
        	string txtresult;
        	curdate=System.DateTime.Now;
        	frm.MainForm.Tools.Click();
        	Delay.Seconds(1);
        	frm.MainForm.DateCalculator.Click();
        	if(frm.DateCalculatorForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Date Calculator Form is opened successfully");
        		//frm.DateCalculatorForm.PnlBase.txtDays.PressKeys(curdate);
        		frm.DateCalculatorForm.PnlBase.txtDays.PressKeys("10");
        		frm.DateCalculatorForm.PnlBase.btnCalculate.Click();
        		
        		result=cmn.AddBusinessDays(curdate,10);
        		txtresult=result.ToString("ddd MMMM dd,yyyy");
        		
        		if(frm.DateCalculatorForm.PnlBase.txtResult.GetAttributeValue<String>("Text")==txtresult)
        		{
        			Report.Success(String.Format("Calculated days for 10 business days {0} is as expected",txtresult));
        		}
        		else
        		{
        			Report.Failure(String.Format("Calculated days for 10 business days {0} is not as expected",txtresult));
        		}
        		
        		frm.DateCalculatorForm.Toolbar1.btnOK.Click();
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
            DateCalcAddBusinessDays();
        }
    }
}
