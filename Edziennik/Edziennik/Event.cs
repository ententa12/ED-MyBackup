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
    
    public partial class Event
    {
        public int ID_Event { get; set; }
        public Nullable<int> ID_Class { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    
        public virtual Class Class { get; set; }
    }
}