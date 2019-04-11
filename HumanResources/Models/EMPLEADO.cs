namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLEADOS")]
    public partial class EMPLEADO
    {
        [DisplayName("CODIGO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [DisplayName("CODIGO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_EMPLEADO { get; set; }

        [DisplayName("NOMBRE")]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        [DisplayName("APELLIDO")]
        [StringLength(40)]
        public string APELLIDO { get; set; }

        [DisplayName("TELEFONO")]
        [StringLength(15)]
        public string TELEFONO { get; set; }

        [DisplayName("DEPARTAMENTO")]
        [StringLength(50)]
        public string DEPARTAMENTO { get; set; }

        [DisplayName("PUESTO")]
        [StringLength(50)]
        public string CARGO { get; set; }

        [DisplayName("FECHA DE INGRESO")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public System.DateTime? FECHA_INGRESO { get; set; }

        [DisplayName("SALARIO")]
        public int? SALARIO { get; set; }

        [DisplayName("ESTATUS")]
        [StringLength(10)]
        public string STATUS_EMP { get; set; }
    }
}
