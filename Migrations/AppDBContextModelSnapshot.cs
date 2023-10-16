﻿// <auto-generated />
using System;
using ClsOutDocDeliveryCtrl.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClsOutDocDeliveryCtrl.Entities.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<DateTime?>("ActFirstCTRSubmitDeadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActFirstCTRSubmitDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActFirstConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActOwnerSubmitDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActSecondCTRSubmitDeadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActSecondCTRSubmitDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActSecondConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActThirdCTRSubmitDeadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActThirdCTRSubmitDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActThirdConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConsultFirstRspCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsultFirstRspStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsultSecondRspCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsultSecondRspStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsultThirdRspCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConsultThirdRspStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpFirstConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpSecondConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpThirdConsultRspDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstCTRSubmitStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OwnerSubmitFormat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerSubmitStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("RcmdDeadlineAfterHandover")
                        .HasColumnType("int");

                    b.Property<int?>("RcmdDeadlineBeforeHandover")
                        .HasColumnType("int");

                    b.Property<string>("ReceivedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecondCTRSubmitStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StoragePlace")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ThirdCTRSubmitStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TotalDeduction")
                        .HasColumnType("decimal(5, 4)");

                    b.Property<decimal?>("TotalRetention")
                        .HasColumnType("decimal(5, 4)");

                    b.HasKey("DocumentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("Name", "ProjectId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ClsOutDocDeliveryCtrl.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ConsultantName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ConsultantReviewTimeInDays")
                        .HasColumnType("int");

                    b.Property<decimal>("ContractValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ContractorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PlannedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ClsOutDocDeliveryCtrl.Entities.Document", b =>
                {
                    b.HasOne("ClsOutDocDeliveryCtrl.Entities.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ClsOutDocDeliveryCtrl.Entities.Project", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
