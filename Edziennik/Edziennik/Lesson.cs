//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Edziennik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            this.Presence = new HashSet<Presence>();
        }
    
        public int ID_Lesson { get; set; }
        public int ID_Subject { get; set; }
        public Nullable<int> ID_Teacher { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Hour { get; set; }
        public Nullable<int> Number { get; set; }
        public string Topic { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Presence> Presence { get; set; }
    }
}
