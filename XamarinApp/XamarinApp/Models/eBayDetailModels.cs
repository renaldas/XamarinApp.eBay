using System.Collections.Generic;
using XamarinApp.Model;

namespace eBayDetailModels
{

    //Item detail models
    public class ConvertedCurrentPrice
    {
        public double Value { get; set; }
        public string CurrencyID { get; set; }
    }

    public class NameValueList
    {
        public string Name { get; set; }
        public List<string> Value { get; set; }
    }

    public class ItemSpecifics
    {
        public List<NameValueList> NameValueList { get; set; }
    }

    public class Item
    {
        public string Description { get; set; }
        public string ItemID { get; set; }
        public string EndTime { get; set; }
        public string ViewItemURLForNaturalSearch { get; set; }
        public string ListingType { get; set; }
        public string Location { get; set; }
        public string GalleryURL { get; set; }
        public List<string> PictureURL { get; set; }
        public string PrimaryCategoryID { get; set; }
        public string PrimaryCategoryName { get; set; }
        public int BidCount { get; set; }
        public ConvertedCurrentPrice ConvertedCurrentPrice { get; set; }
        public string ListingStatus { get; set; }
        public string TimeLeft { get; set; }
        public string Title { get; set; }
        public ItemSpecifics ItemSpecifics { get; set; }
        public string Country { get; set; }
        public bool AutoPay { get; set; }
    }

    public class RootObject
    {
        public string Timestamp { get; set; }
        public string Ack { get; set; }
        public string Build { get; set; }
        public string Version { get; set; }
        public Item Item { get; set; }
    }
}
