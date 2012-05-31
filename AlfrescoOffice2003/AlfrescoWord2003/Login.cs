/*
 * Copyright 2007-2012 Alfresco Software Limited.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * This file is part of an unsupported extension to Alfresco.
 *
 * [BRIEF DESCRIPTION OF FILE CONTENTS]
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlfrescoWord2003
{
   public partial class Login : Form
   {
      public Login()
      {
         InitializeComponent();
      }

      public string Username
      {
         get
         {
            return txtUsername.Text;
         }
         set
         {
            txtUsername.Text = value;
         }
      }

      public string Password
      {
         get
         {
            return txtPassword.Text;
         }
         set
         {
            txtPassword.Text = value;
         }
      }

      private void Login_Activated(object sender, EventArgs e)
      {
         if (txtUsername.Text.Length == 0)
         {
            this.ActiveControl = txtUsername;
         }
         else
         {
            this.ActiveControl = txtPassword;
         }
      }
   }
}