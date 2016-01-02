using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntertaimentGroup.Model;

namespace EntertaimentGroup.ViewModel
{
    public class CategoriesSoundCloudViewModel
    {
        ObservableCollection<CategoriesSoundCloud> MenuList = new ObservableCollection<CategoriesSoundCloud>();

        public ObservableCollection<CategoriesSoundCloud> GetCategorieslist()
        {
            MenuList.Add(new CategoriesSoundCloud { name = "Alternative Rock", link= "https://api-v2.soundcloud.com/explore/alternative+rock?tag=out-of-experiment&limit=30&linked_partitioning=1", color="#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Classical", link = "https://api-v2.soundcloud.com/explore/classical?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Country", link = "https://api-v2.soundcloud.com/explore/country?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Dance & EDM", link = "https://api-v2.soundcloud.com/explore/dance+&+edm?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Dancehall", link = "https://api-v2.soundcloud.com/explore/dancehall?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Deep House", link = "https://api-v2.soundcloud.com/explore/deep+house?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Disco", link = "https://api-v2.soundcloud.com/explore/disco?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Drum & Bass", link = "https://api-v2.soundcloud.com/explore/drum+&+bass?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Electronic", link = "https://api-v2.soundcloud.com/explore/electronic?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Hip Hop & Rap", link = "https://api-v2.soundcloud.com/explore/hip+hop+&+rap?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Pop", link = "https://api-v2.soundcloud.com/explore/pop?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Rock", link = "https://api-v2.soundcloud.com/explore/rock?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Soundtrack", link = "https://api-v2.soundcloud.com/explore/soundtrack?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Techno", link = "https://api-v2.soundcloud.com/explore/techno?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Audiobooks", link = "https://api-v2.soundcloud.com/explore/audiobooks?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Business", link = "https://api-v2.soundcloud.com/explore/business?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Comedy", link = "https://api-v2.soundcloud.com/explore/comedy?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Entertainment", link = "https://api-v2.soundcloud.com/explore/entertainment?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "New & Politics", link = "https://api-v2.soundcloud.com/explore/new+&+politics?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Science", link = "https://api-v2.soundcloud.com/explore/science?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Sports", link = "https://api-v2.soundcloud.com/explore/sports?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Storytelling", link = "https://api-v2.soundcloud.com/explore/storytelling?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });
            MenuList.Add(new CategoriesSoundCloud { name = "Technology", link = "https://api-v2.soundcloud.com/explore/technology?tag=out-of-experiment&limit=30&linked_partitioning=1", color = "#4EC920" });

            return MenuList;
        }
       
    }
}
