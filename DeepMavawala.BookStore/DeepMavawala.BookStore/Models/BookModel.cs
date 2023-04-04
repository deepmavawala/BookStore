using System.ComponentModel.DataAnnotations;

namespace DeepMavawala.BookStore.Models
{
	public class BookModel
	{
        public int Id { get; set; }
		[StringLength(100,MinimumLength =5)]
		[Required(ErrorMessage ="Please enter the title of your book")]
		public string Title { get; set; }
		[Required(ErrorMessage ="Please enter the author name of your book")]
		public string Author { get; set; }
		[StringLength (500)]
		public string Description { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }
		[Display(Name ="Total pages of Book")]
		[Required(ErrorMessage ="Please enter the total pages of your book")]
		public int? TotalPages { get; set; }
	}
}
