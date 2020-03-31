/*
 * Created by Asish
 * User: Administrator
 * Date: 2017-11-01
 * Time: 10:20 AM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of VerifyDocuments.
    /// </summary>
    [TestModule("604E6D1B-7E56-47AA-85CC-E4B69673C65E", ModuleType.UserCode, 1)]
    public class VerifyDocuments : ITestModule
    {
      	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	Common cmn=new Common();
    		
       
       public VerifyDocuments()
        {
            // Do not delete - a parameterless constructor is required!
        }
		public void Action(){
       	file.MainForm.File.Click();
       	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        Delay.Seconds(2);
        file.FileDetailForm.Documents.Click();
        Delay.Seconds(2);
        file.FileDetailForm.DocumentFolder.Click();
        Delay.Seconds(2);
        file.FileDetailForm.SelectFolder.DoubleClick();
        Validate.Exists(file.FileDetailForm.FolderView1Info);
        file.FileDetailForm.AllDocuments.Click();
        Delay.Seconds(1);        
        Validate.Exists(file.FileDetailForm.FileViewInfo);
        file.FileDetailForm.btnSaveClose.Click();
               	
        	
       

    	}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
           Action();
           cmn.ClosePrompt();
        }
    }
}
