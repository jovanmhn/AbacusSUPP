//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbacusSUPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Komentar
    {
        public int id { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
        public string sadrzaj { get; set; }
        public int id_task { get; set; }
        public int id_login { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual Login Login { get; set; }
    }
}
