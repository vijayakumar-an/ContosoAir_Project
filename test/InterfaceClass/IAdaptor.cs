namespace InterfaceClass
{
    
        public interface IWebDriverAdapter
        {
            void InitializeDriver();
            void QuitDriver();
            void NavigateTo(string url);
        }
    

}
