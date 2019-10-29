/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-16
 * Time: 3:37 PM
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
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
namespace SmokeTest
{
    /// <summary>
    /// Description of verifyPromptNoFileSelection.
    /// </summary>
    [TestModule("1ECF0744-527B-410A-A31D-7ECA4F2A3451", ModuleType.UserCode, 1)]
    public class verifyPromptNoFileSelection : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        Common cmn=new Common();
        public verifyPromptNoFileSelection()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);   
        private void GenerateDocument()
        {
        	doc.MainForm.Self.Activate();
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {

        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	doc.DocumentDetail.PnlBase.btnDropdownType.Click();
        	doc.DropDownForm.Self.Activate();
        	cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"Other");
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	Validate.Exists(doc.PromptForm.SelfInfo,"Prompt Form Exists");
        	Validate.AttributeContains(doc.PromptForm.txtInfoInfo,"Text","A document must be associated to one File or Contact.");
        	doc.PromptForm.btnOK.Click();
        	doc.DocumentDetail.MenubarFillPanel.btnCancel.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            GenerateDocument();
            FillDocument();
        }
    }
}
