using System.Collections;

namespace LearningMaterials.Patterns.GoF.CreationalPatterns
{
    /// <summary>
    /// Назначение: Строитель отделяет конструирование сложного объекта от его представления, так что в результате одного 
    /// и того же процесса конструирования могут получаться разные представления.
    /// Когда использовать паттерн Строитель?
    /// -Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот объект состоит и как эти части связаны между собой
    /// -Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания
    /// </summary>
    public class Builder
    {
        public void Build()
        {
            var cb = new ConcreteBuilder();
        }

        class Roof
        {
            public Roof()
            {
                Console.WriteLine("Крыша построена");
            }
        }
        class Basement
        {
            public Basement()
            {
                Console.WriteLine("Подвал построен");
            }
        }

        public class House
        {
            ArrayList parts = new ArrayList();

            public void Add(object part)
            {
                parts.Add(part);
            }
        }
        class Storey
        {
            public Storey()
            {
                Console.WriteLine("Этаж построен");
            }
        }

        public abstract class AbstractBuilder
        {
            public abstract void BuildBasement();
            public abstract void BuildStorey();
            public abstract void BuildRoof();
            public abstract House GetResult();
        }

        public class ConcreteBuilder : AbstractBuilder
        {
            House house = new House();

            public override void BuildBasement()
            {
                house.Add(new Basement());
            }

            public override void BuildStorey()
            {
                house.Add(new Storey());
            }

            public override void BuildRoof()
            {
                house.Add(new Roof());
            }

            public override House GetResult()
            {
                return house;
            }
        }
    }
}
