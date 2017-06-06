using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XamarinApp.Helpers;
using XamarinApp.Model;
using XamarinApp.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

#if __IOS__
using XamarinApp.iOS;
#elif __ANDROID__
using XamarinApp.Droid;
#else
using XamarinApp.UWP.Views;
#endif

namespace XamarinApp.ViewModel
{
    public class ItemsViewModel
    {
        public ObservableRangeCollection<eBayItem> Items { get; set; }

        public ItemsViewModel()
        {
            Items = new ObservableRangeCollection<eBayItem>();

            var items = new List<eBayItem>();
            var task = ExecuteLoadItemsCommand();

        }

        public async Task ExecuteLoadItemsCommand()
        {
            XamarinApp.Services.MockDataStore ds = new MockDataStore();

            try
            {
                Items.Clear();
                var items = ds.GetItems(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }
    }
}