/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/15/2020
 * Time: 5:16 PM
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
    /// Description of filer_Trust_Validation.
    /// </summary>
    [TestModule("BE515F56-95FC-41A4-8C8D-909781476378", ModuleType.UserCode, 1)]
    public class filer_Trust_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public filer_Trust_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Trust trst=Trust.Instance;
    	Common cmn=new Common();
    	string chkdata="Trust Check Added: "+System.DateTime.Now.ToShortDateString();
    	string receiptdata="Retainer: "+System.DateTime.Now.ToShortDateString();
    	string trustTransferdata="Trust Transfer to AR: "+System.DateTime.Now.ToShortDateString();
    	string FiletoFiledata="Trust File to File Transfer: "+System.DateTime.Now.ToShortDateString();
    	
    	private void filter_Validation()
    	{
    		
    		trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	trst.MainForm.TrustControlPanelControl.cbFileToFileTransfers.Uncheck();
        	trst.MainForm.TrustControlPanelControl.cbTrustTransfersToAR.Uncheck();
        	trst.MainForm.TrustControlPanelControl.cbReceipts.Uncheck();
        	trst.MainForm.TrustControlPanelControl.cbChecks.Check();
        	
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,chkdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,receiptdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,trustTransferdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,FiletoFiledata,"Trust Details Table");
        	
        	
        	trst.MainForm.TrustControlPanelControl.cbReceipts.Check();
        	
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,chkdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,receiptdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,trustTransferdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,FiletoFiledata,"Trust Details Table");
        	
        	trst.MainForm.TrustControlPanelControl.cbTrustTransfersToAR.Check();
        	
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,chkdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,receiptdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,trustTransferdata,"Trust Details Table");
        	cmn.VerifyDataNotExistsInTable(trst.MainForm.tblTrustDetails,FiletoFiledata,"Trust Details Table");
        	
        	
        	trst.MainForm.TrustControlPanelControl.cbFileToFileTransfers.Check();
        	
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,chkdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,receiptdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,trustTransferdata,"Trust Details Table");
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,FiletoFiledata,"Trust Details Table");
        	
        	
        	
    	
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
            filter_Validation();
        }
    }
}
