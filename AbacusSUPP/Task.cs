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
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.Komentar = new HashSet<Komentar>();
            this.VezaLT = new HashSet<VezaLT>();
        }
    
        public int id_task { get; set; }
        public int id_partner { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
        public string opis { get; set; }
        public int status_id { get; set; }
        public int prioritet_id { get; set; }
        public int login_id { get; set; }
        public string naslov { get; set; }
        public Nullable<System.DateTime> datum_zatv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komentar> Komentar { get; set; }
        public virtual Login Login { get; set; }
        public virtual Partneri Partneri { get; set; }
        public virtual Prioritet Prioritet { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VezaLT> VezaLT { get; set; }
    }
}
