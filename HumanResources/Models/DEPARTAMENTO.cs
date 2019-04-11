namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTAMENTOS")]
    public partial class DEPARTAMENTO
    {
        [DisplayName("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("CODIGO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CODIGO_DEPARTAMENTO { get; set; }

        [DisplayName("NOMBRE")]
        [StringLength(50)]
        public string NOMBRE { get; set; }
    }
}
