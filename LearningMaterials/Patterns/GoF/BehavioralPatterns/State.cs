using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.BehavioralPatterns.State
{
    /// <summary>
    /// Назначение:
    /// Позволяет объекту варьировать свое поведение в зависимости от внутреннего состояния.Извне создается впечатление, что изменился класс объекта. 
    /// Паттерн «Состояние» предполагает выделение базового класса или интерфейса для всех допустимых операций и наследника для каждого возможного состояния
    /// - Когда использовать Паттерн State
    /// - Когда поведение объекта должно зависеть от его состояния и может изменяться динамически во время выполнения
    /// - Когда в коде методов объекта используются многочисленные условные конструкции, выбор которых зависит от текущего состояния объекта
    /// </summary>
    public class StateExample
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void RunStateExample()
        {
            // Setup context in a state
            Context c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {
        private State _state;

        // Constructor
        public Context(State state)
        {
            this.State = state;
        }

        // Gets or sets the state
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " +
                  _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}

