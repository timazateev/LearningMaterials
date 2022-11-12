using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.StructuralPatterns
{
    /// <summary>
    /// Назначение:
    ///Преобразует интерфейс одного класса в интерфейс другого, который ожидают клиенты.Адаптер делает возможной совместную работу классов с несовместимыми интерфейсами.
    ///Когда следует использовать Адаптер?
    ///Когда необходимо использовать имеющийся класс, но его интерфейс не соответствует потребностям бизнесс логики.
    ///Когда надо использовать уже существующий класс совместно с другими классами, интерфейсы которых не совместимы.
    ///Адаптер позволяет использовать существующие типы в новом контексте
    ///Повторное использование чужого кода.В некоторых случаях у нас уже есть код, который решает нужную задачу, но его интерфейс не подходит для текущего приложения. Вместо изменения кода библиотеки можно создать слой адаптеров.
    ///Адаптивный рефакторинг. Адаптеры позволяют плавно изменять существующую функциональность путем выделения нового «правильного» интерфейса, но с использованием старой проверенной функциональности.
    /// </summary>
    public class AdapterExample
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Target' class
    /// </summary>
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }

    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
