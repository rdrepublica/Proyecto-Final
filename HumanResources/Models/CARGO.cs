namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CARGO")]
    public partial class CARGO
    {
        [DisplayName("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("PUESTO")]
        [Column("CARGO")]
        [StringLength(50)]
        public string CARGO1 { get; set; }
    }
}
