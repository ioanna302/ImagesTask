using System.ComponentModel.DataAnnotations;
namespace ImagesApp.Models
{
    public class ImageViewModel
    {

        public int Id { get; set; }

        /// <summary>
        /// The name of the image. It can be different than actual file name.
        /// </summary>
        /// 
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the image
        /// </summary>
        /// 
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public IFormFile? ImageFile { get; set; }

        public string? ImagePath { get; set; }

    }
}
