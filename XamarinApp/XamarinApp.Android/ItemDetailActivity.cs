using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinApp.Android
{
    [Activity(Label = "ItemDetailActivity")]
    public class ItemDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemDetail);

            var selectedItemId = Intent.Extras.GetString("selectedeBayId");

            var eBayIdText = FindViewById<TextView>(Resource.Id.eBayIdText);

            eBayIdText.Text = selectedItemId;
            //my branch
        }
    }
}