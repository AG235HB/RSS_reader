using System;
using System.Collections.Generic;

namespace RSS_reader
{
    class RssItems:List<RssItem>
    {
        new public bool Contains(RssItem Item)
        {
            foreach(RssItem itemForCheck in this)
                if (Item.title == itemForCheck.title)
                    return true;
            return false;
        }

        public RssItem GetItem(String Title)
        {
            foreach (RssItem itemForCheck in this)
                if (itemForCheck.title == Title)
                    return itemForCheck;
            return null;
        }
    }
}
