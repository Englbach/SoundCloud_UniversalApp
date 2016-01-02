using Newtonsoft.Json;
using System.Collections.Generic;

namespace EntertaimentGroup.Model
{
    public class TracksSoundCloud
    {
        public class __invalid_type__0
        {
            public string urn { get; set; }
            public int entry_time { get; set; }
            public string visual_url { get; set; }
        }

        public class Visuals2
        {
            public __invalid_type__0 __invalid_name__0 { get; set; }
        }

        public class Visuals
        {
            public string urn { get; set; }
            public bool enabled { get; set; }
            public Visuals2 visuals { get; set; }
        }

        public class User
        {
            public string urn { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public string username { get; set; }
            public string first_name { get; set; }
            public string full_name { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public int tracks_count { get; set; }
            public int followers_count { get; set; }
            public int followings_count { get; set; }
            public int public_favorites_count { get; set; }
            public int groups_count { get; set; }
            public string avatar_url { get; set; }
            public string description { get; set; }
            public string last_modified { get; set; }
            public string kind { get; set; }
            public int id { get; set; }
        }

        public class Track
        {
            public string urn { get; set; }
            public string uri { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string track_type { get; set; }
            public string genre { get; set; }
            public string tag_list { get; set; }
            public int duration { get; set; }
            public bool? downloadable { get; set; }
            public string download_url { get; set; }
            public int original_content_size { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool streamable { get; set; }
            public bool commentable { get; set; }
            public string sharing { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string isrc { get; set; }
            public string state { get; set; }
            public int? likes_count { get; set; }
            public int? playback_count { get; set; }
            public int? reposts_count { get; set; }
            public int? download_count { get; set; }
            public int? comment_count { get; set; }
            public string embeddable_by { get; set; }
            public string license { get; set; }
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
            public string stream_url { get; set; }
            public string waveform_url { get; set; }
            public string purchase_url { get; set; }
            public string purchase_title { get; set; }
            public bool reveal_comments { get; set; }
            public bool reveal_stats { get; set; }
            public bool feedable { get; set; }
            public bool geo_blocking { get; set; }
            public object geo_blockings { get; set; }
            public bool embeddable { get; set; }
            public string label_name { get; set; }
            public string release_date { get; set; }
            public object schedule { get; set; }
            public Visuals visuals { get; set; }
            public object publisher_metadata { get; set; }
            public object monetization { get; set; }
            public int user_id { get; set; }
            public User user { get; set; }
            public string policy { get; set; }
            public string monetization_model { get; set; }
            public object secret_token { get; set; }
            public object secret_uri { get; set; }
            public object publisher_state { get; set; }
            public string last_modified { get; set; }
            public object disabled_at { get; set; }
            public object disabled_reason { get; set; }
            public bool has_downloads_left { get; set; }
            public string kind { get; set; }
            public int id { get; set; }
        }

        public class RootObject
        {
            public List<Track> tracks { get; set; }
            public string tag { get; set; }
            public string next_href { get; set; }
        }
    }
}
