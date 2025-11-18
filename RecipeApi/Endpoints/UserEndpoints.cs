using RecipeApi.Models;

namespace RecipeApi.Endpoints
{
    public static class UserEndpoints
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Username = "ChefMaster", Email = "chef@example.com" },
        };

        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains('@');
        }

        public static void MapUserEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/users");

            group.MapGet("/", () => Results.Ok(users));

            group.MapGet("/{id:int}", (int id) =>
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });

            group.MapPost("/", (User newUser) =>
            {
                if (!IsValidEmail(newUser.Email))
                {
                    return Results.BadRequest("Некоректний формат Email!"); // 400
                }
                
                newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
                users.Add(newUser);
                
                return Results.Created($"/users/{newUser.Id}", newUser); // 201
            });

            group.MapPut("/{id:int}", (int id, User updatedUser) =>
            {
                var existingUser = users.FirstOrDefault(u => u.Id == id);
                if (existingUser is null) return Results.NotFound();

                existingUser.Username = updatedUser.Username;
                existingUser.Email = updatedUser.Email;
                
                return Results.Ok(existingUser); 
            });

            // DELETE
            group.MapDelete("/{id:int}", (int id) =>
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user is null) return Results.NotFound();

                users.Remove(user);
                return Results.NoContent(); 
            });
        }
    }
}