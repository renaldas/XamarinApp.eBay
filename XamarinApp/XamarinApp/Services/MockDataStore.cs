﻿using eBayDetailModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinApp.Helpers;
using XamarinApp.Model;

namespace XamarinApp.Services
{
    public class MockDataStore : IDataStore
    {
		public eBayDetailModels.Item GetItem(string id)
		{
            string appId = AppConfig.GetEBayAppName();

            var item = new eBayDetailModels.Item();
            string requestUrl = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=" + appId + "&siteid=3&version=515&IncludeSelector=Compatibility,ItemSpecifics,%20Description&ItemID=" + id;

            WebClient client = new WebClient();
            var contents = client.DownloadString(requestUrl);

            var result = JsonConvert.DeserializeObject<RootObject>(contents);

            return result.Item;
        }

        public List<eBayItem> GetItems(bool forceRefresh = false)
        {
            string appId = AppConfig.GetEBayAppName();

            var items = new List<eBayItem>();
            string requestUrl = "http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findItemsAdvanced&SERVICE-VERSION=1.13.0&SECURITY-APPNAME=" + appId + "&GLOBAL-ID=EBAY-GB&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&categoryId=179681&itemFilter(0).name=Seller&itemFilter(0).value=tgc_automotive&itemFilter(1).name=sellingStatus.sellingState&itemFilter(1).value=active&paginationInput.entriesPerPage=40&paginationInput.pageNumber=1";
            WebClient client = new WebClient();
            var contents = client.DownloadString(requestUrl);

            var securities = JsonConvert.DeserializeObject<eBayItems>(contents);

            if (securities.findItemsAdvancedResponse.Count > 0)
            {
                if (securities.findItemsAdvancedResponse.FirstOrDefault().ack.FirstOrDefault() == "Success")
                {
                        items.AddRange(securities.findItemsAdvancedResponse.FirstOrDefault().searchResult.FirstOrDefault().item);        
                }
            }

            return items;
        }
    }
}