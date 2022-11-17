using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.BehavioralPatterns.Memento
{
    /// <summary>
    /// Паттерн Хранитель (Memento) — позволяет выносить внутреннее состояние объекта за его пределы для последующего возможного восстановления объекта без нарушения принципа инкапсуляции.
    /// Не нарушая инкапсуляции, паттерн Memento получает и сохраняет за пределами объекта его внутреннее состояние так, чтобы позже можно было восстановить объект в таком же состоянии.
    /// Является средством для инкапсуляции "контрольных точек" программы.
    /// Паттерн Memento придает операциям "Отмена" (undo) или "Откат" (rollback) статус "полноценного объекта".
    /// Когда использовать Memento?
    /// -Когда нужно сохранить состояние объекта для возможного последующего восстановления;
    /// -Когда сохранение состояния должно проходить без нарушения принципа инкапсуляции;
    /// Memento: хранитель, который сохраняет состояние объекта Originator и предоставляет полный доступ только этому объекту Originator
    /// Originator: создает объект хранителя для сохранения своего состояния
    /// Caretaker: выполняет только функцию хранения объекта Memento, в то же время у него нет полного доступа к хранителю и никаких других операций над хранителем, кроме собственно сохранения, он не производит
    /// </summary>

    class MementoExample
    {
        static void RunMainAppExample()
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Originator' class

    /// </summary>

    class Originator

    {
        private string _state;

        // Property

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        // Creates memento 
        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        // Restores original state

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private string _state;

        // Constructor
        public Memento(string state)
        {
            this._state = state;
        }

        // Gets or sets state
        public string State
        {
            get { return _state; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class Caretaker

    {
        private Memento _memento;

        // Gets or sets memento

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
