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
    
    public partial class Podesavanja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Podesavanja()
        {
            this.Login = new HashSet<Login>();
        }
    
        public int id_podesavanja { get; set; }
        public bool minimize_notif { get; set; }
        public bool minimize_tray { get; set; }
        public bool novitask_notif { get; set; }
        public bool novikom_notif { get; set; }
        public bool task_novi_prozor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Login { get; set; }
    }
}
