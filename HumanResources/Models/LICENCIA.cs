namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICENCIAS")]
    public partial class LICENCIA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("EMPLEADO")]
        [StringLength(50)]
        public string EMPLEADO { get; set; }

        [DisplayName("FECHA DE INICIO")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? FECHA_INICIO { get; set; }

        [DisplayName("FECHA DE FIN")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? FECHA_FIN { get; set; }

        [DisplayName("MOTIVO")]
        [StringLength(50)]
        public string MOTIVO { get; set; }

        [DisplayName("COMENTARIOS")]
        [StringLength(150)]
        public string COMENTARIOS { get; set; }
    }
}
