using System;
using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Snapshooter.NUnit;
using ToDoApi.Data;

namespace ToDoApi.Tests.ToDoItemTests
{
    public class UpdateToDoItemTests: BaseTest
    {
        [Test]
        public async Task CanUpdateItem()
        {
            // arrange
            var dbContext = Services
                .GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
                .CreateDbContext();
            var toDoItem = new ToDoItem {
                Content = "My new todo",
                CreatedDate = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Status = ToDoItemStatus.PENDING,
            };
            dbContext.ToDoItems.Add(toDoItem);
            await dbContext.SaveChangesAsync();

            // act
            IExecutionResult result = await Services.ExecuteRequestAsync(
                QueryRequestBuilder.New()
                    .SetQuery(@"
                        mutation($id: Uuid!)
                        {
                            updateToDoItem(input: {
                                id: $id
                                content: ""My updated todo""
                            }) {
                                toDoItem {
                                    content
                                    createdDate
                                    id
                                    status
                                }
                            }
                        }")
                    .SetVariableValue("id", toDoItem.Id)
                    .Create());
            
            // assert
            result.MatchSnapshot(match => match
                .IgnoreField<Guid>("Data.updateToDoItem.toDoItem.id")
                .IgnoreField<DateTimeOffset>("Data.updateToDoItem.toDoItem.createdDate")
            );
        }
    }
}
