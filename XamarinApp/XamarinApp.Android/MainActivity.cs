using Android.App;
using Android.Widget;
using Android.OS;
using XamarinApp.Android;
using XamarinApp.Services;
using XamarinApp.Model;
using System.Collections.Generic;
using System;
using XamarinApp.Android.Adapters;

namespace XamarinApp.Droid
{
    [Activity(Label = "eBayShop", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private ListView eBayItemsListView;
        private List<eBayItem> items;
        private MockDataStore service;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            XamarinApp.Services.MockDataStore service = new MockDataStore();

            items = service.GetItems(true);

            eBayItemsListView = FindViewById<ListView>(Resource.Id.listView1);
            eBayItemsListView.Adapter = new eBayListAdapter(this, items);
            eBayItemsListView.FastScrollEnabled = true;
        }
    }
}

