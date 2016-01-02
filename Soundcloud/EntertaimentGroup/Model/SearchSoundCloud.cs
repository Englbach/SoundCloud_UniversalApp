using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertaimentGroup.Model
{
    public class SearchSoundCloud
    {
        public class User
        {

            public string full_name { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public int? tracks_count { get; set; }
            public int followers_count { get; set; }
            public int followings_count { get; set; }
            public int public_favorites_count { get; set; }
            public int groups_count { get; set; }
            public string description { get; set; }
            public string plan { get; set; }
            public int id { get; set; }
            public string uri { get; set; }
            public string username { get; set; }
            public string kind { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public string first_name { get; set; }
            public string avatar_url { get; set; }
            public string last_modified { get; set; }
        }

      

        public class Collection
        {
            public User user { get; set; }
            public int user_id { get; set; }
            public string genre { get; set; }
            public string tag_list { get; set; }
            public int duration { get; set; }
            public string avatar_url { get; set; }
            public string full_name { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool downloadable { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool streamable { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int original_content_size { get; set; }
            public bool commentable { get; set; }
            public string sharing { get; set; }
            public bool @public { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string isrc { get; set; }
            public string state { get; set; }
            public bool embeddable { get; set; }
            public string embeddable_by { get; set; }
            public string license { get; set; }
            public string waveform_url { get; set; }
            public bool feedable { get; set; }
            public string label_name { get; set; }
            public string release_date { get; set; }
            public bool has_downloads_left { get; set; }
            public string purchase_title { get; set; }
            public string purchase_url { get; set; }
            public string policy { get; set; }
            public string monetization_model { get; set; }
           
            public string permalink { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string track_type { get; set; }
            public string last_modified { get; set; }
            private string _artwork_url;
            public string artwork_url
            {
                get
                {
                    return _artwork_url;
                }
                set
                {
                    if (_artwork_url != value)
                    {
                        _artwork_url = value.Replace("large", "t300x300");
                    }
                }

            }
            public int id { get; set; }
            public string kind { get; set; }
            public int? comment_count { get; set; }
            public int? download_count { get; set; }
            public string uri { get; set; }
            public string stream_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int playback_count { get; set; }
            public string download_url { get; set; }
            public object secret_token { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int reposts_count { get; set; }
            public string permalink_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? likes_count { get; set; }
        }

        public class Facet2
        {
            public string filter { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int count { get; set; }
            public string value { get; set; }
        }

        public class Facet
        {
            public string name { get; set; }
            public List<Facet2> facets { get; set; }
        }

        public class RootObject
        {
            public List<Collection> collection { get; set; }
            public List<Facet> facets { get; set; }
            public int total_results { get; set; }
            public string qid { get; set; }
            public string query_urn { get; set; }
            public string next_href { get; set; }
        }
    }
}
