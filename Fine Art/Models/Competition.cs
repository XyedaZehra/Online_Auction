//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fine_Art.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            this.Awards = new HashSet<Award>();
            this.Student_Academic_Record = new HashSet<Student_Academic_Record>();
        }
    
        public int C_Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string C_description { get; set; }
        public Nullable<long> Price { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string S_Id { get; set; }
        public Nullable<int> Competition_Name { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Award> Awards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Academic_Record> Student_Academic_Record { get; set; }
    }
}
