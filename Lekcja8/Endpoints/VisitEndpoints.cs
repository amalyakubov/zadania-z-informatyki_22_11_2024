namespace Lekcja8.Endpoints;
using Lekcja8.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


public static class VisitEndpoints
{
    private static List<Visit> database = new List<Visit> {
        new Visit { Id = 1, Date = DateTime.Now, AnimalId = 1, VisitDescription = "Visit 1", Price = 10 },
        new Visit { Id = 2, Date = DateTime.Now, AnimalId = 2, VisitDescription = "Visit 2", Price = 20 },
        new Visit { Id = 3, Date = DateTime.Now, AnimalId = 3, VisitDescription = "Visit 3", Price = 30 }
    };
    public static void MapVisitEndpoints(this WebApplication app)
    {
        app.MapGet("/api/visits", GetVisits);
        app.MapGet("/api/visits/{id}", GetVisit);
        app.MapPost("/api/visits", CreateVisit);
    }

    private static IResult GetVisits()
    {
        return Results.Ok(database);
    }

    public static IResult CreateVisit(Visit visit)
    {
        visit.Id = database.Max(x => x.Id) + 1;
        database.Add(visit);
        return Results.Ok(visit);
    }

    private static IResult GetVisit(int id)
    {
        return Results.Ok(database.Find(x => x.Id == id));
    }
}
