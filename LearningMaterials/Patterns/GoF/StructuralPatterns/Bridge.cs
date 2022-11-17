namespace LearningMaterials.Patterns.GoF.StructuralPatterns.Bridge
{
    /// <summary>
    /// Мост (Bridge) - структурный шаблон проектирования, который позволяет отделить абстракцию от реализации таким образом, 
    /// чтобы и абстракцию, и реализацию можно было изменять независимо друг от друга.
    /// Когда использовать паттерн мост?
    /// -Когда надо избежать постоянной привязки абстракции к реализации
    /// -Когда наряду с реализацией надо изменять и абстракцию независимо друг от друга.То есть изменения в абстракции не должно привести к изменениям в реализации
    /// </summary>
    class BridgeClient
    {
        static void RunBridgeExample()
        {
            Abstraction abstraction;
            abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }
    abstract class Abstraction
    {
        protected Implementor implementor;
        public Implementor Implementor
        {
            set { implementor = value; }
        }
        public Abstraction(Implementor imp)
        {
            implementor = imp;
        }
        public virtual void Operation()
        {
            implementor.OperationImp();
        }
    }

    abstract class Implementor
    {
        public abstract void OperationImp();
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp)
            : base(imp)
        { }
        public override void Operation()
        {
        }
    }

    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp()
        {
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
        }
    }
}
