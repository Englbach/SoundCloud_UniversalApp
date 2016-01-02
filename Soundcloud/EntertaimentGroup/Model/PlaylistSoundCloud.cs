using Newtonsoft.Json;
using System.Collections.Generic;

namespace EntertaimentGroup.Model
{
    public class PlaylistSoundCloud
    {
        public class User
        {
            public int id { get; set; }
            public string kind { get; set; }
            public string permalink { get; set; }
            public string username { get; set; }
            public string last_modified { get; set; }
            public string uri { get; set; }
            public string permalink_url { get; set; }
            public string avatar_url { get; set; }
        }

        public class CreatedWith
        {
            public int id { get; set; }
            public string kind { get; set; }
            public string name { get; set; }
            public string uri { get; set; }
            public string permalink_url { get; set; }
            public string external_url { get; set; }
        }

        public class Track
        {
            public string kind { get; set; }
            public int id { get; set; }
            public string created_at { get; set; }
            public int user_id { get; set; }
            public int duration { get; set; }
            public bool commentable { get; set; }
            public string state { get; set; }
            public int original_content_size { get; set; }
            public string last_modified { get; set; }
            public string sharing { get; set; }
            public string tag_list { get; set; }
            public string permalink { get; set; }

            public string embeddable_by { get; set; }
            public bool downloadable { get; set; }
            public object purchase_url { get; set; }
            public object label_id { get; set; }
            public object purchase_title { get; set; }
            public string genre { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string label_name { get; set; }
            public string release { get; set; }
            public string track_type { get; set; }
            public string key_signature { get; set; }
            public string isrc { get; set; }
            public object video_url { get; set; }
            public object bpm { get; set; }
            public object release_year { get; set; }
            public object release_month { get; set; }
            public object release_day { get; set; }
            public string original_format { get; set; }
            public string license { get; set; }
            public string uri { get; set; }
            public User user { get; set; }
            public string permalink_url { get; set; }
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
            public string waveform_url { get; set; }
            public string stream_url { get; set; }
            public int playback_count { get; set; }
            public int download_count { get; set; }
            public int favoritings_count { get; set; }
            public int comment_count { get; set; }
            public int likes_count { get; set; }
            public int reposts_count { get; set; }
            public string attachments_uri { get; set; }
            public string policy { get; set; }
            public string monetization_model { get; set; }
            public string download_url { get; set; }
            public CreatedWith created_with { get; set; }
        }

        public class CreatedWith2
        {
            public string permalink_url { get; set; }
            public string name { get; set; }
            public string external_url { get; set; }
            public string uri { get; set; }
            public string creator { get; set; }
            public int id { get; set; }
            public string kind { get; set; }
        }

        public class User2
        {
            public string permalink_url { get; set; }
            public string permalink { get; set; }
            public string username { get; set; }
            public string uri { get; set; }
            public string last_modified { get; set; }
            public int id { get; set; }
            public string kind { get; set; }
            public string avatar_url { get; set; }
        }

        public class RootObject
        {
            public int duration { get; set; }
            public object release_day { get; set; }
            public string permalink_url { get; set; }
            public int reposts_count { get; set; }
            public object genre { get; set; }
            public string permalink { get; set; }
            public object purchase_url { get; set; }
            public object release_month { get; set; }
            public object description { get; set; }
            public string uri { get; set; }
            public object label_name { get; set; }
            public string tag_list { get; set; }
            public object release_year { get; set; }
            public int track_count { get; set; }
            public int user_id { get; set; }
            public string last_modified { get; set; }
            public string license { get; set; }
            public List<Track> tracks { get; set; }
            public object playlist_type { get; set; }
            public int id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object downloadable { get; set; }
            public string sharing { get; set; }
            public string created_at { get; set; }
            public object release { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int likes_count { get; set; }
            public string kind { get; set; }
            public string title { get; set; }
            public object type { get; set; }
            public object purchase_title { get; set; }
            public CreatedWith2 created_with { get; set; }
            public object artwork_url { get; set; }
            public object ean { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Include)]

            public User2 user { get; set; }
            public string embeddable_by { get; set; }
            public object label_id { get; set; }
        }
    }
}
