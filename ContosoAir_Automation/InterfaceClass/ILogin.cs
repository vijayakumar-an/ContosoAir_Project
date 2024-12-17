using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    // Interface for the login automation
    public interface ILoginTest
    {
        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        void NavigateToUrl(string url);

        /// <summary>
        /// Logs in with the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void PerformLoginWithCredentials(string username, string password);

        void PerformLoginWithOutCredentials();
    }
}
