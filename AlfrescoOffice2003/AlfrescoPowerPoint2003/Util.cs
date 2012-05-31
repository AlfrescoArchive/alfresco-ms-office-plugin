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
using System.Text;
using Microsoft.Win32;

namespace AlfrescoPowerPoint2003
{
   public static class Util
   {
      public static string DefaultIcon(string fileExtn)
      {
         RegistryKey rkExtn = Registry.ClassesRoot.OpenSubKey(fileExtn);
         if (rkExtn == null)
         {
            return "";
         }

         RegistryKey rkIcon = Registry.ClassesRoot.OpenSubKey(rkExtn.GetValue("") + "\\DefaultIcon");
         if (rkIcon == null)
         {
            // Try the CLSID
            RegistryKey rkCLSID = Registry.ClassesRoot.OpenSubKey(rkExtn.GetValue("") + "\\CLSID");
            if (rkCLSID == null)
            {
               return "";
            }
            rkIcon = Registry.ClassesRoot.OpenSubKey("CLSID\\" + rkCLSID.GetValue("") + "\\DefaultIcon");
            if (rkIcon == null)
            {
               return "";
            }
         }
         return rkIcon.GetValue("").ToString();
      }
   }
}
