

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BussinessLayer
{
    public class Video
    {
        [Key]
        public string VideoId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [ForeignKey("FormatId")]
        [AllowNull]
        public string FormatId { get; set; }

        [AllowNull]
        public Format Format { get; set; }

        [AllowNull]
        public HashSet<Tag> Tags { get; set; }

        [AllowNull]
        public double? Size { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [AllowNull]
        public HashSet<Genre> Genres { get; set; }

        [AllowNull]
        public string Comment { get; set; }

        [AllowNull]
        public int? Year { get; set; }

        [AllowNull]
        public HashSet<Author> Authors { get; set; }

        [AllowNull]
        public string Copyright { get; set; }
        public Video()
        {
            VideoId = Guid.NewGuid().ToString();
            Authors = new();
            Tags = new();
            Genres = new();
        }
        public Video(string videoId, string title, string location, Format format, double size, string description, string comment, int year, string copyright) : this()
        {
            VideoId = videoId;
            Title = title;
            Location = location;
            Format = format;
            Size = size;
            Description = description;
            Comment = comment;
            Year = year;
            Copyright = copyright;
        }
    }
}