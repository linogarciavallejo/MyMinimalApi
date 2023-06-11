using Microsoft.EntityFrameworkCore;
using MyMinimalApi.Data.Models;
using MyMinimalApi.Services;
using Microsoft.AspNetCore.Builder;

namespace MyMinimalApi
{
    public static class EndpointConfiguration {
        public static IApplicationBuilder MapEndpoints(this IApplicationBuilder app) {

            //var petService = (IPetService)app.ApplicationServices.GetService(typeof(IPetService));

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/", async (IPetService petService) => {
                    return await petService.GetPets();
                });

                endpoints.MapGet("/pet/{id}", async (int id, IPetService petService) => {
                    var pet = await petService.GetPet(id);
                    return pet is not null ? Results.Ok(pet) : Results.NotFound();
                });

                endpoints.MapPost("/", async (Pet pet, IPetService petService) => {
                    var newPet = await petService.AddPet(pet);
                    return Results.Created($"/{pet.Id}", newPet);
                });
            });

            return app;
        }
    }
}
