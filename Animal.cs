namespace AnimalAPI;

public class Animal
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public float Mass { get; set; }
    public string FurColor { get; set; }

    public Animal(int id, string name, string category, float mass, string furColor)
    {
        ID = id;
        Name = name;
        Category = category;
        Mass = mass;
        FurColor = furColor;
    }

    public string getInfo()
    {
        return $"Animal: {Name}, Category: {Category}, Mass: {Mass}, Fur Color: {FurColor}";
    }
}
