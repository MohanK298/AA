﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

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
using Ranorex.Core.Repository;

namespace SmokeTest.Recordings
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Recording8 recording.
    /// </summary>
    [TestModule("6ed65633-6e3a-4362-a969-12ca6f4cdbff", ModuleType.Recording, 1)]
    public partial class Recording8 : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::SmokeTest.Repositories.FirmSettings repository.
        /// </summary>
        public static global::SmokeTest.Repositories.FirmSettings repo = global::SmokeTest.Repositories.FirmSettings.Instance;

        static Recording8 instance = new Recording8();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Recording8()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Recording8 Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Application", "Run application 'C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe' with arguments '' in normal mode.", new RecordItemIndex(0));
            Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe", "", "C:\\Amicus\\Amicus Attorney Workstation", false);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'LoginForm.Login' at 56;9.", repo.LoginForm.LoginInfo, new RecordItemIndex(1));
            repo.LoginForm.Login.Click("56;9");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MainForm.FirmSettings' at 59;12.", repo.MainForm.FirmSettingsInfo, new RecordItemIndex(2));
            repo.MainForm.FirmSettings.Click("59;12");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MainForm.StaticText' at 20;7.", repo.MainForm.StaticTextInfo, new RecordItemIndex(3));
            repo.MainForm.StaticText.Click("20;7");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentFirmSettingsForm.Configure' at 39;8.", repo.DocumentFirmSettingsForm.ConfigureInfo, new RecordItemIndex(4));
            repo.DocumentFirmSettingsForm.Configure.Click("39;8");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentManagementWizForm.RadioAmicusManaged' at 5;3.", repo.DocumentManagementWizForm.RadioAmicusManagedInfo, new RecordItemIndex(5));
            repo.DocumentManagementWizForm.RadioAmicusManaged.Click("5;3");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentManagementWizForm.Next' at 3;8.", repo.DocumentManagementWizForm.NextInfo, new RecordItemIndex(6));
            repo.DocumentManagementWizForm.Next.Click("3;8");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentManagementWizForm.Next' at 6;8.", repo.DocumentManagementWizForm.NextInfo, new RecordItemIndex(7));
            repo.DocumentManagementWizForm.Next.Click("6;8");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentManagementWizForm.Finish' at 36;9.", repo.DocumentManagementWizForm.FinishInfo, new RecordItemIndex(8));
            repo.DocumentManagementWizForm.Finish.Click("36;9");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'PromptForm.Yes' at 30;12.", repo.PromptForm.YesInfo, new RecordItemIndex(9));
            repo.PromptForm.Yes.Click("30;12");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ProgressForm.ButtonToolbarToolbarBaseDesignerToo' at 13;11.", repo.ProgressForm.ButtonToolbarToolbarBaseDesignerTooInfo, new RecordItemIndex(10));
            repo.ProgressForm.ButtonToolbarToolbarBaseDesignerToo.Click("13;11");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating Exists on item 'DocumentFirmSettingsForm.TextEditorEditArea'.", repo.DocumentFirmSettingsForm.TextEditorEditAreaInfo, new RecordItemIndex(11));
            Validate.Exists(repo.DocumentFirmSettingsForm.TextEditorEditAreaInfo);
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DocumentFirmSettingsForm.OK' at 20;9.", repo.DocumentFirmSettingsForm.OKInfo, new RecordItemIndex(12));
            repo.DocumentFirmSettingsForm.OK.Click("20;9");
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
