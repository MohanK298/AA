/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/8/2020
 * Time: 12:32 PM
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
using SmokeTest.Modules;
using SmokeTest.Repositories;
using SmokeTest.Modules.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateFloatingToolbar.
    /// </summary>
    [TestModule("75BBF21C-674A-469D-8E4E-6BB8D3DCEF82", ModuleType.UserCode, 1)]
    public class validateFloatingToolbar : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateFloatingToolbar()
        {
            // Do not delete - a parameterless constructor is required!
        }
		Files files=Files.Instance;
		
		
		private void validateFloatingTbar()
		{
			files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	if(files.MainForm.ShowAmicusToolbarInfo.Exists(3000))
        	{
        		files.MainForm.ShowAmicusToolbar.Click();
        		if(files.ToolbarForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Floating toolbar is seen as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnViewDailiesReportsInfo,"Dailies Report Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnFavoritesInfo,"Favorites Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnFilesListInfo,"Files List Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnViewCalendarInfo,"Calendar Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnPeopleListInfo,"People List Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnEntryListInfo,"Entry List Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnNotesListInfo,"Dailies Report Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnCommunicationsInfo,"Communications Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnDocumentsInfo,"Documents Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnLibraryInfo,"Library Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnTrustListInfo,"Trust Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnBillListInfo,"Bill List Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnReportListInfo,"Report List Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnRecordPhoneCallInfo,"Phone Call Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnSendStickyInfo,"Sticky Notes Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnCreateNewEventInfo,"Create New Event Button is displayed as expected");
        			Validate.Exists(files.ToolbarForm.Toolbar1.btnShowTimerInfo,"Show Timer Button is displayed as expected");
        		}
        		   
        	}
        	
        	files.ToolbarForm.Toolbar1.MenuItem.Click();
        	Validate.Exists(files.ToolbarForm.Toolbar1.AboutAmicusAttorneyInfo,"About Amicus Attorney List is displayed as expected");
			Validate.Exists(files.ToolbarForm.Toolbar1.HideFloatingToolbarInfo,"Hide Floating Toolbar List is displayed as expected");
			Validate.Exists(files.ToolbarForm.Toolbar1.AlignVerticallyInfo,"Align Vertically List is displayed as expected");
			Validate.Exists(files.ToolbarForm.Toolbar1.ExitAmicusAttorneyInfo,"Exit Amicus Attorney List is displayed as expected");
        	
			
			files.ToolbarForm.Toolbar1.MenuItem.Click();
        	
			files.MainForm.View.Click();
        	Delay.Seconds(1);
        	files.MainForm.Toolbars.Click();
        	Delay.Seconds(1);
        	if(files.MainForm.HideAmicusToolbarInfo.Exists(3000))
        	{
        		files.MainForm.HideAmicusToolbar.Click();
        		Delay.Seconds(2);	
   				Validate.NotExists(files.ToolbarForm.SelfInfo,"Floating Tool bar is not present as expected");
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
            validateFloatingTbar();
        }
    }
}
