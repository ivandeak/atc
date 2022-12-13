using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Data
{
    public enum ToDoItemStatus
    {
        PENDING,
        DOING,
        DONE
    }

    public enum ToDoItemPriority
    {
        HIGH,
        NORMAL,
        LOW
    }

    public class ToDoItem
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public ToDoItemStatus Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public ToDoItemPriority Priority { get; set; }
    }
}
