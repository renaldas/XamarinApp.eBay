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
using XamarinApp.Services;
using XamarinApp.Helpers;
using XamarinApp.Android.Adapters;
using Android.Util;

namespace XamarinApp.Android
{
    [Activity(Label = "Product description")]
    public class ItemDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemDetail);

            var selectedItemId = Intent.Extras.GetString("selectedeBayId");

            MockDataStore mds = new MockDataStore();
            
            var ebayItemDetails = mds.GetItem(selectedItemId.ToString());
            
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(ebayItemDetails.GalleryURL);

            //Whole Html in here
            //FindViewById<TextView>(Resource.Id.description).Text = ebayItemDetails.Description;

            FindViewById<TextView>(Resource.Id.title).Text = ebayItemDetails.Title;
            FindViewById<TextView>(Resource.Id.price).Text = "PRICE " + ebayItemDetails.ConvertedCurrentPrice.Value + " " + ebayItemDetails.ConvertedCurrentPrice.CurrencyID;

            if (imageBitmap != null)
            {
                var imgView = FindViewById<ImageView>(Resource.Id.imageView);
                imgView.SetImageBitmap(imageBitmap);

                DisplayMetrics mets = new DisplayMetrics();
                WindowManager.DefaultDisplay.GetMetrics(mets);
                double viewWidthToBitmapWidthRatio = (double)mets.WidthPixels / (double)imageBitmap.Width;
                imgView.LayoutParameters.Height = (int)(imageBitmap.Height * viewWidthToBitmapWidthRatio);
            }

            if (ebayItemDetails.ItemSpecifics.NameValueList != null) { 
                ListView specificationListView = FindViewById<ListView>(Resource.Id.specificatonListView);
                specificationListView.Adapter = new SpecificationAdapter(this, ebayItemDetails.ItemSpecifics);
                specificationListView.FastScrollEnabled = true;
            }
        }
    }
}
