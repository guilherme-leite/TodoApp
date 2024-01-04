using System.ComponentModel;

namespace TodoApp.Enums
{
    public enum TodoStatus
    {
        [Description("Todo")]
        Todo = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}
