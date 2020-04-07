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
    ///The EmailTest_QC recording.
    /// </summary>
    [TestModule("318fcd2b-5d99-4182-843b-a8fd9d335d55", ModuleType.Recording, 1)]
    public partial class EmailTest_QC : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::SmokeTest.Repositories.SmokeTestRepository repository.
        /// </summary>
        public static global::SmokeTest.Repositories.SmokeTestRepository repo = global::SmokeTest.Repositories.SmokeTestRepository.Instance;

        static EmailTest_QC instance = new EmailTest_QC();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EmailTest_QC()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EmailTest_QC Instance
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

            Mouse_Click_ContainerGroup9(repo.MainForm.ContainerGroup9Info);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='True') on item 'MainForm.CommIndexForm.MenuItemToolbarToolbarToolsTool1'.", repo.MainForm.CommIndexForm.MenuItemToolbarToolbarToolsTool1Info, new RecordItemIndex(1));
            Validate.AttributeEqual(repo.MainForm.CommIndexForm.MenuItemToolbarToolbarToolsTool1Info, "Enabled", "True");
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='True') on item 'MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolC'.", repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolCInfo, new RecordItemIndex(2));
            Validate.AttributeEqual(repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolCInfo, "Enabled", "True");
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text='Synchronize now') on item 'MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolC'.", repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolCInfo, new RecordItemIndex(3));
            Validate.AttributeEqual(repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolCInfo, "Text", "Synchronize now");
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolC' at 33;28.", repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolCInfo, new RecordItemIndex(4));
            repo.MainForm.CommIndexForm.ButtonToolbarToolbarToolsToolC.Click("33;28");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text='Newest on Top') on item 'MainForm.CommIndexForm.NewestOnTop'.", repo.MainForm.CommIndexForm.NewestOnTopInfo, new RecordItemIndex(5));
            Validate.AttributeEqual(repo.MainForm.CommIndexForm.NewestOnTopInfo, "Text", "Newest on Top");
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Down item 'MainForm.CommIndexForm.AmicusGradientPanel' at 105;6.", repo.MainForm.CommIndexForm.AmicusGradientPanelInfo, new RecordItemIndex(6));
            repo.MainForm.CommIndexForm.AmicusGradientPanel.MoveTo("105;6");
            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MainForm.CommIndexForm.AmicusGradientPanel' at 113;-2.", repo.MainForm.CommIndexForm.AmicusGradientPanelInfo, new RecordItemIndex(7));
            repo.MainForm.CommIndexForm.AmicusGradientPanel.MoveTo("113;-2");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Up item 'MainForm.CommIndexForm.NewestOnTop' at 74;7.", repo.MainForm.CommIndexForm.NewestOnTopInfo, new RecordItemIndex(8));
            repo.MainForm.CommIndexForm.NewestOnTop.MoveTo("74;7");
            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MainForm.CommIndexForm.AmicusGradientPanel' at 104;5.", repo.MainForm.CommIndexForm.AmicusGradientPanelInfo, new RecordItemIndex(9));
            repo.MainForm.CommIndexForm.AmicusGradientPanel.Click("104;5");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MainForm.CommIndexForm.AmicusGradientPanel' at 104;7.", repo.MainForm.CommIndexForm.AmicusGradientPanelInfo, new RecordItemIndex(10));
            repo.MainForm.CommIndexForm.AmicusGradientPanel.Click("104;7");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (InnerText='this is from gmail to ol') on item 'MainForm.CommIndexForm.ThisIsFromGmailToOl'.", repo.MainForm.CommIndexForm.ThisIsFromGmailToOlInfo, new RecordItemIndex(11));
            Validate.AttributeEqual(repo.MainForm.CommIndexForm.ThisIsFromGmailToOlInfo, "InnerText", "this is from gmail to ol");
            Delay.Milliseconds(100);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
