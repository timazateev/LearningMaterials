using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GRASP
{
    public class GRASPExamples
    {
        internal class Order
        {
            public Order(IList<OrderProduct> orderProduct)
            {
            }
            internal decimal Amount { get; set; }
        }
        public class OrderProduct
        {
        }

        /// <summary>
        /// Ответственность должна быть назначена тому, кто владеет максимумом необходимой информации для исполнения — информационному эксперту.
        /// В следующем примере на C# класс Customer содержит ссылки на все заказы клиентов, следовательно логично разместить тут метод для подсчета общей стоимости заказов
        /// </summary>
        public class InformationExpert
        {
            public class Customer
            {
                private readonly List<Order> _orders = new List<Order>();

                public decimal GetTotalAmount(Guid orderId)
                {
                    return this._orders.Sum(x => x.Amount);
                }
            }

        }

        /// <summary>
        /// Cуть ответственности такого объекта в том, что он создает другие объекты.
        /// Но есть ряд моментов, которые должны выполняться, когда мы наделяем объект ответственностью создателя:
        /// - Создатель содержит или агрегирует создаваемые объекты
        /// - Создатель использует создаваемые объекты
        /// - Создатель знает, как проинициализировать создаваемый объект
        /// - Создатель записывает создаваемые объекты
        /// - Создатель имеет данные инициализации для A
        /// </summary>
        public class Creator
        {
            private readonly List<Order> _orders = new List<Order>();
            public void AddOrder(List<OrderProduct> orderProducts)
            {
                var order = new Order(orderProducts); // создатель
                _orders.Add(order);
            }
        }

        /// <summary>
        /// Шаблон сontroller призван решить проблему разделения интерфейса и логики в интерактивном приложении. 
        /// Это не что иное, как хорошо известный контроллер из MVC парадигмы. 
        /// Контролер отвечает за обработку запросов и решает кому должен делегировать запросы на выполнение. 
        /// Если обобщить назначение сontroller, то он должен отвечать за обработку входных системных сообщений.
        /// </summary>
        public class Controller
        {

        }

        /// <summary>
        /// Если объекты в приложении сильно связанны, то любой их изменение приводит к изменениям во всех связанных объектах. 
        /// А это неудобно и порождает множество проблем. Low coupling как раз говорит о том что необходимо, чтобы код был слабо связан и зависел только от абстракций. 
        /// Слабая связанность так же встречается в SOLID принципах как The Dependency Inversion Principle​ (DIP) и слабая связанность по сути это реализация Dependency Injection принципа. 
        /// Когда мы уходим от конкретных реализаций и абстрагируемся на уровнях интерфейсов(которые легко подменять нужными нам реализациями), тогда код не завязан на определенные реализации.
        /// </summary>
        public class LowCoupling
        {

        }

        /// <summary>
        /// По сути High Cohesion очень тесно связанна с Single Responsibility Principle​ (SRP) с SOLID принципов. High Cohesion получается в результате соблюдения SRP. 
        /// High Cohesion принцип говорит о том, что класс должен стараться выполнять как можно меньше не специфичных для него задач, 
        /// и иметь вполне определенную область применения.Только с опытом приходит понимание балансировки между High Cohesion и Low Coupling.
        /// считается что Low Coupling и High Cohesion) это инь и янь проектирования ПО. Некорректное юзание High Cohesion порождает неправильное Low Coupling и наоборот.
        /// </summary>
        public class HighCohesion
        {

        }
    }
}
