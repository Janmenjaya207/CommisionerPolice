//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommissionerPolice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileTypeId { get; set; }
        public int FileSize { get; set; }
        public string FileLocation { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ContentType { get; set; }
        public string SystemFileName { get; set; }
    
        public virtual FileType FileType { get; set; }
    }
}
