namespace CleanArchitecture.Domain.Constants;

public static class Permissions
{
    public const string TodoView = "Permissions.Todo.View";
    public const string TodoCreate = "Permissions.Todo.Create";
    public const string TodoEdit = "Permissions.Todo.Edit";
    public const string TodoDelete = "Permissions.Todo.Delete";
    
    public static readonly string[] All = new[]
    {
        TodoView,
        TodoCreate,
        TodoEdit,
        TodoDelete
    };
}
