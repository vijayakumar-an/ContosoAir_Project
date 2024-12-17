using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    public interface IHomepage
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
        void PerformLogin(string username, string password);

        void getLogo();
        /// <summary>
        /// Retrieves the title element's text.
        /// </summary>
        /// <returns>Title text</returns>
        string getTitle();

        /// <summary>
        /// Retrieves the subtitle element's text.
        /// </summary>
        /// <returns>Subtitle text</returns>
        string subTitle();

        /// <summary>
        /// Retrieves the suggestion title's text.
        /// </summary>
        /// <returns>Suggestion title text</returns>
        string getSuggestTitle();

        void checkHawaiiImage();

        string checkHawaiiCaption();

        void checkParisImage();

        string checkParisCaption();

        void checkBarcelonaImage();
        string checkBarcelonaCaption();

    }
}
