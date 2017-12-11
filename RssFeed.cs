using System;
using System.Xml;

namespace RSS_reader
{
    class RssFeed
    {
        public string title, link, description;
        public RssItems items;

        public RssFeed(string Url)
        {
            items = new RssItems();
            XmlTextReader xmlTextReader = new XmlTextReader(Url);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlTextReader);
                xmlTextReader.Close();
                XmlNode channelXmlNode = xmlDoc.GetElementsByTagName("channel")[0];
                if (channelXmlNode != null)
                    foreach (XmlNode channelNode in channelXmlNode.ChildNodes)
                        switch (channelNode.Name)
                        {
                            case "title":
                                title = channelNode.InnerText;
                                break;
                            case "description":
                                description = channelNode.InnerText;
                                break;
                            case "link":
                                link = channelNode.InnerText;
                                break;
                            case "item":
                                RssItem channelItem = new RssItem(channelNode);
                                items.Add(channelItem);
                                break;
                        }
                else
                    throw new Exception("XML error. The channel description not found.");
            }
            catch(System.Net.WebException ex)
            { if (ex.Status == System.Net.WebExceptionStatus.NameResolutionFailure)
                    throw new Exception("Unable to connect specified source.\r\n" + Url);
                else throw ex;
            }
            catch(System.IO.FileNotFoundException)
            {
                throw new Exception(Url + " not found.");
            }
            catch(Exception ex)
            { throw ex; }
            finally
            { xmlTextReader.Close(); }
        }
    }
}
