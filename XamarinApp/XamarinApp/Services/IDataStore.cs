using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Model;

namespace XamarinApp.Services
{
	public interface IDataStore
    {
        eBayItems GetItem(string id);
        List<eBayItem> GetItems(bool forceRefresh = false);
    }
}
