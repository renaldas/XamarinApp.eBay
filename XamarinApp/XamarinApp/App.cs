#if __ANDROID__
using XamarinApp.Droid;
#elif __IOS__
using XamarinApp.iOS.Helpers;
#elif WINDOWS_UWP
using XamarinApp.UWP.Helpers;
#endif
using XamarinApp.Helpers;
using XamarinApp.Interfaces;
using XamarinApp.Services;
using XamarinApp.Model;

namespace XamarinApp
{
    public partial class App 
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore, MockDataStore>();
        }
    }
}