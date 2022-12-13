using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoApi.Data;
using Microsoft.EntityFrameworkCore;
using ToDoApi.ToDoItems;

namespace ToDoApi.Tests.ToDoItemTests
{
    public class BaseTest
    {
        protected IServiceProvider Services { get; set; }

        [SetUp]
        public void Setup()
        {
            Services = new ServiceCollection()
                .AddPooledDbContextFactory<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("Data Source=todo.db"))
                .AddGraphQL()
                    .AddQueryType(d => d.Name("Query"))
                        .AddTypeExtension<ToDoItemQueries>()
                    .AddMutationType(d => d.Name("Mutation"))
                        .AddTypeExtension<ToDoItemMutations>()
                    .AddFiltering()
                    .AddSorting()
                .Services
                .BuildServiceProvider();
        }
    }
}
