using Newtonsoft.Json;
using System.Collections.Generic;

namespace EntertaimentGroup.Model
{
    public class UserSoundCloud
    {

        public class Visual
        {
            public string urn { get; set; }
            public int entry_time { get; set; }
            public string visual_url { get; set; }
        }

        public class Visuals
        {
            public string urn { get; set; }
            public bool enabled { get; set; }
            public List<Visual> visuals { get; set; }
        }

        public class Product
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class CreatorSubscription
        {
            public Product product { get; set; }
            public bool recurring { get; set; }
        }

        public class Visual2
        {
            public string urn { get; set; }
            public int entry_time { get; set; }
            public string visual_url { get; set; }
        }

        public class Visuals2
        {
            public string urn { get; set; }
            public bool enabled { get; set; }
            public List<Visual2> visuals { get; set; }
        }

        public class User
        {
            public string avatar_url { get; set; }
            public string city { get; set; }
            public int comments_count { get; set; }
            public string country_code { get; set; }
            public List<CreatorSubscription> creator_subscriptions { get; set; }
            public string description { get; set; }
            public int followers_count { get; set; }
            public int followings_count { get; set; }
            public string first_name { get; set; }
            public string full_name { get; set; }
            public int groups_count { get; set; }
            public int id { get; set; }
            public string kind { get; set; }
            public string last_modified { get; set; }
            public string last_name { get; set; }
            public int likes_count { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public int playlist_count { get; set; }
            public int reposts_count { get; set; }
            public int track_count { get; set; }
            public string uri { get; set; }
            public string urn { get; set; }
            public string username { get; set; }
            public bool verified { get; set; }
            public Visuals2 visuals { get; set; }
        }

        public class Product2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class CreatorSubscription2
        {
            public Product2 product { get; set; }
            public bool recurring { get; set; }
        }

        public class Track
        {
            public int id { get; set; }
            public string kind { get; set; }
        }

        public class Collection
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string artwork_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool commentable { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int comment_count { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string created_at { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string description { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool downloadable { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int download_count { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string download_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int duration { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int full_duration { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string embeddable_by { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string genre { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool has_downloads_left { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string kind { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string label_name { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string last_modified { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string license { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int likes_count { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int original_content_size { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string permalink { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string permalink_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int playback_count { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool @public { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object publisher_metadata { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object purchase_title { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object purchase_url { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string release_date { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? reposts_count { get; set; }
            public object secret_token { get; set; }
            public string sharing { get; set; }
            public string state { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool streamable { get; set; }
            public string tag_list { get; set; }
            public string title { get; set; }
            public string uri { get; set; }
            public string urn { get; set; }
            public int user_id { get; set; }
            public Visuals visuals { get; set; }
            public string waveform_url { get; set; }
            public string monetization_model { get; set; }
            public string policy { get; set; }
            public User user { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string avatar_url { get; set; }
            public string city { get; set; }
            public int? comments_count { get; set; }
            public string country_code { get; set; }
            public List<CreatorSubscription2> creator_subscriptions { get; set; }
            public int? followers_count { get; set; }
            public int? followings_count { get; set; }
            public string first_name { get; set; }
            public string full_name { get; set; }
            public int? groups_count { get; set; }
            public string last_name { get; set; }
            public int? playlist_count { get; set; }
            public int? track_count { get; set; }
            public string username { get; set; }
            public string stream_url { get; set; }
            public bool? verified { get; set; }
            public List<Track> tracks { get; set; }
        }

        public class Facet2
        {
            public string value { get; set; }
            public int count { get; set; }
            public string filter { get; set; }
        }

        public class Facet
        {
            public string name { get; set; }
            public List<Facet2> facets { get; set; }
        }

        public class RootObject
        {
            public List<Collection> collection { get; set; }
            public int total_results { get; set; }
            public List<Facet> facets { get; set; }
            public string next_href { get; set; }
            public string query_urn { get; set; }
        }

    }
}
