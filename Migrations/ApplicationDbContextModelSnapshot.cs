﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NgNetCore.Data;

namespace NgNetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NgNetCore.Models.Cliente", b =>
                {
                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identidad");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NgNetCore.Models.Credito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroCuotas")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCredito")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Creditos");
                });

            modelBuilder.Entity("NgNetCore.Models.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreditoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroCuota")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoCuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCuota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreditoId");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("NgNetCore.Models.Inmueble", b =>
                {
                    b.Property<string>("NumeroMatricula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumeroMatricula");

                    b.ToTable("Inmueble");
                });

            modelBuilder.Entity("NgNetCore.Models.Ruta", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CiudadDestino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Codigo");

                    b.ToTable("Rutas");
                });

            modelBuilder.Entity("NgNetCore.Models.Credito", b =>
                {
                    b.HasOne("NgNetCore.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("NgNetCore.Models.Cuota", b =>
                {
                    b.HasOne("NgNetCore.Models.Credito", null)
                        .WithMany("Cuotas")
                        .HasForeignKey("CreditoId");
                });
#pragma warning restore 612, 618
        }
    }
}
