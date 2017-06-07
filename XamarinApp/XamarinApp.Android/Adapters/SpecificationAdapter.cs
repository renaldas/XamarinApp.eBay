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
using System.Collections.Specialized;
using eBayDetailModels;

namespace XamarinApp.Android.Adapters
{
    public class SpecificationAdapter : BaseAdapter<NameValueList>
    {
        ItemSpecifics items;
        Activity context;

        public SpecificationAdapter(Activity context, ItemSpecifics items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        
        public override NameValueList this[int position]
        {
            get
            {
                return items.NameValueList[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.NameValueList.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items.NameValueList[position];

            string val = string.Empty;

            if (item.Value != null)
            {
                val = item.Value.FirstOrDefault();
                if (item.Value.Count > 1)
                {
                    foreach (var itemVal in item.Value)
                    {
                        val += (itemVal + " ");
                    }
                }
            }

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SpecificationListRow, null);
            }
            
            convertView.FindViewById<TextView>(Resource.Id.nameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.valueTextView).Text = val;

            return convertView;
        }
    }
}