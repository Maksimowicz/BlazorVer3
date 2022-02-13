namespace SOAPService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardsTable")]
    public partial class CardsTable
    {
        [Key]
        [StringLength(20)]
        public string cardId { get; set; }

        [StringLength(141)]
        public string cardName { get; set; }

        [StringLength(10)]
        public string cmc { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [StringLength(75)]
        public string subTypes { get; set; }

        public int? powerValue { get; set; }

        public int? toughness { get; set; }

        [StringLength(11)]
        public string rarity { get; set; }

        [Column(TypeName = "text")]
        public string cardText { get; set; }
    }
}
