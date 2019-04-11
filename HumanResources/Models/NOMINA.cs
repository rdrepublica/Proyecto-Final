namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOMINA")]
    public partial class NOMINA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("AÑO")]
        public int? ANO { get; set; }

        [DisplayName("MES")]
        public int? MES { get; set; }

        [DisplayName("TOTAL DEL MES")]
        public int? MONTO_TOTAL { get; set; }
    }
}
