using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Blogging.Files
{
    public class FileUploadInputDto
    {
        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public string Name { get; set; }
    }
}