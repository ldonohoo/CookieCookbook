

public abstract class Ingredient
{
    public abstract int Id { get; }
    public virtual string Name => "An unnamed cookie ingredient";
    public abstract string Instructions { get; }
    public override string ToString() => Instructions;
    public void Print() => Console.WriteLine($"{Id}. {Name}");
}

public class Flour : Ingredient
{
    public override int Id { get; } = 1;
    public override string Name { get; } = "Flour";
    public override string Instructions { get; } = "Measure and sift flour, then add";
}

public class Sugar : Ingredient
{
    public override int Id { get; } = 2;
    public override string Name { get; } = "Sugar";
     public override string Instructions { get; } = "Measure and add sugar";
}
public class Eggs : Ingredient
{
    public override int Id { get; } = 3;
    public override string Name { get; } = "Eggs";
     public override string Instructions { get; } = "Crack eggs and add";
}
public class Butter : Ingredient
{
    public override int Id { get; } = 4;
    public override string Name { get; } = "Butter";
     public override string Instructions { get; } = "Soften butter and stir in";
}
public class BakingPowder : Ingredient
{
    public override int Id { get; } = 5;
    public override string Name { get; } = "Baking Powder";
     public override string Instructions { get; } = "Measure and stir in";
}
public class Vanilla : Ingredient
{
    public override int Id { get; } = 6;
    public override string Name { get; } = "Vanilla";
     public override string Instructions { get; } = "Measure and pour in";
}
public class ChocolateChips : Ingredient
{
    public override int Id { get; } = 7;
    public override string Name { get; } = "Chocolate Chips";
     public override string Instructions { get; } = "Measure and stir in";
}
