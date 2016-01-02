using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntertaimentGroup.Model
{
    public class Photos
    {
        public class Thumb
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Preview
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
            public Thumb thumb { get; set; }
            public Preview preview { get; set; }
        }

        public class Response
        {
            public int id { get; set; }
            public int bytes { get; set; }
            public string created_at { get; set; }
            public Image image { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string review_state { get; set; }
            public string uploader { get; set; }
            public int user_count { get; set; }
            public int likes_count { get; set; }
            public List<string> palette { get; set; }
            public string url { get; set; }
        }

        public class RootObject
        {
            public Response response { get; set; }
        }

    }
}
