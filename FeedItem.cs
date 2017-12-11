using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RSS_reader
{
    [DataContract]
    class FeedItem
    {
        [DataMember]
        public string _name { get; set; }
        [DataMember]
        public string _link { get; set; }

        public FeedItem(string name,string link)
        {
            _name = name;
            _link = link;
        }
    }
}
