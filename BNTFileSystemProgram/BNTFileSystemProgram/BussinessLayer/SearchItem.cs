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
        public List<Author> SelectedAuthors { get; set; }
        public List<Genre> SelectedGenres { get; set; }
        public List<Tag> SelectedTags { get; set; }
        public SearchTextOption SelectedTextOption { get; set; }
        public SearchNumberOption SearchedNumberOption { get; set; }

        public SearchItem()
        {
            SelectedAuthors = new List<Author>();
            SelectedTags = new List<Tag>();
            SelectedGenres = new List<Genre>();
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

    }
}
