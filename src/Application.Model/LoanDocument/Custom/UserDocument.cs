using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Model.LoanDocument.Custom
{
    public  class UserDocument
    {
        public int DocumentRepositoryID { get; set; }
        public string ImgName { get; set; }
        public byte[] ImgData { get; set; }
        public string ImgContentType { get; set; }
        public int ImgLength { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string IDNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
