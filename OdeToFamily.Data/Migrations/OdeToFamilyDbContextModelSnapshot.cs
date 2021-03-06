﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OdeToFamily.Data;

namespace OdeToFamily.Data.Migrations
{
    [DbContext(typeof(OdeToFamilyDbContext))]
    partial class OdeToFamilyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OdeToFamily.Core.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Gender");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("OdeToFamily.Core.Relations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PeopleId");

                    b.Property<int>("PeopleRelateToId");

                    b.Property<int>("Relation");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.HasIndex("PeopleRelateToId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("OdeToFamily.Core.Relations", b =>
                {
                    b.HasOne("OdeToFamily.Core.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OdeToFamily.Core.People", "PeopleRelateTo")
                        .WithMany()
                        .HasForeignKey("PeopleRelateToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
