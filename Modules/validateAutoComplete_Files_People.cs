/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/16/2020
 * Time: 4:27 PM
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
    /// Description of validateAutoComplete_Files_People.
    /// </summary>
    [TestModule("97362075-8551-4385-88EF-49DEE508F35F", ModuleType.UserCode, 1)]
    public class validateAutoComplete_Files_People : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateAutoComplete_Files_People()
        {
            // Do not delete - a parameterless constructor is required!
        }
		Calendar calendar=Calendar.Instance;
		Common cmn=new Common();
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void validateAutoFill()
        {
        	calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtFileAutoComplete.Click();
        	calendar.EventDetailForm.PnlBase.txtFileAutoComplete.PressKeys("Personal");
        	Delay.Seconds(1);
        	//cmn.SelectItemDropdown(calendar.AutoCompleteForm.tbAutoComplete,"Personal - Illness -");
        	if(calendar.AutoCompleteForm.tbAutoCompleteInfo.Exists(3000))
        	{
        		Report.Success(String.Format("Auto Complete Form exists for the File Entry provided with {0} reocrds",calendar.AutoCompleteForm.tbAutoComplete.Rows.Count));
        	}
        	calendar.EventDetailForm.btnCancel.Click();
        	
        	
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtPeopleAutoComplete.Click();
        	calendar.EventDetailForm.PnlBase.txtPeopleAutoComplete.PressKeys("Amicus");
        	Delay.Seconds(1);
        	//cmn.SelectItemDropdown(calendar.AutoCompleteForm.tbAutoComplete,"Amicus");
        	if(calendar.AutoCompleteForm.tbAutoCompleteInfo.Exists(3000))
        	{
        		Report.Success(String.Format("Auto Complete Form exists for the People Entry provided with {0} reocrds",calendar.AutoCompleteForm.tbAutoComplete.Rows.Count));
        	}
        	calendar.EventDetailForm.btnCancel.Click();

        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            validateAutoFill();
        }
    }
}
