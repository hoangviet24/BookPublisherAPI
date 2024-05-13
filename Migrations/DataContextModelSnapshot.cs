﻿// <auto-generated />
using System;
using BookPublisher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookPublisher.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookPublisher.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdList")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdList = 1,
                            Name = "Võ Hoàng Việt"
                        },
                        new
                        {
                            Id = 2,
                            IdList = 2,
                            Name = "Nguyễn Phạm Phương Linh"
                        });
                });

            modelBuilder.Entity("BookPublisher.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("DateRead")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("IdList")
                        .HasColumnType("int");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("PublishersId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublishersId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverUrl = "Hello",
                            DateAdd = new DateTime(2004, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateOnly(2024, 4, 15),
                            Description = "Chưa biết",
                            Genre = 17,
                            IdList = 0,
                            IsRead = false,
                            PublisherId = 1,
                            Rate = 4,
                            Title = "Sách hay"
                        },
                        new
                        {
                            Id = 2,
                            CoverUrl = "Hello",
                            DateAdd = new DateTime(2004, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRead = new DateOnly(2024, 4, 15),
                            Description = "Chưa biết",
                            Genre = 17,
                            IdList = 0,
                            IsRead = false,
                            PublisherId = 1,
                            Rate = 3,
                            Title = "Sách hay"
                        });
                });

            modelBuilder.Entity("BookPublisher.Models.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("idauthor")
                        .HasColumnType("int");

                    b.Property<int?>("idbook")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idauthor");

                    b.HasIndex("idbook");

                    b.ToTable("book_authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            idauthor = 1,
                            idbook = 1
                        },
                        new
                        {
                            Id = 2,
                            idauthor = 2,
                            idbook = 2
                        });
                });

            modelBuilder.Entity("BookPublisher.Models.DTO.AuthorDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorDTO");
                });

            modelBuilder.Entity("BookPublisher.Models.DTO.BookWithAuthorAndPublisherDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("DateRead")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isRead")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BookWithAuthorAndPublisherDTO");
                });

            modelBuilder.Entity("BookPublisher.Models.Publishers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Name = "NoName"
                        });
                });

            modelBuilder.Entity("BookPublisher.Models.Book", b =>
                {
                    b.HasOne("BookPublisher.Models.Publishers", "Publishers")
                        .WithMany("IdBook")
                        .HasForeignKey("PublishersId");

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("BookPublisher.Models.BookAuthor", b =>
                {
                    b.HasOne("BookPublisher.Models.Author", "Author")
                        .WithMany("Author_List")
                        .HasForeignKey("idauthor");

                    b.HasOne("BookPublisher.Models.Book", "Book")
                        .WithMany("BookList")
                        .HasForeignKey("idbook");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookPublisher.Models.Author", b =>
                {
                    b.Navigation("Author_List");
                });

            modelBuilder.Entity("BookPublisher.Models.Book", b =>
                {
                    b.Navigation("BookList");
                });

            modelBuilder.Entity("BookPublisher.Models.Publishers", b =>
                {
                    b.Navigation("IdBook");
                });
#pragma warning restore 612, 618
        }
    }
}
