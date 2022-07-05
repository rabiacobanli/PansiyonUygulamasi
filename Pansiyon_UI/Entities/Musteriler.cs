namespace Pansiyon_UI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteriler")]
    public partial class Musteriler
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Musteriler()
        //{
        //    Konaklamalar = new HashSet<Konaklamalar>();
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string TcNo { get; set; }

        [Required]
        [StringLength(20)]
        public string Ad { get; set; }

        [Required]
        [StringLength(20)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }

        public string Email { get; set; }

        [StringLength(5)]
        public string Cinsiyet { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Konaklamalar> Konaklamalar { get; set; }
    }
}
