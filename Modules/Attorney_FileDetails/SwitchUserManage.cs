/*
 * Created by Asish
 * User: Administrator
 * Date: 2017-11-01
 * Time: 9:26 AM
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
    /// Description of SwitchUserManage.
    /// </summary>
    [TestModule("7101FC44-9129-46C5-B911-664B02244978", ModuleType.UserCode, 1)]
    public class SwitchUserManage : ITestModule
    {
        SmokeTest.Repositories.FirmSettings firmsetting = new SmokeTest.Repositories.FirmSettings();
        Common cmn=new Common();
 /*       public class Locator
        {
        	public const string Xpath = "/form[@controlname='ProgressForm']";
        }
 */       
        public SwitchUserManage()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
  /*      public static bool Exists(
        	string /form[@controlname='ProgressForm'],
        	Duration 10ms,
        	string "Switched",
        	bool report.info()
        )
*/
        public void Action(){
        	firmsetting.MainForm.Office.Click();
        	Delay.Seconds(1);
        	
        	firmsetting.MainForm.View.Click();
			Delay.Seconds(2);
			firmsetting.MainForm.FirmSettings1.Click();
			
        	Delay.Seconds(2);
        	firmsetting.MainForm.FirmSettingsForm.Management.Click();
        	Delay.Seconds(1);
        	firmsetting.DocumentFirmSettingsForm.Configure.Click();
        	Delay.Seconds(1);
        	firmsetting.DocumentManagementWizForm.RadioAmicusManaged.Click();
        	firmsetting.DocumentManagementWizForm.Next.Click();
        	//firmsetting.DocumentManagementWizForm.Indexing.Click();
        	firmsetting.DocumentManagementWizForm.Next.Click();
        	//firmsetting.DocumentManagementWizForm.Dropdown.Click();
        	//firmsetting.DocumentManagementWizForm.SelectCopy.Click();
        	firmsetting.DocumentManagementWizForm.Finish.Click();
        	firmsetting.PromptForm.btnYes.Click();
        	Delay.Seconds(30);
        	
    /*    	bool found = true;
        	found = bool.Parse("/form[@controlname='ProgressForm']");
        	if( firmsetting.(()))
        		{ 
        			Delay.Seconds(20);	
        		}
        		else
        		{
        			Report.Info("Switch Completed");
        		}
    	   	//Validate.NotExists("/form[@controlname='ProgressForm']");
        	//Report.Info("Switch Complete");
     */   	Delay.Seconds(20);
   	 	if(firmsetting.DocumentUnconverted.UnconvertedCloseInfo.Exists(10000))
   		 {firmsetting.DocumentUnconverted.UnconvertedClose.Click();
   	 		Report.Info("Unconverted Close button is closed");
   	 			
   	 	}
   	 	if(     firmsetting.DocumentFirmSettingsForm.OKInfo.Exists(3000))
   	 	{firmsetting.DocumentFirmSettingsForm.OK.Click();
   	 		Report.Info("Ok button is clicked");
   	 	}
        
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
