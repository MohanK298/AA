/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 11:48 AM
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
    /// Description of FindFile.
    /// </summary>
    [TestModule("44687487-73CF-41A1-9CEE-65F231901706", ModuleType.UserCode, 1)]
    public class FindFile : ITestModule
    {
        //Repository Variable
        SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public FindFile()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _fileName = "";
        [TestVariable("11787393-9ED7-4DFE-A08B-2670926DDD69")]
        public string fileName
        {
        	get { return _fileName; }
        	set { _fileName = value; }
        }
        
        string _time = "";
        [TestVariable("D8BA9113-129C-4F9A-AEE3-7A3E16D81C1C")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            //Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	//file.FindFilesForm.txtFindFile.TextValue = fileName + time + "2";
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	file.FindFilesForm.btnOK.Click();
        	Delay.Seconds(2);
        	Utilities.Common.ClosePrompt();
        }
    }
}
