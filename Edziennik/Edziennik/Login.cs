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
    
    public partial class Login
    {
        public int ID_Person { get; set; }
        public string Login1 { get; set; }
        public string Password { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
