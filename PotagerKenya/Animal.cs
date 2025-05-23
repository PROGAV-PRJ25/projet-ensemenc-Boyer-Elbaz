public abstract class Animal
{
  public int x {get; set;} //Position de l'animal sur la grille

  public int y {get; set;}

  public string espece {get; set;}

  public Animal(string Espece)
  {
    espece = Espece;
  }

  public abstract void ApparitionAnimal(Monde monde);
}