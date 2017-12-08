using System.Xml;

namespace RSS_reader
{
    class RssItem
    {
        public string title, link, description;

        public RssItem(XmlNode ItemTag)
        {
            foreach(XmlNode xmlTag in ItemTag.ChildNodes)
            {
                switch(xmlTag.Name)
                {
                    case "title":
                        this.title = xmlTag.InnerText;
                        break;
                    case "link":
                        this.link = xmlTag.InnerText;
                        break;
                    case "description":
                        this.description = xmlTag.InnerText;
                        break;
                }
            }
        }
    }
}
