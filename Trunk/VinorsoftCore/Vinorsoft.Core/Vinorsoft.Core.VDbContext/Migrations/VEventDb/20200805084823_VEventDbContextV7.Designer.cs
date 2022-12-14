// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinorsoft.Core.VDbContext;

namespace Vinorsoft.Core.VDbContext.Migrations.VEventDb
{
    [DbContext(typeof(VEventDbContext))]
    [Migration("20200805084823_VEventDbContextV7")]
    partial class VEventDbContextV7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinorsoft.Core.Entities.VEvents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255);

                    b.Property<string>("DataJson")
                        .IsRequired();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<Guid?>("RefId");

                    b.Property<Guid?>("RefId1");

                    b.Property<Guid?>("RefId2");

                    b.Property<Guid?>("RefId3");

                    b.Property<Guid?>("TenantId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Sys_VEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
