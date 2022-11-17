namespace LearningMaterials.Patterns.GoF.BehavioralPatterns
{
    /// <summary>
    /// Назначение: определяет семейство алгоритмов, инкапсулирует каждый из них и делает их взаимозаменяемыми. Стратегия позволяет изменять алгоритмы независимо от клиентов, которые ими пользуются.
    /// Другими словами: стратегия инкапсулирует определенное поведение с возможностью его подмены.
    /// Когда использовать стратегию?
    /// - Когда есть несколько схожих классов , которые отличаются поведением.Можно задать один основной класс, а разные варианты поведения вынести в отдельные классы и при необходимости их применять;
    /// - Когда необходимо обеспечить выбор из нескольких вариантов решений, которые можно легко менять в зависимости от условий;
    /// - Когда необходимо менять поведение классов и объектов на стадии выполнения программы;
    /// - Когда класс, применяющий определенную функциональность, ничего не должен знать о ее реализации
    /// </summary>
    public class StrategyExample
    {
        /// <summary>
        /// The 'Strategy' abstract class
        /// </summary>
        public abstract class Strategy
        {
            public abstract void AlgorithmInterface();
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyA : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                  "Called ConcreteStrategyA.AlgorithmInterface()");
            }
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyB : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                  "Called ConcreteStrategyB.AlgorithmInterface()");
            }
        }

        /// <summary>
        /// A 'ConcreteStrategy' class
        /// </summary>
        public class ConcreteStrategyC : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                  "Called ConcreteStrategyC.AlgorithmInterface()");
            }
        }

        /// <summary>
        /// The 'Context' class
        /// </summary>
        public class Context
        {
            private readonly Strategy _strategy;

            // Constructor
            public Context(Strategy strategy)
            {
                _strategy = strategy;
            }

            public void ContextInterface()
            {
                _strategy.AlgorithmInterface();
            }
        }
    }
}
