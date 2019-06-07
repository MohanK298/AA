/*
 * Created By Asish
 * User: Administrator
 * Date: 2017-11-02
 * Time: 10:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of AddFolder2.
    /// </summary>
    [TestModule("B1E7519A-F770-4367-9111-63130D97FF64", ModuleType.UserCode, 1)]
    public class AddFolder2 : ITestModule
    {
        //Repository Variable
       SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
       
       public AddFolder2()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Documents.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.AllDocuments.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.btnNewDoc.Click();
        	Delay.Seconds(1);
        	//file.DocumentDetail.pnlBase.txtDocumentTitle.PressKeys(documentTitle + time);
        	file.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Add Folder Test");
        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
        	Delay.Seconds(1);
        	file.DropdownSelector.DropdownSelect1.Click();
        	Delay.Seconds(1);
//        	file.DocumentDetail.PnlBase.btnLocation.Click();
//        	Delay.Seconds(1);
//      /*  	file.OpenFolder.ThisPC.Click();
//        	file.OpenFolder.BrowseFolder.Documents.Click();
//        	file.OpenFolder.BrowseFolder.SelectFolder.Click();
//      */	file.OpenFolder.BrowseFolder.Network.Click();
//        	file.OpenFolder.BrowseFolder.SharedDocuments.Click();
//        	file.OpenFolder.BrowseFolder.DocumentFolder.Click();	  	
//     		file.OpenFolder.btnOK.Click();
        	
			file.DocumentDetail.PnlBase.EnterURL.PressKeys("\\\\newautomation\\SharedDocuments\\tutorial");
			Delay.Seconds(1);
        	file.DocumentDetail.summaryTxt.PressKeys("Folder Adding Test");
        	file.DocumentDetail.btnOK.Click();  
        	file.FileDetailForm.AddedFolder.Click();
        	Validate.Exists(file.FileDetailForm.FolderView);
        	//Validate.Exists(file.FileDetailForm.AllDoc);
        	file.FileDetailForm.btnSaveClose.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
        Action();
        }
    }
}
