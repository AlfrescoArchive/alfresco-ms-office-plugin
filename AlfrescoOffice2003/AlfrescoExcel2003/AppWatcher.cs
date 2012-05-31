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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace AlfrescoExcel2003
{
   public delegate void WindowHasFocus(int hwnd);
   public delegate void WindowLostFocus(int hwnd);

   public class AppWatcher
   {
      // Public events
      public event WindowHasFocus OnWindowHasFocus;
      public event WindowLostFocus OnWindowLostFocus;

      // Private member variables
      private static BackgroundWorker m_Worker;
      private int m_hwnd = -1;
      private int m_hwndAlfresco = -1;
      private bool m_shouldHaveFocus = true;

      // Win32 SDK functions
      [DllImport("user32.dll")]
      public static extern int GetForegroundWindow();

      public void Start(int hwndApp)
      {
         m_hwnd = hwndApp;
         m_Worker = new BackgroundWorker();
         m_Worker.WorkerSupportsCancellation = true;
         m_Worker.DoWork += new DoWorkEventHandler(AppWatcherProc);
         m_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WindowFocusChanged);
         m_Worker.RunWorkerAsync(hwndApp);
      }

      public int AlfrescoWindow
      {
         set
         {
            m_hwndAlfresco = value;
         }
      }

      ~AppWatcher()
      {
         if ((m_Worker != null) && (m_Worker.IsBusy))
         {
            m_Worker.CancelAsync();
         }
      }

      void WindowFocusChanged(object sender, RunWorkerCompletedEventArgs e)
      {
         if (!e.Cancelled)
         {
            // Store what state we think the focus should be for next time
            m_shouldHaveFocus = (bool)e.Result;

            if (m_shouldHaveFocus)
            {
               // Window now has focus
               if (OnWindowHasFocus != null)
               {
                  OnWindowHasFocus(m_hwnd);
               }
            }
            else
            {
               // Window has lost focus
               if (OnWindowLostFocus != null)
               {
                  OnWindowLostFocus(m_hwnd);
               }
            }

            // Restart the worker
            m_Worker.RunWorkerAsync(m_hwnd);
         }
      }

      void AppWatcherProc(object sender, DoWorkEventArgs e)
      {
         int hwndFocus = GetForegroundWindow();
         bool initialFocus = ((m_hwnd == hwndFocus) || (m_hwndAlfresco == hwndFocus));

         // Does the focus look how we expect it to?
         if (initialFocus != m_shouldHaveFocus)
         {
            // No - return the actual focus state
            e.Result = initialFocus;
            return;
         }

         while (!m_Worker.CancellationPending)
         {
            // Does watched window have focus?
            hwndFocus = GetForegroundWindow();
            if ((m_hwnd == hwndFocus) || (m_hwndAlfresco == hwndFocus))
            {
               // Yes - has it changed from initial state
               if (!initialFocus)
               {
                  // App now has focus - return true
                  e.Result = true;
                  return;
               }
            }
            else
            {
               // No - did it used to have focus?
               if (initialFocus)
               {
                  // App just lost focus - return false
                  e.Result = false;
                  return;
               }
            }
            Thread.Sleep(250);
         }

         e.Cancel = m_Worker.CancellationPending;
         return;
      }
   }
}
