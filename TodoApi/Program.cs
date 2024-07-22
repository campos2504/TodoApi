using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

//Add DI- Add Services
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline. Use Method
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.TodoItems.ToListAsync());

app.MapGet("/todoitems/{id}", async (TodoDb db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);
    if (todo == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todo);
});

app.MapPost("/todoitems", async (TodoItem todoItem, TodoDb db) =>
{
    db.TodoItems.Add(todoItem);
    await db.SaveChangesAsync();
    return Results.Created($"/todoItems/{todoItem.Id}", todoItem);
});

app.MapPut("/todoitems/{id}", async (TodoItem todoItem, TodoDb db, int id) =>
{
    if (id != todoItem.Id) return Results.BadRequest();

    if (await db.TodoItems.FindAsync(id) == null) return Results.NotFound();
   
    db.Entry(todoItem).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (TodoDb db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);
    if (todo == null) return Results.NotFound();

    db.TodoItems.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});



app.Run();
