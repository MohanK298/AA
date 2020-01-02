/*
 * Created by Ranorex
 * User: qa
 * Date: 6/6/2019
 * Time: 10:54 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories.Premium;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of CheckCache.
    /// </summary>
    [TestModule("CCAF2AA4-5385-4D93-BF01-8068B00A91B5", ModuleType.UserCode, 1)]
    public class CheckCache : ITestModule
    {
    	FileDetails fd = FileDetails.Instance;
    	Communications cm = Communications.Instance;
    	EventDetails ed = EventDetails.Instance;
    	string eventTitle = "Ranorex event " + System.DateTime.Now;
    	
    	string _MatterName = "File";
    	[TestVariable("79645f53-9ae6-4e45-89b5-1d7dd640a9cb")]
    	public string MatterName
    	{
    		get { return _MatterName; }
    		set { _MatterName = value; }
    	}
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckCache()
        {
            // Do not delete - a parameterless constructor is required!
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
            
            Report.Log(ReportLevel.Info, eventTitle);
            cm.MainForm.AttorneyOrBilling.Attorney.Click();
            cm.MainForm.LeftPanel.Files.Click();
            cm.FileName = MatterName; //Name of the Matter that this script should run on, using default value when commented out
            cm.MainForm.FilesModule.FileByName.DoubleClick();
            AddSummary();
            AddStatusReport();
            AddMainNote();
            CreateNewEvent();
            fd.EventTitle = eventTitle;
        	fd.FileDetailForm.Self.Activate();
        	Validate.Exists(fd.FileDetailForm.PanelRight.Events.EventByTitleInfo);
        	
        	fd.FileDetailForm.File_Facts.Summary.Click();
        	Validate.AttributeContains(fd.FileDetailForm.PanelRight.TextInfo, "Text", "Ranorex test file Summary text" + eventTitle);
        	fd.FileDetailForm.File_Facts.Status_Report.Click();
        	Validate.AttributeContains(fd.FileDetailForm.PanelRight.TextInfo, "Text", "Ranorex test file Status text" + eventTitle);
        	fd.FileDetailForm.File_Facts.Notes.Click();
        	Validate.AttributeContains(fd.FileDetailForm.PanelRight.TextInfo, "Text", "Ranorex test file Main Note text" + eventTitle);
        	
        	fd.FileDetailForm.SaveClose.Click();
        	Utilities.Common.ClosePrompt();
        }
        
        private void AddSummary()
        {
        	fd.FileDetailForm.File_Facts.Summary.Click();
            fd.FileDetailForm.PanelRight.TitleInfo.WaitForAttributeEqual(Utilities.Constants.customWaitTime, "Text", "Summary");
            fd.FileDetailForm.PanelRight.Text.PressKeys("Ranorex test file Summary text" + eventTitle);
        }
        
        private void AddStatusReport()
        {
        	fd.FileDetailForm.File_Facts.Status_Report.Click();
            fd.FileDetailForm.PanelRight.TitleInfo.WaitForAttributeEqual(Utilities.Constants.customWaitTime, "Text", "Status Report");
            fd.FileDetailForm.PanelRight.Text.PressKeys("Ranorex test file Status text" + eventTitle);
        }
        
        private void AddMainNote()
        {
        	fd.FileDetailForm.File_Facts.Notes.Click();
            fd.FileDetailForm.PanelRight.TitleInfo.WaitForAttributeEqual(Utilities.Constants.customWaitTime, "Text", "Main Note");
            fd.FileDetailForm.PanelRight.Text.PressKeys("Ranorex test file Main Note text" + eventTitle);
        }
        
        private void CreateNewEvent()
        {
        	fd.FileDetailForm.File_Facts.Events.Click();
        	fd.FileDetailForm.PanelRight.NewBtn.Click();
        	ed.EventDetailForm.Title.PressKeys(eventTitle);
        	ed.EventDetailForm.OkBtn.Click();
        	
        	if (ed.AppointmentOverlapDialog.SelfInfo.Exists()) {
        		ed.AppointmentOverlapDialog.RadioOK.Click();
        		ed.AppointmentOverlapDialog.OkBtn.Click();
        	}
        }
    }
}
