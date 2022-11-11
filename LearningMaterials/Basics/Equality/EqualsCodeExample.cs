using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Basics.Equality
{
    // == и RefefenceEquals работает идентично, сравнивая ссылки на объекты в heap'е, а значит при выполнении данного кода
    internal class EqualsCodeExample
    {
        public void EqualsRefefence()
        {
            var obj1 = new TestClass
            {
                Count = 2
            };
            var obj2 = new TestClass
            {
                Count = 2
            };

            var obj3 = new TestClassEqualsOverride
            {
                Count = 2
            };
            var obj4 = new TestClassEqualsOverride
            {
                Count = 2
            };

            PrintResults(obj1, obj2);
            PrintResults(obj3, obj4);

            obj1 = null;
            obj2 = null;

            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(ReferenceEquals(obj1, obj2));
            Console.WriteLine(Equals(obj1, obj2));

            Console.ReadKey();
        }

        private static void PrintResults<T>(T obj1, T obj2) where T : class
        {
            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(obj1.Equals(obj2));
            Console.WriteLine(ReferenceEquals(obj1, obj2));
            Console.ReadKey();
        }
    }
    class TestClass
    {
        public int Count { get; set; }
    }

    class TestClassEqualsOverride
    {
        public int Count { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is TestClassEqualsOverride objectType)
            {
                return Count == objectType.Count;
            }
            return false;
        }
    }

    //У типа Object есть еще один статический метод static bool Equals(Object objA, Object objB)

    //public static bool Equals(Object objA, Object objB)
    //{
    //    if (objA == objB)
    //    {
    //        return true;
    //    }
    //    if (objA == null || objB == null)
    //    {
    //        return false;
    //    }
    //    return objA.Equals(objB);
    //}
}
