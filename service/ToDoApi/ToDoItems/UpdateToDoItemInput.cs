using System;
using HotChocolate;
using ToDoApi.Data;

namespace ToDoApi.ToDoItems
{
    public record UpdateToDoItemInput(
        Guid Id,
        Optional<string> Content,
        Optional<ToDoItemStatus?> Status,
        Optional<ToDoItemPriority?> Priority
    );
}
