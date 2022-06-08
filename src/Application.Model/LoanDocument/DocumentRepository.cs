using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.LoanDocument
{
    [Table("DocumentRepository")]
    public class DocumentRepository
    {
        [Key]
        public int DocumentRepositoryID { get; set; }
        [Required]
        public string ImgName { get; set; }
        [Required]
        public byte[] ImgData { get; set; }
        public string ImgDataStr { get; set; }
        [Required]
        public string ImgContentType { get; set; }
        [Required]
        public int ImgLength { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedByUserID { get; set; }
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
