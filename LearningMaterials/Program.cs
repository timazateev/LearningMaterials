using LearningMaterials.Basics.Equality;
using LearningMaterials.Exercise;
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

        //StateExample.RunStateExample();

        //merge nodes check
        int[] fristToMerge = new int[] { 1, 3, 5, 7 };
        LinkedList<int> fristList = new LinkedList<int>(fristToMerge);

        int[] secondToMerge = new int[] { 2, 4, 6, 8 };
        LinkedList<int> secondList = new LinkedList<int>(secondToMerge);

        var twoInOne = new TwoInOne();
        var mergeResult = twoInOne.MergeFirstToSecond(fristList, secondList);

        foreach (var item in mergeResult)
        {
            Console.WriteLine(item);
        }
        //Console.ReadKey();

        //Where implementation check
        int[] dateForMyEnumeration = new int[] { 2, 4, 6, 8 };
        MyEnumeration<int> myEnumeration = new MyEnumeration<int>(dateForMyEnumeration);

        var result = MyEnumeration<int>.NewWhere(myEnumeration, i => i > 5);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();

    }
    private interface IExample
    {
        internal void RunStateExample();
        private protected int ReturnValie();
    }
}