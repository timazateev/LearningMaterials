using LearningMaterials.Basics.Equality;
using LearningMaterials.Patterns.GoF.BehavioralPatterns;
using LearningMaterials.Patterns.GoF.BehavioralPatterns.ChainOfResponsibility;
using LearningMaterials.Patterns.GoF.BehavioralPatterns.Mediator;
using LearningMaterials.Patterns.GoF.BehavioralPatterns.State;
using LearningMaterials.Patterns.GoF.CreationalPatterns;
using LearningMaterials.Patterns.GRASP;
using static LearningMaterials.Patterns.GoF.CreationalPatterns.Builder;

internal class Program
{
    private static void Main(string[] args)
    {
        //var ece = new EqualsCodeExample();
        //ece.EqualsRefefence();

        //var cb = new ConcreteBuilder();
        //cb.BuildBasement();

        //ChainOfResponsibility.RunChainOfResponsibilityExample();
        //CommandExample.RunCommandExample();

        //MediatorExample.RunMediatorExample();

        StateExample.RunStateExample();
    }
}