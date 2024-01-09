﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoRosty.Models;

#nullable disable

namespace ProyectoRosty.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    partial class LibreriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Bodega", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("FechaIngreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProducto");

                    b.ToTable("bodegas");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empleadosIdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("idEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<int>("rolesIdRol")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.HasIndex("empleadosIdEmpleado");

                    b.HasIndex("rolesIdRol");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Empleados", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaDeContratacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("empleados");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.GestionDeGaseosas", b =>
                {
                    b.Property<int>("IdGestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGestion"));

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaIngreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Proveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGestion");

                    b.ToTable("GestionDeGaseosas");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.RegistroDeVentas", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"));

                    b.Property<int>("BodegaIdProducto")
                        .HasColumnType("int");

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<string>("DetalleVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaDeVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GestionDeGaseosasIdGestion")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VentasDiarias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idGestion")
                        .HasColumnType("int");

                    b.Property<int>("idProducto")
                        .HasColumnType("int");

                    b.HasKey("IdVenta");

                    b.HasIndex("BodegaIdProducto");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("GestionDeGaseosasIdGestion");

                    b.ToTable("RegistroDeVentas");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<int>("rolesIdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("rolesIdRol");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Clientes", b =>
                {
                    b.HasOne("ProyectoRosty.Models.Entidades.Empleados", "empleados")
                        .WithMany()
                        .HasForeignKey("empleadosIdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoRosty.Models.Entidades.Roles", "roles")
                        .WithMany()
                        .HasForeignKey("rolesIdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empleados");

                    b.Navigation("roles");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.RegistroDeVentas", b =>
                {
                    b.HasOne("ProyectoRosty.Models.Entidades.Bodega", "Bodega")
                        .WithMany()
                        .HasForeignKey("BodegaIdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoRosty.Models.Entidades.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoRosty.Models.Entidades.GestionDeGaseosas", "GestionDeGaseosas")
                        .WithMany()
                        .HasForeignKey("GestionDeGaseosasIdGestion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bodega");

                    b.Navigation("Cliente");

                    b.Navigation("GestionDeGaseosas");
                });

            modelBuilder.Entity("ProyectoRosty.Models.Entidades.Usuarios", b =>
                {
                    b.HasOne("ProyectoRosty.Models.Entidades.Roles", "roles")
                        .WithMany()
                        .HasForeignKey("rolesIdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}
