///*
// * Created by Ranorex
// * User: Kumar
// * Date: 2019-10-04
// * Time: 3:33 PM
// * 
// * To change this template use Tools > Options > Coding > Edit standard headers.
// */
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Drawing;
//using System.Threading;
//using WinForms = System.Windows.Forms;
//
//using Ranorex;
//using Ranorex.Core;
//using Ranorex.Core.Testing;
//
//using SmokeTest.Repositories;
//
//namespace SmokeTest.Modules.Attorney_FileDetails
//{
//    /// <summary>
//    /// Description of testfolder.
//    /// </summary>
//    [TestModule("24080C1D-4BDA-40BB-B49A-E7135E0EA75E", ModuleType.UserCode, 1)]
//    public class testfolder : ITestModule
//    {
//        /// <summary>
//        Documents dc = new Documents();
//        /// Constructs a new instance.
//        /// </summary>
//        public testfolder()
//        {
//            // Do not delete - a parameterless constructor is required!
//        }
//
//        /// <summary>
//        /// Performs the playback of actions in this module.
//        /// </summary>
//        /// <remarks>You should not call this method directly, instead pass the module
//        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
//        /// that will in turn invoke this method.</remarks>
//        void ITestModule.Run()
//        {
//            Mouse.DefaultMoveTime = 300;
//            Keyboard.DefaultKeyPressTime = 100;
//            Delay.SpeedFactor = 1.0;
//            
//            dc.DocumentDetail.PnlBase.dpdwnFileType.Click();
//            Keyboard.PrepareFocus(dc.DocumentDetail.PnlBase.dpdwnFileType);
//            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//            Keyboard.Press(System.Windows.Forms.Keys.Return, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//            
//        }
//    }
//}
