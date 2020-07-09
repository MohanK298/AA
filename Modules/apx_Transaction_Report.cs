/*
 * Created by Ranorex
 * User: qa
 * Date: 7/9/2020
 * Time: 6:29 PM
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
    /// Description of apx_Transaction_Report.
    /// </summary>
    [TestModule("377ADC4F-C7CE-472B-B802-E17EF9A15B0B", ModuleType.UserCode, 1)]
    public class apx_Transaction_Report : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public apx_Transaction_Report()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        
        FirmSettings frm=FirmSettings.Instance;
        BillingClient bclient=BillingClient.Instance;
        Common cmn=new Common();
        
        private void apx_transaction_Report()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.Self.Activate();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	frm.MainForm.FirmSettingsForm.txtBillingAPX.Click();
        	
        	if(frm.BillingFirmSettingsForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Billing Abacus Payment Exchange form is displayed successfully.");
        		frm.BillingFirmSettingsForm.PnlBase.btnAPXTransactionReport.Click();
        		
        		if(frm.SQLReportGenerateForm.SelfInfo.Exists(3000))
        		{
        			Report.Success(String.Format("{0} is opened successfully.",frm.SQLReportGenerateForm.txttitle.GetAttributeValue<String>("Text")));
        			frm.SQLReportGenerateForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.AddMonths(-6).ToShortDateString());
        			frm.SQLReportGenerateForm.btnOK.Click();
        			if(frm.PDFForm.SelfInfo.Exists(10000))
        			{
        				Report.Success("PDF Form is opened successfully with the Transaction Report.");
        				Report.Success(frm.PDFForm.AVLAVView.GetAttributeValue<String>("Text"));
        				frm.PDFForm.Self.Close();
        			}
        		}
        		frm.BillingFirmSettingsForm.Toolbar1.btnOK.Click();
        	
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
            apx_transaction_Report();
        }
    }
}
