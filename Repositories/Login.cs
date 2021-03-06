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
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace SmokeTest.Repositories
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Login element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("5ef322c8-b0ca-474c-a89b-a70fb297402b")]
    public partial class Login : RepoGenBaseFolder
    {
        static Login instance = new Login();
        LoginFolders.LoginFormAppFolder _loginform;
        LoginFolders.AnnouncementFormAppFolder _announcementform;
        LoginFolders.CustomerExperienceProgramFormAppFolder _customerexperienceprogramform;
        LoginFolders.UpdateAppFolder _update;

        /// <summary>
        /// Gets the singleton class instance representing the Login element repository.
        /// </summary>
        [RepositoryFolder("5ef322c8-b0ca-474c-a89b-a70fb297402b")]
        public static Login Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Login() 
            : base("Login", "/", null, 0, false, "5ef322c8-b0ca-474c-a89b-a70fb297402b", ".\\RepositoryImages\\Login5ef322c8.rximgres")
        {
            _loginform = new LoginFolders.LoginFormAppFolder(this);
            _announcementform = new LoginFolders.AnnouncementFormAppFolder(this);
            _customerexperienceprogramform = new LoginFolders.CustomerExperienceProgramFormAppFolder(this);
            _update = new LoginFolders.UpdateAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("5ef322c8-b0ca-474c-a89b-a70fb297402b")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The LoginForm folder.
        /// </summary>
        [RepositoryFolder("ca16897b-8561-4bec-91d5-5e4caa0d49c6")]
        public virtual LoginFolders.LoginFormAppFolder LoginForm
        {
            get { return _loginform; }
        }

        /// <summary>
        /// The AnnouncementForm folder.
        /// </summary>
        [RepositoryFolder("5fb23e7f-84df-4c53-ac49-00c75ae26838")]
        public virtual LoginFolders.AnnouncementFormAppFolder AnnouncementForm
        {
            get { return _announcementform; }
        }

        /// <summary>
        /// The CustomerExperienceProgramForm folder.
        /// </summary>
        [RepositoryFolder("5b4360c6-01f7-496a-bfc3-e317aa2b2f36")]
        public virtual LoginFolders.CustomerExperienceProgramFormAppFolder CustomerExperienceProgramForm
        {
            get { return _customerexperienceprogramform; }
        }

        /// <summary>
        /// The Update folder.
        /// </summary>
        [RepositoryFolder("aee45c88-2397-4893-b4bb-380ffc9ce352")]
        public virtual LoginFolders.UpdateAppFolder Update
        {
            get { return _update; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class LoginFolders
    {
        /// <summary>
        /// The LoginFormAppFolder folder.
        /// </summary>
        [RepositoryFolder("ca16897b-8561-4bec-91d5-5e4caa0d49c6")]
        public partial class LoginFormAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _firmidInfo;
            RepoItemInfo _useridInfo;
            RepoItemInfo _pwdInfo;
            RepoItemInfo _servernameInfo;
            RepoItemInfo _cbrememberpwdInfo;
            RepoItemInfo _btncancelInfo;
            RepoItemInfo _btnloginInfo;

            /// <summary>
            /// Creates a new LoginForm  folder.
            /// </summary>
            public LoginFormAppFolder(RepoGenBaseFolder parentFolder) :
                    base("LoginForm", "/form[@controlname='LoginForm']", parentFolder, 30000, null, false, "ca16897b-8561-4bec-91d5-5e4caa0d49c6", "")
            {
                _firmidInfo = new RepoItemInfo(this, "FirmId", "?/?/text[@controlname='_firmIdTextBox']/text[@accessiblerole='Text']", 30000, null, "9e4c6d59-55df-433b-83e5-a4ec4e7d4da9");
                _useridInfo = new RepoItemInfo(this, "UserId", "?/?/text[@controlname='_userIdTextBox']/text[@accessiblerole='Text']", 30000, null, "d774919a-d017-4b3f-9b7b-81658594f693");
                _pwdInfo = new RepoItemInfo(this, "Pwd", "?/?/text[@controlname='_passwordTextBox']/text[@accessiblerole='Text']", 30000, null, "12b5793b-875f-4b2c-98e9-8c93ed55d904");
                _servernameInfo = new RepoItemInfo(this, "ServerName", "?/?/text[@controlname='txtHTTPServerName']/text[@accessiblerole='Text']", 30000, null, "419676a5-6a3e-40a7-9c79-39f21f2f3121");
                _cbrememberpwdInfo = new RepoItemInfo(this, "cbRememberPwd", "?/?/checkbox[@controlname='checkRememberMe']", 30000, null, "87311ce0-4af0-4b6e-b51b-f1667d30674c");
                _btncancelInfo = new RepoItemInfo(this, "btnCancel", "?/?/element[@controlname='btnCancel']/button[@accessiblename='Cancel']", 30000, null, "e781e2df-e56d-4aa9-b7b0-2c8f844d5a43");
                _btnloginInfo = new RepoItemInfo(this, "btnLogin", "?/?/element[@controlname='btnLogin']/button[@accessiblename='Login']", 30000, null, "adef954c-6be3-4184-8fbf-9899b8ec81b9");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("ca16897b-8561-4bec-91d5-5e4caa0d49c6")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("ca16897b-8561-4bec-91d5-5e4caa0d49c6")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The FirmId item.
            /// </summary>
            [RepositoryItem("9e4c6d59-55df-433b-83e5-a4ec4e7d4da9")]
            public virtual Ranorex.Text FirmId
            {
                get
                {
                    return _firmidInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The FirmId item info.
            /// </summary>
            [RepositoryItemInfo("9e4c6d59-55df-433b-83e5-a4ec4e7d4da9")]
            public virtual RepoItemInfo FirmIdInfo
            {
                get
                {
                    return _firmidInfo;
                }
            }

            /// <summary>
            /// The UserId item.
            /// </summary>
            [RepositoryItem("d774919a-d017-4b3f-9b7b-81658594f693")]
            public virtual Ranorex.Text UserId
            {
                get
                {
                    return _useridInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The UserId item info.
            /// </summary>
            [RepositoryItemInfo("d774919a-d017-4b3f-9b7b-81658594f693")]
            public virtual RepoItemInfo UserIdInfo
            {
                get
                {
                    return _useridInfo;
                }
            }

            /// <summary>
            /// The Pwd item.
            /// </summary>
            [RepositoryItem("12b5793b-875f-4b2c-98e9-8c93ed55d904")]
            public virtual Ranorex.Text Pwd
            {
                get
                {
                    return _pwdInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Pwd item info.
            /// </summary>
            [RepositoryItemInfo("12b5793b-875f-4b2c-98e9-8c93ed55d904")]
            public virtual RepoItemInfo PwdInfo
            {
                get
                {
                    return _pwdInfo;
                }
            }

            /// <summary>
            /// The ServerName item.
            /// </summary>
            [RepositoryItem("419676a5-6a3e-40a7-9c79-39f21f2f3121")]
            public virtual Ranorex.Text ServerName
            {
                get
                {
                    return _servernameInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The ServerName item info.
            /// </summary>
            [RepositoryItemInfo("419676a5-6a3e-40a7-9c79-39f21f2f3121")]
            public virtual RepoItemInfo ServerNameInfo
            {
                get
                {
                    return _servernameInfo;
                }
            }

            /// <summary>
            /// The cbRememberPwd item.
            /// </summary>
            [RepositoryItem("87311ce0-4af0-4b6e-b51b-f1667d30674c")]
            public virtual Ranorex.CheckBox cbRememberPwd
            {
                get
                {
                    return _cbrememberpwdInfo.CreateAdapter<Ranorex.CheckBox>(true);
                }
            }

            /// <summary>
            /// The cbRememberPwd item info.
            /// </summary>
            [RepositoryItemInfo("87311ce0-4af0-4b6e-b51b-f1667d30674c")]
            public virtual RepoItemInfo cbRememberPwdInfo
            {
                get
                {
                    return _cbrememberpwdInfo;
                }
            }

            /// <summary>
            /// The btnCancel item.
            /// </summary>
            [RepositoryItem("e781e2df-e56d-4aa9-b7b0-2c8f844d5a43")]
            public virtual Ranorex.Button btnCancel
            {
                get
                {
                    return _btncancelInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The btnCancel item info.
            /// </summary>
            [RepositoryItemInfo("e781e2df-e56d-4aa9-b7b0-2c8f844d5a43")]
            public virtual RepoItemInfo btnCancelInfo
            {
                get
                {
                    return _btncancelInfo;
                }
            }

            /// <summary>
            /// The btnLogin item.
            /// </summary>
            [RepositoryItem("adef954c-6be3-4184-8fbf-9899b8ec81b9")]
            public virtual Ranorex.Button btnLogin
            {
                get
                {
                    return _btnloginInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The btnLogin item info.
            /// </summary>
            [RepositoryItemInfo("adef954c-6be3-4184-8fbf-9899b8ec81b9")]
            public virtual RepoItemInfo btnLoginInfo
            {
                get
                {
                    return _btnloginInfo;
                }
            }
        }

        /// <summary>
        /// The AnnouncementFormAppFolder folder.
        /// </summary>
        [RepositoryFolder("5fb23e7f-84df-4c53-ac49-00c75ae26838")]
        public partial class AnnouncementFormAppFolder : RepoGenBaseFolder
        {
            LoginFolders.ToolbarToolbarBaseDesigner1Folder _toolbartoolbarbasedesigner1;
            RepoItemInfo _amicuscheckbox1Info;

            /// <summary>
            /// Creates a new AnnouncementForm  folder.
            /// </summary>
            public AnnouncementFormAppFolder(RepoGenBaseFolder parentFolder) :
                    base("AnnouncementForm", "/form[@controlname='AnnouncementForm']", parentFolder, 30000, null, false, "5fb23e7f-84df-4c53-ac49-00c75ae26838", "")
            {
                _toolbartoolbarbasedesigner1 = new LoginFolders.ToolbarToolbarBaseDesigner1Folder(this);
                _amicuscheckbox1Info = new RepoItemInfo(this, "AmicusCheckBox1", "container[@controlname='pnlBase']//checkbox[@controlname='amicusCheckBox1']", 30000, null, "c63102f6-7140-4cd0-b48b-531eca21e41e");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("5fb23e7f-84df-4c53-ac49-00c75ae26838")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("5fb23e7f-84df-4c53-ac49-00c75ae26838")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The AmicusCheckBox1 item.
            /// </summary>
            [RepositoryItem("c63102f6-7140-4cd0-b48b-531eca21e41e")]
            public virtual Ranorex.CheckBox AmicusCheckBox1
            {
                get
                {
                    return _amicuscheckbox1Info.CreateAdapter<Ranorex.CheckBox>(true);
                }
            }

            /// <summary>
            /// The AmicusCheckBox1 item info.
            /// </summary>
            [RepositoryItemInfo("c63102f6-7140-4cd0-b48b-531eca21e41e")]
            public virtual RepoItemInfo AmicusCheckBox1Info
            {
                get
                {
                    return _amicuscheckbox1Info;
                }
            }

            /// <summary>
            /// The ToolbarToolbarBaseDesigner1 folder.
            /// </summary>
            [RepositoryFolder("54b27292-56fb-423e-aa5b-fec471918b19")]
            public virtual LoginFolders.ToolbarToolbarBaseDesigner1Folder ToolbarToolbarBaseDesigner1
            {
                get { return _toolbartoolbarbasedesigner1; }
            }
        }

        /// <summary>
        /// The ToolbarToolbarBaseDesigner1Folder folder.
        /// </summary>
        [RepositoryFolder("54b27292-56fb-423e-aa5b-fec471918b19")]
        public partial class ToolbarToolbarBaseDesigner1Folder : RepoGenBaseFolder
        {
            RepoItemInfo _toolbartoolbarbasedesignerInfo;
            RepoItemInfo _btnokInfo;
            RepoItemInfo _texttoolbartoolbarbasedesignertoolsInfo;

            /// <summary>
            /// Creates a new ToolbarToolbarBaseDesigner1  folder.
            /// </summary>
            public ToolbarToolbarBaseDesigner1Folder(RepoGenBaseFolder parentFolder) :
                    base("ToolbarToolbarBaseDesigner1", "?/?/toolbar[@automationid='Toolbar : toolbarBaseDesigner']", parentFolder, 30000, null, false, "54b27292-56fb-423e-aa5b-fec471918b19", "")
            {
                _toolbartoolbarbasedesignerInfo = new RepoItemInfo(this, "ToolbarToolbarBaseDesigner", "", 30000, null, "f8621256-5586-4676-ab22-c7362c234348");
                _btnokInfo = new RepoItemInfo(this, "btnOK", "button[@automationid='[Toolbar : toolbarBaseDesigner Tools] Tool : TOOLBAR_BUTTON_OK - Index : 1 ']", 30000, null, "5f336440-bb7d-46b5-82ed-0eaacb36cdde");
                _texttoolbartoolbarbasedesignertoolsInfo = new RepoItemInfo(this, "TextToolbarToolbarBaseDesignerTools", "text[@automationid='[Toolbar : toolbarBaseDesigner Tools] Tool : TOOLBAR_ALIGN_SPRING - Index : 0 ']", 30000, null, "0d0bb2ba-a4e0-4b12-876e-0a01a4952e4d");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("54b27292-56fb-423e-aa5b-fec471918b19")]
            public virtual Ranorex.ToolBar Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.ToolBar>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("54b27292-56fb-423e-aa5b-fec471918b19")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ToolbarToolbarBaseDesigner item.
            /// </summary>
            [RepositoryItem("f8621256-5586-4676-ab22-c7362c234348")]
            public virtual Ranorex.ToolBar ToolbarToolbarBaseDesigner
            {
                get
                {
                    return _toolbartoolbarbasedesignerInfo.CreateAdapter<Ranorex.ToolBar>(true);
                }
            }

            /// <summary>
            /// The ToolbarToolbarBaseDesigner item info.
            /// </summary>
            [RepositoryItemInfo("f8621256-5586-4676-ab22-c7362c234348")]
            public virtual RepoItemInfo ToolbarToolbarBaseDesignerInfo
            {
                get
                {
                    return _toolbartoolbarbasedesignerInfo;
                }
            }

            /// <summary>
            /// The btnOK item.
            /// </summary>
            [RepositoryItem("5f336440-bb7d-46b5-82ed-0eaacb36cdde")]
            public virtual Ranorex.Button btnOK
            {
                get
                {
                    return _btnokInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The btnOK item info.
            /// </summary>
            [RepositoryItemInfo("5f336440-bb7d-46b5-82ed-0eaacb36cdde")]
            public virtual RepoItemInfo btnOKInfo
            {
                get
                {
                    return _btnokInfo;
                }
            }

            /// <summary>
            /// The TextToolbarToolbarBaseDesignerTools item.
            /// </summary>
            [RepositoryItem("0d0bb2ba-a4e0-4b12-876e-0a01a4952e4d")]
            public virtual Ranorex.Text TextToolbarToolbarBaseDesignerTools
            {
                get
                {
                    return _texttoolbartoolbarbasedesignertoolsInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The TextToolbarToolbarBaseDesignerTools item info.
            /// </summary>
            [RepositoryItemInfo("0d0bb2ba-a4e0-4b12-876e-0a01a4952e4d")]
            public virtual RepoItemInfo TextToolbarToolbarBaseDesignerToolsInfo
            {
                get
                {
                    return _texttoolbartoolbarbasedesignertoolsInfo;
                }
            }
        }

        /// <summary>
        /// The CustomerExperienceProgramFormAppFolder folder.
        /// </summary>
        [RepositoryFolder("5b4360c6-01f7-496a-bfc3-e317aa2b2f36")]
        public partial class CustomerExperienceProgramFormAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _acceptInfo;
            RepoItemInfo _declineInfo;

            /// <summary>
            /// Creates a new CustomerExperienceProgramForm  folder.
            /// </summary>
            public CustomerExperienceProgramFormAppFolder(RepoGenBaseFolder parentFolder) :
                    base("CustomerExperienceProgramForm", "/form[@controlname='CustomerExperienceProgramForm']", parentFolder, 30000, null, false, "5b4360c6-01f7-496a-bfc3-e317aa2b2f36", "")
            {
                _acceptInfo = new RepoItemInfo(this, "Accept", "container[@controlname='pnlBase']//button[@accessiblename='Accept']", 30000, null, "fb5aa2c7-cc21-4b91-92b1-fb3d435fd376");
                _declineInfo = new RepoItemInfo(this, "Decline", ".//button[@name='Decline']", 30000, null, "dd3f5840-31fa-4cae-87a6-c1560ff69f47");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("5b4360c6-01f7-496a-bfc3-e317aa2b2f36")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("5b4360c6-01f7-496a-bfc3-e317aa2b2f36")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Accept item.
            /// </summary>
            [RepositoryItem("fb5aa2c7-cc21-4b91-92b1-fb3d435fd376")]
            public virtual Ranorex.Button Accept
            {
                get
                {
                    return _acceptInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Accept item info.
            /// </summary>
            [RepositoryItemInfo("fb5aa2c7-cc21-4b91-92b1-fb3d435fd376")]
            public virtual RepoItemInfo AcceptInfo
            {
                get
                {
                    return _acceptInfo;
                }
            }

            /// <summary>
            /// The Decline item.
            /// </summary>
            [RepositoryItem("dd3f5840-31fa-4cae-87a6-c1560ff69f47")]
            public virtual Ranorex.Button Decline
            {
                get
                {
                    return _declineInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Decline item info.
            /// </summary>
            [RepositoryItemInfo("dd3f5840-31fa-4cae-87a6-c1560ff69f47")]
            public virtual RepoItemInfo DeclineInfo
            {
                get
                {
                    return _declineInfo;
                }
            }
        }

        /// <summary>
        /// The UpdateAppFolder folder.
        /// </summary>
        [RepositoryFolder("aee45c88-2397-4893-b4bb-380ffc9ce352")]
        public partial class UpdateAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _btncontinueInfo;
            RepoItemInfo _btnfinishInfo;

            /// <summary>
            /// Creates a new Update  folder.
            /// </summary>
            public UpdateAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Update", "/form[@controlname='Form1']", parentFolder, 30000, null, false, "aee45c88-2397-4893-b4bb-380ffc9ce352", "")
            {
                _btncontinueInfo = new RepoItemInfo(this, "btnContinue", "button[@controlname='button2']", 30000, null, "c9f65c85-0b07-40aa-a093-05c69c92cffa");
                _btnfinishInfo = new RepoItemInfo(this, "btnFinish", "button[@controlname='button1']", 30000, null, "d88b156e-0473-471f-8dcd-326a091a432e");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("aee45c88-2397-4893-b4bb-380ffc9ce352")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("aee45c88-2397-4893-b4bb-380ffc9ce352")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The btnContinue item.
            /// </summary>
            [RepositoryItem("c9f65c85-0b07-40aa-a093-05c69c92cffa")]
            public virtual Ranorex.Button btnContinue
            {
                get
                {
                    return _btncontinueInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The btnContinue item info.
            /// </summary>
            [RepositoryItemInfo("c9f65c85-0b07-40aa-a093-05c69c92cffa")]
            public virtual RepoItemInfo btnContinueInfo
            {
                get
                {
                    return _btncontinueInfo;
                }
            }

            /// <summary>
            /// The btnFinish item.
            /// </summary>
            [RepositoryItem("d88b156e-0473-471f-8dcd-326a091a432e")]
            public virtual Ranorex.Button btnFinish
            {
                get
                {
                    return _btnfinishInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The btnFinish item info.
            /// </summary>
            [RepositoryItemInfo("d88b156e-0473-471f-8dcd-326a091a432e")]
            public virtual RepoItemInfo btnFinishInfo
            {
                get
                {
                    return _btnfinishInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
