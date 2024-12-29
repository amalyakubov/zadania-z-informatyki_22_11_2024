namespace Lekcja8.Endpoints;
using Lekcja8.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


public static class AnimalEndpoints
{
    private static List<Animal> database = new List<Animal> {
        new Animal { Id = 1, Name = "Rex", Category = "Pies", Color = "Brown", Weight = 12 },
        new Animal { Id = 2, Name = "Max", Category = "Kot", Color = "Brown", Weight = 5 },
        new Animal { Id = 3, Name = "Fluffy", Category = "Kot", Color = "White", Weight = 4 }
    };
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/api/animals", GetAnimals);
        app.MapGet("/api/animals/{id}", GetAnimal);
        app.MapPost("/api/animals", CreateAnimal);
        app.MapPut("/api/animals/{id}", EditAnimal);
        app.MapDelete("/api/animals/{id}", DeleteAnimal);
    }

    private static IResult GetAnimals()
    {
        return Results.Ok(database);
    }

    public static IResult CreateAnimal(Animal animal)
    {
        animal.Id = database.Max(a => a.Id) + 1;
        database.Add(animal);
        return Results.Ok(animal);
    }

    private static IResult GetAnimal(int id)
    {
        var animal = database.Find(x => x.Id == id);
        if (animal == null)
            return Results.NotFound();
        return Results.Ok(animal);
    }

    private static IResult EditAnimal(int id, Animal animal)
    {
        var animalToUpdate = database.Find(x => x.Id == id);
        if (animalToUpdate == null)
        {
            return Results.NotFound();
        }
        animalToUpdate.Name = animal.Name;
        animalToUpdate.Category = animal.Category;
        animalToUpdate.Color = animal.Color;
        animalToUpdate.Weight = animal.Weight;
        return Results.Ok(animalToUpdate);
    }

    private static IResult DeleteAnimal(int id)
    {
        var animalToDelete = database.Find(x => x.Id == id);
        if (animalToDelete == null)
        {
            return Results.NotFound();
        }
        database.Remove(animalToDelete);
        return Results.Ok();
    }
}
