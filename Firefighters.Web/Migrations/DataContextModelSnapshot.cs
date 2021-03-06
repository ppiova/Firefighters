﻿// <auto-generated />
using System;
using Firefighters.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firefighters.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Area", b =>
                {
                    b.Property<short>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("LlevaInventario");

                    b.HasKey("AreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Elemento", b =>
                {
                    b.Property<int>("ElementoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<short?>("AreaID");

                    b.Property<DateTime?>("BajaFecha");

                    b.Property<DateTime?>("CompraFecha");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Estado");

                    b.Property<DateTime?>("FabricacionFecha");

                    b.Property<short?>("MarcaID");

                    b.Property<short?>("ModeloID");

                    b.Property<string>("NroSerie")
                        .HasMaxLength(50);

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500);

                    b.Property<int?>("Titular");

                    b.Property<short?>("UbicacionID");

                    b.Property<DateTime?>("VencimientoFecha");

                    b.HasKey("ElementoID");

                    b.HasIndex("AreaID");

                    b.HasIndex("MarcaID");

                    b.HasIndex("ModeloID");

                    b.HasIndex("UbicacionID");

                    b.ToTable("Elementos");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.ElementoComprobante", b =>
                {
                    b.Property<int>("ElementoComprobanteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComprobanteNombre");

                    b.Property<string>("ComprobanteUrl");

                    b.Property<int?>("ElementoID");

                    b.HasKey("ElementoComprobanteId");

                    b.HasIndex("ElementoID");

                    b.ToTable("ElementoComprobantes");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.ElementoImage", b =>
                {
                    b.Property<int>("ElementoImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ElementoID");

                    b.Property<string>("ImageUrl");

                    b.HasKey("ElementoImageId");

                    b.HasIndex("ElementoID");

                    b.ToTable("ElementoImages");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Emergencia", b =>
                {
                    b.Property<short>("EmergenciaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoEmergencia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("EmergenciaID");

                    b.ToTable("Emergencias");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Localidad", b =>
                {
                    b.Property<int>("LocalidadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreLocalidad")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("LocalidadID");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Marca", b =>
                {
                    b.Property<short>("MarcaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarcaElemento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("MarcaID");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Modelo", b =>
                {
                    b.Property<short>("ModeloID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModeloElemento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ModeloID");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Siniestro", b =>
                {
                    b.Property<int>("SiniestroID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Damnificado")
                        .HasMaxLength(50);

                    b.Property<string>("Denunciante")
                        .HasMaxLength(50);

                    b.Property<string>("DirUbicación")
                        .HasMaxLength(50);

                    b.Property<short?>("EmergenciaID");

                    b.Property<DateTime>("FechaSiniestro");

                    b.Property<DateTime>("HoraSiniestro");

                    b.Property<int?>("LocalidadID");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500);

                    b.Property<string>("RutaKm")
                        .HasMaxLength(10);

                    b.Property<string>("TelDamnificado")
                        .HasMaxLength(50);

                    b.Property<string>("TelDeununciante")
                        .HasMaxLength(50);

                    b.HasKey("SiniestroID");

                    b.HasIndex("EmergenciaID");

                    b.HasIndex("LocalidadID");

                    b.ToTable("Siniestros");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.SiniestroComprobante", b =>
                {
                    b.Property<int>("SiniestroComprobanteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComprobanteUrl");

                    b.Property<int?>("SiniestroID");

                    b.Property<string>("SiniestroNombre");

                    b.HasKey("SiniestroComprobanteId");

                    b.HasIndex("SiniestroID");

                    b.ToTable("SiniestroComprobantes");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Ubicacion", b =>
                {
                    b.Property<short>("UbicacionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UbicacionElemento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("UbicacionID");

                    b.ToTable("Ubicaciones");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Elemento", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.Area", "Area")
                        .WithMany("Elementos")
                        .HasForeignKey("AreaID");

                    b.HasOne("Firefighters.Web.Data.Entities.Marca", "Marca")
                        .WithMany("Elementos")
                        .HasForeignKey("MarcaID");

                    b.HasOne("Firefighters.Web.Data.Entities.Modelo", "Modelo")
                        .WithMany("Elementos")
                        .HasForeignKey("ModeloID");

                    b.HasOne("Firefighters.Web.Data.Entities.Ubicacion", "Ubicacion")
                        .WithMany("Elementos")
                        .HasForeignKey("UbicacionID");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.ElementoComprobante", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.Elemento", "Elemento")
                        .WithMany("ElementoComprobantes")
                        .HasForeignKey("ElementoID");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.ElementoImage", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.Elemento", "Elemento")
                        .WithMany("ElementoImages")
                        .HasForeignKey("ElementoID");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.Siniestro", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.Emergencia", "Emergencia")
                        .WithMany("Siniestros")
                        .HasForeignKey("EmergenciaID");

                    b.HasOne("Firefighters.Web.Data.Entities.Localidad", "Localidad")
                        .WithMany("Siniestros")
                        .HasForeignKey("LocalidadID");
                });

            modelBuilder.Entity("Firefighters.Web.Data.Entities.SiniestroComprobante", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.Siniestro", "Siniestro")
                        .WithMany("SiniestroComprobante")
                        .HasForeignKey("SiniestroID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Firefighters.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Firefighters.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
