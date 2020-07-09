/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/15/2020
 * Time: 3:56 PM
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
    /// Description of trustFileToFileTransfer.
    /// </summary>
    [TestModule("7AD3F0DC-469D-475B-92B2-1A4F63288A7E", ModuleType.UserCode, 1)]
    public class trustFileToFileTransfer : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trustFileToFileTransfer()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Trust trst=Trust.Instance;
    	Common cmn=new Common();
    	
    	string data="Trust File to File Transfer: "+System.DateTime.Now.ToString();
    	string availBalance,newBalance,transferAmt="";
    	string newAmount="";
    	private void trustFiletoFile_Validation()
    	{
    		trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	trst.MainForm.TrustControlPanelControl.cbFileToFileTransfers.Check();
        	
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	trst.MainForm.Toolbar1.FileToFileTransfer.Click();
        	
        	if(trst.TrustFileToTrustFileForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Trust File to File Transfer Form is displayed successfully");
        		//cmn.SelectItemDropdown(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptTo,"1 - Trust","Receipt to Dropdown");
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(trst.TrustFileToTrustFileForm.PnlBase.cmbbxReceiptToInfo,"Text","1 - Trust","From Dropdown has the value 1 - Trust Selected");
        		
        		Validate.AttributeContains(trst.TrustFileToTrustFileForm.PnlBase.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"),"Today's Date is set to Default");
        		Validate.AttributeContains(trst.TrustFileToTrustFileForm.PnlBase.txtDescriptionInfo,"UIAutomationValueValue","",String.Format("Description for Trust File to File Transfer is: '{0}' - empty",trst.TrustFileToTrustFileForm.PnlBase.txtDescription.GetAttributeValue<String>("UIAutomationValueValue")));
        		trst.TrustFileToTrustFileForm.PnlBase.txtDescription.PressKeys(data);
        		
        		
        		trst.TrustFileToTrustFileForm.PnlBase.btnAddFile.Click();
        		if(trst.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			trst.FileSelectForm.btnQuickFindFile.Click();
        			if(trst.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				trst.FindFilesForm.searchTextInput.PressKeys(System.DateTime.Now.ToShortDateString());
        				trst.FindFilesForm.btnOK.Click();
        			}
        			trst.FileSelectForm.listFirstFound.DoubleClick();
        		}
        		
        		Delay.Seconds(2);
        		
        		availBalance=trst.TrustFileToTrustFileForm.PnlBase.txtAvailableValue.GetAttributeValue<String>("Text");
        		newBalance=trst.TrustFileToTrustFileForm.PnlBase.txtNewBalanceValue.GetAttributeValue<String>("Text");
        		transferAmt=trst.TrustFileToTrustFileForm.PnlBase.txtTransferValue.GetAttributeValue<String>("Text");
        		
        		Report.Success(String.Format("Available balance for the selected file is : {0}",availBalance));
        		Report.Success(String.Format("Transfer amount for the selected file is : {0}",transferAmt));
        		Report.Success(String.Format("New balance for the selected file is : {0}",newBalance));
        		
        		
        		
        		trst.TrustFileToTrustFileForm.PnlBase.imgAddFile.Click();
        		if(trst.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			trst.FileSelectForm.btnQuickFindFile.Click();
        			if(trst.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				trst.FindFilesForm.searchTextInput.PressKeys(System.DateTime.Now.ToShortDateString());
        				trst.FindFilesForm.btnOK.Click();
        			}
        			trst.FileSelectForm.listSecondFoundFile.DoubleClick();
        		}
        		Delay.Seconds(2);
        		trst.TrustFileToTrustFileForm.PnlBase.txtTransferInput.Click();
        		trst.TrustFileToTrustFileForm.PnlBase.txtTransferEdit.TextValue="150";
        		
        		trst.TrustFileToTrustFileForm.PnlBase.txtDescription.Click();
        		
        		Delay.Seconds(1);
        		
        		availBalance=trst.TrustFileToTrustFileForm.PnlBase.txtAvailableValue.GetAttributeValue<String>("Text");
        		newBalance=trst.TrustFileToTrustFileForm.PnlBase.txtNewBalanceValue.GetAttributeValue<String>("Text");
        		transferAmt=trst.TrustFileToTrustFileForm.PnlBase.txtTransferValue.GetAttributeValue<String>("Text");
        		
        		
        		Report.Success(String.Format("Available balance for the selected file after the transfer is : {0}",availBalance));
        		Report.Success(String.Format("Transfer amount for the selected file after the transfer is : {0}",transferAmt));
        		Report.Success(String.Format("New balance for the selected file after the transfer is : {0}",newBalance));
        		
        		
        		newAmount=(Double.Parse(availBalance)-Double.Parse(transferAmt)).ToString();
        		

        		if(newBalance.Contains(newAmount))
        		{
        			Report.Success(String.Format("The New balance for the selected file after the tranfer is calculated correctly"));
        		}
        		else
        		{
        			Report.Failure(String.Format("The New balance for the selected file after the tranfer is wrongly calculated"));
        		}
        			
        		trst.TrustFileToTrustFileForm.btnSaveClose.Click();
        		
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,data,"Trust Details Table");
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
            trustFiletoFile_Validation();
        }
    }
}
