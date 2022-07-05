namespace Pansiyon_UI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odalar")]
    public partial class Odalar
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Odalar()
        //{
        //    Konaklamalar = new HashSet<Konaklamalar>();
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string OdaNo { get; set; }

        public decimal Fiyat { get; set; }

        public bool MüsaitMi { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Konaklamalar> Konaklamalar { get; set; }
    }
}
