//Skype logic written by Sean Mahan

using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SKYPE4COMLib;

namespace skype_test
{
    class SkypeCall
    {
        const bool DEBUG = false;
        // Controls this class, interface to use this class.
        public int StartSkypeSession(string username = "echo123", bool KillSkypeAfterSession = false, bool firstStart = false)
        {
            Skype skypeInstance = new Skype();
            
            // If error is generated starting and attaching to skype, restart the process.
            // Many times the user will not notice the allow skype connection in skype and will need to be reminded. 
            while (!AttachAndConnectToSkype(skypeInstance, firstStart))
            {
                //MessageBox.Show("General Error, check connection and allow program connection in skype");
            }

            //skype.SendMessage(username, "Hello World");
            int time = StartVideoCall(username, skypeInstance);

            if (KillSkypeAfterSession)
            {
                KillSkype();
            }

            //MessageBox.Show(time + " minutes elapsed");
            //skype.SendMessage(username, time + " minutes elapsed");
            return time;
        }
        private bool AttachAndConnectToSkype(Skype skype, bool firstStart)
        {
            if (!skype.Client.IsRunning)
            {
                // start with no splash screen
                skype.Client.Start(!firstStart, true);
            }

            // wait for the client to be ready for connection attempt, helps prevent Wait timeout error.
            

            if (firstStart)
            {
                System.Threading.Thread.Sleep(15000);
            }
            else
            {
                System.Threading.Thread.Sleep(5000);   
            }

            try
            {
                AttachToSkype(skype);
            }

            //Handle various exceptions with a catch-all at the end
            catch (System.Runtime.InteropServices.COMException e)
            {
                if (String.Compare(e.Message.Trim(), "Not attached.") == 0)
                {
                    MessageBox.Show("Please verify that you are logged in to skype and click ok");

                }
                else if (String.Compare(e.Message.Trim(), "Wait timeout.") == 0)
                {
                    MessageBox.Show("Please check skype and allow program to connect and verify internet connection");
                }
                else
                {
                    MessageBox.Show("Unhandled error: " + e.Message.Trim());
                }

                return false;
            }

            return true;
        }

        private int StartVideoCall(string username, Skype skype)
        {
            TUserStatus prevUserStatus = TUserStatus.cusUnknown;
            Call CurrentCall = null;
            try
            {
                CurrentCall = skype.PlaceCall(username);
                prevUserStatus = skype.CurrentUserStatus;
            }

            catch (System.Runtime.InteropServices.COMException e)
            {
                if (String.Compare(e.Message.Trim(), "Not online") == 0)
                {
                    MessageBox.Show("Error: Not online");
                }
                else
                {
                    MessageBox.Show("Unhandled Error: " + e.Message.Trim());
                }

                return 0;
            }

            System.Diagnostics.Stopwatch CallTimer = new System.Diagnostics.Stopwatch();

            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (CurrentCall.Status != TCallStatus.clsInProgress && CheckStatus(CurrentCall));

            if (CheckStatus(CurrentCall))
            {
                try
                {
                    CallTimer.Start();
                    CurrentCall.StartVideoSend();
                    skype.CurrentUserStatus = TUserStatus.cusDoNotDisturb;
                }

                catch (System.Runtime.InteropServices.COMException e)
                {
                    if (String.Compare(e.Message.Trim(), "CALL: Action failed") == 0)
                    {
                        if (DEBUG)
                        {
                            MessageBox.Show("Error: Video not supported");
                        }
                    }
                }
            }

            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (CheckStatus(CurrentCall));

            CallTimer.Stop();
            skype.CurrentUserStatus = prevUserStatus;

            return CallTimer.Elapsed.Minutes;
        }

        private void AttachToSkype(Skype skype)
        {
            skype.Attach(6, true);
        }

        private bool CheckStatus(Call CurrentCall)
        {
            bool status = true;
            switch (CurrentCall.Status)
            {
                case (TCallStatus.clsRefused):
                    if (DEBUG)
                        MessageBox.Show("No Answer or Call Refused");
                    status = false;
                    break;
                case (TCallStatus.clsFinished):
                    if (DEBUG)
                        MessageBox.Show("Call Finished");
                    status = false;
                    break;
                case (TCallStatus.clsFailed):
                    if (DEBUG)
                        MessageBox.Show("Call Failed");
                    status = false;
                    break;
                case (TCallStatus.clsCancelled):
                    if (DEBUG)
                        MessageBox.Show("Call Canceled");
                    status = false;
                    break;
                case (TCallStatus.clsMissed):
                    if (DEBUG)
                        MessageBox.Show("Call Missed");
                    status = false;
                    break;
                default:
                    if (DEBUG)
                        MessageBox.Show("Unhandled exception: " + CurrentCall.Status.ToString());
                    break;
            }

            return status;
        }

        public void KillSkype()
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "Skype")
                {
                    myProc.Kill();
                }
            }

        }
    }

}
