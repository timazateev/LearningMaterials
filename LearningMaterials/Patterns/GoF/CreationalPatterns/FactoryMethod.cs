using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.CreationalPatterns
{
    /// <summary>
    /// Назначение: определяет интерфейс для создания объекта, но оставляет подклассам решение о том, какой класс инстанцировать. Фабричный метод позволяет классу делегировать инстанцирование подклассам.
    /// Когда следует использовать фабричный метод
    /// -Когда заранее неизвестно, объекты каких типов необходимо создавать;
    /// -Когда система должна быть независимой от процесса создания новых объектов и расширяемой: в нее можно легко вводить новые классы, объекты которых система должна создавать;
    /// -Когда создание новых объектов необходимо делегировать из базового класса классам наследникам;
    ///
    /// В объектно-ориентированных языках программирования конструктор отвечает за корректную инициализацию создаваемого объекта. В большинстве случаев они прекрасно справляются со своей задачей, но иногда лучше воспользоваться статическим фабричным методом.
    /// Именованные конструкторы.
    /// В языке C# имя конструктора совпадает с именем класса, что делает невозможным использование двух конструкторов с одним набором и типом параметров.
    /// Тяжеловесный процесс создания Лучше отдать фабричному методу
    /// </summary>
    public class FactoryMethod
    {
        static void RunFactoryMethodExample()
        {
            // An array of creators
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class Product
    {
    }

    class ConcreteProductA : Product
    {
    }

    class ConcreteProductB : Product
    {
    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
