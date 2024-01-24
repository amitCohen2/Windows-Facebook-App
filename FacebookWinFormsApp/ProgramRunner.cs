using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public static class ProgramRunner
    {
        public static void run()
        {
            FormLogin loginForm;

            do
            {
                loginForm = new FormLogin();

                if (!loginForm.isUserConnected())
                {
                    Application.Run(loginForm);
                }

                if (loginForm.isUserConnected())
                {
                    Application.Run(loginForm.MainApp);
                }
            }
            while (loginForm.MainApp != null && loginForm.MainApp.IsLoggoutPressed);
        }

    }
}
