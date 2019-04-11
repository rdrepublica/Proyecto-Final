namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISOS")]
    public partial class PERMISO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("EMPLEADO")]
        [StringLength(50)]
        public string EMPLEADO { get; set; }

        [DisplayName("FECHA DE INICIO")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public System.DateTime? FECHA_INICIO { get; set; }

        [DisplayName("FECHA DE FIN")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public System.DateTime? FECHA_FIN { get; set; }

        [DisplayName("COMENTARIOS")]
        [StringLength(150)]
        public string COMENTARIOS { get; set; }
    }
}
