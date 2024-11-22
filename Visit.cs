namespace VisitAPI;

using System;

public class Visit
{
    public int ID { get; set; }
    public int AnimalID { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public float Cost { get; set; }

    public Visit(int id, int animalID, DateTime date, string description, float cost)
    {
        ID = id;
        AnimalID = animalID;
        Date = date;
        Description = description;
        Cost = cost;
    }
}
