﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using esportsMania.Context;

#nullable disable

namespace esportsMania.Migrations
{
    [DbContext(typeof(EsportsContext))]
    [Migration("20250603155043_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("esportsMania.Models.Ganadores", b =>
                {
                    b.Property<int>("IdGanador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGanador"));

                    b.Property<int>("IdJuego")
                        .HasColumnType("int");

                    b.Property<string>("NombreGanador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("IdGanador");

                    b.HasIndex("IdJuego");

                    b.ToTable("Ganadores");
                });

            modelBuilder.Entity("esportsMania.Models.Juegos", b =>
                {
                    b.Property<int>("IdJuego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJuego"));

                    b.Property<string>("NombreJuego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJuego");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("esportsMania.Models.Jugadores", b =>
                {
                    b.Property<int>("IdJugador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJugador"));

                    b.Property<int>("Asistencias")
                        .HasColumnType("int");

                    b.Property<string>("FotoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdJuego")
                        .HasColumnType("int");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<int>("Muertes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJugador");

                    b.HasIndex("IdJuego");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("esportsMania.Models.Ganadores", b =>
                {
                    b.HasOne("esportsMania.Models.Juegos", "IdJuegoNavigation")
                        .WithMany("Ganadores")
                        .HasForeignKey("IdJuego")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJuegoNavigation");
                });

            modelBuilder.Entity("esportsMania.Models.Jugadores", b =>
                {
                    b.HasOne("esportsMania.Models.Juegos", "IdJuegoNavigation")
                        .WithMany("Jugadores")
                        .HasForeignKey("IdJuego")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJuegoNavigation");
                });

            modelBuilder.Entity("esportsMania.Models.Juegos", b =>
                {
                    b.Navigation("Ganadores");

                    b.Navigation("Jugadores");
                });
#pragma warning restore 612, 618
        }
    }
}
