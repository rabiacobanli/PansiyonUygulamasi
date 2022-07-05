namespace Pansiyon_UI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Konaklamalar")]
    public partial class Konaklamalar
    {
        public int Id { get; set; }

        public int MusteriId { get; set; }

        public int OdaId { get; set; }

        public DateTime GirisTarihi { get; set; }

        public DateTime CikisTarihi { get; set; }

        public decimal ToplamFiyat { get; set; }

        public bool AktifMi { get; set; }

        //public virtual Musteriler Musteriler { get; set; }

        //public virtual Odalar Odalar { get; set; }
    }
}
