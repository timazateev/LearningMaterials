namespace LearningMaterials.Patterns.GoF.BehavioralPatterns
{
    /// <summary>
    /// Назначение: шаблонный метод определяет основу алгоритма и позволяет подклассам переопределять некоторые шаги алгоритма, не изменяя его структуры в целом.
    /// Другими словами: шаблонный метод — это каркас, в который наследники могут подставить реализации недостающих элементов.

    /// Когда использовать шаблонный метод?
    /// - Когда планируется, что в будущем подклассы должны будут переопределять различные этапы алгоритма без изменения его структуры
    /// - Когда в классах, реализующим схожий алгоритм, происходит дублирование кода.Вынесение общего кода в шаблонный метод уменьшит его дублирование в подклассах.
    /// </summary>
    public class TemplateMethodExapme
    {
        /// <summary>
        /// The 'AbstractClass' abstract class
        /// </summary>
        public abstract class AbstractClass
        {
            public abstract void PrimitiveOperation1();
            public abstract void PrimitiveOperation2();

            // The "Template method"
            public void TemplateMethod()
            {
                PrimitiveOperation1();
                PrimitiveOperation2();
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// A 'ConcreteClass' class
        /// </summary>
        public class ConcreteClassA : AbstractClass
        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
            }
            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
            }
        }

        /// <summary>
        /// A 'ConcreteClass' class
        /// </summary>
        public class ConcreteClassB : AbstractClass
        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
            }
            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
            }
        }
    }
}
