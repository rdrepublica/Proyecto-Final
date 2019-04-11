namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALIDA_EMPLEADOS
    {
        [DisplayName("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("EMPLEADO")]
        [StringLength(50)]
        public string EMPLEADO { get; set; }

        [DisplayName("TIPO DE SALIDA")]
        [StringLength(15)]
        public string TIPO_SALIDA { get; set; }

        [DisplayName("MOTIVO")]
        [StringLength(100)]
        public string MOTIVO { get; set; }

        [DisplayName("FECHA DE SALIDA")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public System.DateTime? FECHA_SALIDA { get; set; }
    }
}
