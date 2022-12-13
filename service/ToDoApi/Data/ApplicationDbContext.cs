using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ToDoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ToDoItem> ToDoItems { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.Property(ptp => ptp.Status)
                    .HasConversion(new EnumToStringConverter<ToDoItemStatus>())
                    .HasMaxLength(100);

                entity.Property(ptp => ptp.CreatedDate);

                entity.HasData(
                    new ToDoItem {
                        Content = "Finish up work on latest feature",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:55.593Z"),
                        Id = Guid.Parse("35bbef832b664d94b1b6075b5172868f"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Make a bitmoji",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:53.593Z"),
                        Id = Guid.Parse("38560f1d83aa4824a39df81b2ac4ae81"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Buy bread",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:51.593Z"),
                        Id = Guid.Parse("e404faa17a0641d287b87ddfb9e7300c"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Follow up with Sam RE Friday night",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:49.593Z"),
                        Id = Guid.Parse("cf18518288c14413969d733cea151b1a"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Cat flea treatment",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:45.326Z"),
                        Id = Guid.Parse("eb60226cf9a044fc887cec98ce39f433"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Daily walk",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:42.087Z"),
                        Id = Guid.Parse("cc552a5da3e44e5ebcb03ec3d249a3f9"),
                        Status = ToDoItemStatus.PENDING
                    },
                    new ToDoItem {
                        Content = "Take out the rubbish",
                        CreatedDate = DateTimeOffset.Parse("2021-02-16T22:39:34.598Z"),
                        Id = Guid.Parse("ad35676c81a048c38af64d8dd41671f0"),
                        Status = ToDoItemStatus.DONE
                    }
                );
            });

            // thanks to https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/ for this
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }
    }
}
