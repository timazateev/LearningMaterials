using LearningMaterials.Basics.Equality;
using LearningMaterials.Patterns.GoF.CreationalPatterns;
using static LearningMaterials.Patterns.GoF.CreationalPatterns.Builder;

internal class Program
{
    private static void Main(string[] args)
    {
        //var ece = new EqualsCodeExample();
        //ece.EqualsRefefence();

        var cb = new ConcreteBuilder();
        cb.BuildBasement();

    }
}