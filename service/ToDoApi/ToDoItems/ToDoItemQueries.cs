using System.Linq;
using HotChocolate.Types;
using ToDoApi.Extensions;
using ToDoApi.Data;
using HotChocolate;
using HotChocolate.Data;

namespace ToDoApi.ToDoItems
{
    [ExtendObjectType(Name = "Query")]
    public class ToDoItemQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ToDoItem> GetToDoItems(
            [ScopedService] ApplicationDbContext context) =>
            context.ToDoItems;
    }
}
