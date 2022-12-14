// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinorsoft.Core.VDbContext;

namespace Vinorsoft.Core.VDbContext.Migrations.CoreUploadDb
{
    [DbContext(typeof(CoreUploadDbContext))]
    partial class CoreUploadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinorsoft.Core.Entities.Media.CoreUploadFiles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(4000);

                    b.Property<byte[]>("FileContent");

                    b.Property<string>("FileExtension");

                    b.Property<string>("Link");

                    b.Property<string>("MimeType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<Guid>("RefId");

                    b.Property<Guid?>("TenantId");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Sys_CoreUploadFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
