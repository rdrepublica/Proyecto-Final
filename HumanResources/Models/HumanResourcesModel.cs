namespace HumanResources.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HumanResourcesModel : DbContext
    {
        public HumanResourcesModel()
            : base("name=HumanRR")
        {
        }

        public virtual DbSet<CARGO> CARGOes { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTOS { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADOS { get; set; }
        public virtual DbSet<LICENCIA> LICENCIAS { get; set; }
        public virtual DbSet<NOMINA> NOMINAs { get; set; }
        public virtual DbSet<PERMISO> PERMISOS { get; set; }
        public virtual DbSet<SALIDA_EMPLEADOS> SALIDA_EMPLEADOS { get; set; }
        public virtual DbSet<VACACIONE> VACACIONES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CARGO>()
                .Property(e => e.CARGO1)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.DEPARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.STATUS_EMP)
                .IsUnicode(false);

            modelBuilder.Entity<LICENCIA>()
                .Property(e => e.EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<LICENCIA>()
                .Property(e => e.MOTIVO)
                .IsUnicode(false);

            modelBuilder.Entity<LICENCIA>()
                .Property(e => e.COMENTARIOS)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.COMENTARIOS)
                .IsUnicode(false);

            modelBuilder.Entity<SALIDA_EMPLEADOS>()
                .Property(e => e.EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<SALIDA_EMPLEADOS>()
                .Property(e => e.TIPO_SALIDA)
                .IsUnicode(false);

            modelBuilder.Entity<SALIDA_EMPLEADOS>()
                .Property(e => e.MOTIVO)
                .IsUnicode(false);

            modelBuilder.Entity<VACACIONE>()
                .Property(e => e.EMPLEADO)
                .IsUnicode(false);

            modelBuilder.Entity<VACACIONE>()
                .Property(e => e.COMENTARIOS)
                .IsUnicode(false);
        }
    }
}
