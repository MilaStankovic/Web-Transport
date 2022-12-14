// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Web_Transport.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Isporuka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KompanijaID")
                        .HasColumnType("int");

                    b.Property<int?>("PrevozID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KompanijaID");

                    b.HasIndex("PrevozID");

                    b.ToTable("Isporuke");
                });

            modelBuilder.Entity("Models.Kompanija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProsecnaZarada")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Kompanija");
                });

            modelBuilder.Entity("Models.PrevoznoSredstvo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("KompanijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TezinaPaketa")
                        .HasColumnType("int");

                    b.Property<int>("Zapremina")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KompanijaID");

                    b.ToTable("Vozila");
                });

            modelBuilder.Entity("Models.Isporuka", b =>
                {
                    b.HasOne("Models.Kompanija", "Kompanija")
                        .WithMany("ListaIsporuka")
                        .HasForeignKey("KompanijaID");

                    b.HasOne("Models.PrevoznoSredstvo", "Prevoz")
                        .WithMany("ListaIsporuka")
                        .HasForeignKey("PrevozID");

                    b.Navigation("Kompanija");

                    b.Navigation("Prevoz");
                });

            modelBuilder.Entity("Models.PrevoznoSredstvo", b =>
                {
                    b.HasOne("Models.Kompanija", "Kompanija")
                        .WithMany("Vozila")
                        .HasForeignKey("KompanijaID");

                    b.Navigation("Kompanija");
                });

            modelBuilder.Entity("Models.Kompanija", b =>
                {
                    b.Navigation("ListaIsporuka");

                    b.Navigation("Vozila");
                });

            modelBuilder.Entity("Models.PrevoznoSredstvo", b =>
                {
                    b.Navigation("ListaIsporuka");
                });
#pragma warning restore 612, 618
        }
    }
}
