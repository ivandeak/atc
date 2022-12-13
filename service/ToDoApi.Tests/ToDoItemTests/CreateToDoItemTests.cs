using System;
using System.Threading.Tasks;
using HotChocolate.Execution;
using NUnit.Framework;
using Snapshooter.NUnit;

namespace ToDoApi.Tests.ToDoItemTests
{
    public class CreateToDoItemTests: BaseTest
    {
        [Test]
        public async Task CanCreateNewItem()
        {
            // act
            IExecutionResult result = await Services.ExecuteRequestAsync(
                QueryRequestBuilder.New()
                    .SetQuery(@"
                        mutation
                        {
                            createToDoItem(input: {
                                content: ""My fourth todo""
                            }) {
                                toDoItem {
                                    content
                                    createdDate
                                    id
                                    status
                                }
                            }
                        }")
                    .Create());
            
            // assert
            result.MatchSnapshot(match => match
                .IgnoreField<Guid>("Data.createToDoItem.toDoItem.id")
                .IgnoreField<DateTimeOffset>("Data.createToDoItem.toDoItem.createdDate")
            );
        }
    }
}
