using ToDoApi.Data;

namespace ToDoApi.ToDoItems
{
    public record CreateToDoItemInput(
        string Content,
        ToDoItemStatus? Status,
        ToDoItemPriority? Priority
    );
}
