using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.StructuralPatterns
{
    /// <summary>
    /// Facade  
    /// -Знает, какие классы подсистемы отвечают за запрос.
    /// -Делегирует запросы клиентов соответствующим объектам подсистем.
    ///​ Классы подсистемы
    /// -Реализовывают функционал подсистемы
    /// -Обрабатывают методы, назначенные объектом Facade.
    /// -Не знают о фасаде и не ссылаются на него.
    /// Когда использовать фасад?
    /// -Когда имеется сложная система, и необходимо упростить с ней работу.Фасад позволит определить одну точку взаимодействия между клиентом и системой.
    /// -Когда надо уменьшить количество зависимостей между клиентом и сложной системой.Фасадные объекты позволяют отделить, изолировать компоненты системы от клиента и развивать и работать с ними независимо.
    /// -Когда нужно определить подсистемы компонентов в сложной системе. Создание фасадов для компонентов каждой отдельной подсистемы позволит упростить взаимодействие между ними и повысить их независимость друг от друга.
    /// Привмер: Фасад определяет унифицированный интерфейс более высокого уровня для подсистемы, которая упрощает ее использование. Потребители сталкиваются с фасадом при заказе из каталога. Потребитель звонит на один номер и разговаривает с представителем службы поддержки клиентов. Представитель службы поддержки клиентов выступает в качестве фасада, предоставляя интерфейс отделу исполнения заказов, отделу биллинга и отделу доставки.
    /// </summary>
    /// 

    //Очень многие библиотеки или подсистемы приложений содержат встроенные фасады, которые являются высокоуровневыми классами,
    //предназначенными для решения типовых операций. Фасады делают базовые сценарии простыми, а сложные сценарии — возможными.
    //Если клиенту нужна лишь базовая функциональность, достаточно воспользоваться фасадом; если же его функциональности недостаточно,
    //можно использовать более низкоуровневые классы модуля или библиотеки напрямую.
    //Инкапсуляция стороннего кода
    //Использование фасадов не только упрощает использование библиотек или сторонних компонентов, но и решает ряд насущных проблем.
    //Повторное использование кода и лучших практик.Многие библиотеки довольно сложные, поэтому их корректное использование требует определенных навыков.Инкапсуляция работы с ними в одном месте позволяет корректно использовать их всеми разработчиками независимо от их опыта
    //Переход на новую версию библиотеки. При выходе новой версии библиотеки достаточно будет протестировать лишь фасад, чтобы принять решение, стоит на нее переходить или нет.
    //Переход с одной библиотеки на другую. Благодаря фасаду приложение не так сильно завязано на библиотеку, так что переход на другую библиотеку потребует лишь создание еще одного фасада. А использование адаптера сделает этот переход менее болезненным.
    public class FacadeExample
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void RunFacadeExample()
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassD' class
    /// </summary>
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}
