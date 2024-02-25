using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SearchItem
    {
        public string SearchedString { get; set; }
        public double? SearchedNumber { get; set; }
        public Format SelectedFormat { get; set; }
        public HashSet<Author> SelectedAuthors { get; set; }
        public HashSet<Tag> SelectedTags { get; set; }
        public HashSet<Genre> SelectedGenres { get; set; }
        public SearchTextOption SelectedTextOption { get; set; }
        public SearchNumberOption SelectedNumberOption { get; set; }
        public SearchNumberComparatorOption SelectedNumberComparatorOption { get; set; }
        public SearchItem()
        {
            SelectedAuthors = new ();
            SelectedTags = new ();
            SelectedGenres = new ();
        }

        public enum SearchTextOption
        {
            None,
            Title,
            Location,
            Description,
            Comment,
            Copyright
        }

        public enum SearchNumberOption
        {
            None,
            Size,
            Year
        }
         public enum SearchNumberComparatorOption
        {
            Equal,
            Greater,
            Less
        }
    }
}
