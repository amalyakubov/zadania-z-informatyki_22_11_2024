using System.Runtime.InteropServices;
using AnimalAPI;
using AnimalAPI.Service;
using VisitAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var animalService = new AnimalService();
var visitService = new VisitService();

/* Kod do testowania
var exampleAnimal = animalService.AddAnimal("Dog", "Mammal", 10, "Brown");
var exampleAnimal2 = animalService.AddAnimal("Cat", "Mammal", 5, "Black");
var exampleAnimal3 = animalService.AddAnimal("Bird", "Bird", 1, "Red");
var exampleAnimal4 = animalService.AddAnimal("Fish", "Fish", 0.5f, "Blue");

var exampleVisit = visitService.AddVisit(exampleAnimal.ID, DateTime.Now, "Checkup", 100);
var exampleVisit2 = visitService.AddVisit(exampleAnimal2.ID, DateTime.Now, "Checkup", 100);
*/

app.MapGet(
    "/animals/add&{name}&{category}&{mass}&{furColor}",
    (string name, string category, float mass, string furColor) =>
    {
        Animal animal = animalService.AddAnimal(name, category, mass, furColor);
        return animal.getInfo();
    }
);

app.MapGet(
    "/animals/edit&{id}&{name}&{category}&{mass}&{furColor}",
    (int id, string name, string category, float mass, string furColor) =>
    {
        var animal = new Animal(id, name, category, mass, furColor);
        animalService.EditAnimal(animal);
        return animal.getInfo();
    }
);

app.MapGet(
    "/animals/delete&{id}",
    (int id) =>
    {
        animalService.DeleteAnimal(id);
        return "Animal deleted";
    }
);

app.MapGet(
    "/animals/getAll",
    () =>
    {
        return animalService.GetAnimals();
    }
);

app.MapGet(
    "/visits/add&{animalID}&{date}&{description}&{cost}",
    (int animalID, DateTime date, string description, float cost) =>
    {
        var visit = visitService.AddVisit(animalID, date, description, cost);
        return visit;
    }
);

app.MapGet(
    "/visits/getAll",
    () =>
    {
        return visitService.GetVisits();
    }
);

app.Run();
