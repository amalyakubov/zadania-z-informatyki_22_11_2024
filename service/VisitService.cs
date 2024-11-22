namespace VisitAPI.Service;

public interface IVisitService
{
    public Visit AddVisit(int animalID, DateTime date, string description, float cost);
}

public class VisitService : IVisitService
{
    private List<Visit> Visits = new();
    private int nextId = 1;

    public Visit AddVisit(int animalID, DateTime date, string description, float cost)
    {
        Visit visit = new Visit(nextId++, animalID, date, description, cost);
        Visits.Add(visit);
        return visit;
    }

    public Visit GetVisit(int ID)
    {
        return Visits.Find(visit => visit.ID == ID);
    }

    public List<Visit> GetVisits()
    {
        return Visits;
    }
}
