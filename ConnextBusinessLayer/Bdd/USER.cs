//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConnextBusinessLayer.Bdd
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.PUBLICATIONs = new HashSet<PUBLICATION>();
            this.REQUEST_TRAVEL = new HashSet<REQUEST_TRAVEL>();
            this.SESSIONs = new HashSet<SESSION>();
            this.GROUPs = new HashSet<GROUP>();
        }
    
        public int ID_USER { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int ID_AGENCY { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual AGENCY AGENCY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUBLICATION> PUBLICATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUEST_TRAVEL> REQUEST_TRAVEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SESSION> SESSIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GROUP> GROUPs { get; set; }
    }
}
