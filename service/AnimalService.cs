namespace AnimalAPI.Service;

public interface IAnimalService
{
    public Animal AddAnimal(string name, string category, float mass, string furColor);
}

public class AnimalService : IAnimalService
{
    private List<Animal> Animals = new();
    private int nextId = 1;

    public Animal AddAnimal(string name, string category, float mass, string furColor)
    {
        Animal animal = new Animal(nextId++, name, category, mass, furColor);
        Animals.Add(animal);
        return animal;
    }

    public List<Animal> GetAnimals()
    {
        return Animals;
    }

    public Animal GetAnimal(int ID)
    {
        return Animals.Find(animal => animal.ID == ID);
    }

    public void DeleteAnimal(int ID)
    {
        Animals.RemoveAll(animal => animal.ID == ID);
    }

    public void EditAnimal(Animal animal)
    {
        DeleteAnimal(animal.ID);
        Animals.Add(animal);
    }
}
