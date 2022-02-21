//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            this.RegistrationEvents = new HashSet<RegistrationEvent>();
            this.Sponsorships = new HashSet<Sponsorship>();
        }
    
        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        public System.DateTime RegistrationDateTime { get; set; }
        public string RaceKitOptionId { get; set; }
        public byte RegistrationStatusId { get; set; }
        public decimal Cost { get; set; }
        public int CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }
    
        public virtual Charity Charity { get; set; }
        public virtual RaceKitOption RaceKitOption { get; set; }
        public virtual RegistrationStatu RegistrationStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationEvent> RegistrationEvents { get; set; }
        public virtual Runner Runner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponsorship> Sponsorships { get; set; }
    }
}
