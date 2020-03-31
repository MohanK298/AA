/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-02-02
 * Time: 9:56 AM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CreatePrecedent.
    /// </summary>
    [TestModule("840AC78A-7185-42C0-A164-634CC87945C6", ModuleType.UserCode, 1)]
    public class CreatePrecedent : ITestModule
    {
        SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	SmokeTest.Repositories.Calendar calendar = new SmokeTest.Repositories.Calendar();
    	Common cmn=new Common();
    	
        public CreatePrecedent()
        {
            // Do not delete - a parameterless constructor is required!
        }
       
        public void Action()
        {
        	Random rnd=new Random();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	file.FileDetailForm.SelectToDo.PressKeys("{LShiftKey down}");
        	file.FileDetailForm.SelectToDo.Click();
        	file.FileDetailForm.SelectToDo.PressKeys("{LShiftKey up}");
        	file.FileDetailForm.Precedent.Click();
        	file.FileDetailForm.SavePrecedent.Click();
        	file.NewPrecedentForm.txtPrecedentName.TextValue="Precedent Test"+rnd.Next(1,1000).ToString();
        	file.NewPrecedentForm.RadioSameOriginal.Click();
        	file.NewPrecedentForm.btnOk.Click();
        	file.PrecedentProfileForm.txtPrecedentDescription.PressKeys("Precedents Test Description");
        	//file.PrecedentProfileForm.btnAdd.Click();
        	file.PrecedentProfileForm.btnSave.Click();
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
