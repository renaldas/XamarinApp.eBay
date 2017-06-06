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
using XamarinApp.Model;
using XamarinApp.Helpers;

namespace XamarinApp.Android.Adapters
{
    public class eBayListAdapter : BaseAdapter<eBayItem>
    {
        List<eBayItem> items;
        Activity context;

        public eBayListAdapter(Activity context, List<eBayItem> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        
        public override eBayItem this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.eBayListRow, null);
            }

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(item.galleryURL.FirstOrDefault());

            convertView.FindViewById<TextView>(Resource.Id.nameTextView).Text = item.title.FirstOrDefault();
            convertView.FindViewById<TextView>(Resource.Id.descriptionTextView).Text = item.itemId.FirstOrDefault();
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "£" + item.sellingStatus.FirstOrDefault().currentPrice.FirstOrDefault().__value__;
            convertView.FindViewById<ImageView>(Resource.Id.imageView).SetImageBitmap(imageBitmap);

            return convertView;
        }
    }
}