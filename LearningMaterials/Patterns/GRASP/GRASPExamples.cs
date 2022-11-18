using LearningMaterials.Patterns.GoF.BehavioralPatterns.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LearningMaterials.Patterns.GoF.BehavioralPatterns.StrategyExample;
using static LearningMaterials.Patterns.GRASP.GRASPExamples.InformationExpert;

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

        /// <summary>
        /// Pure Fabrication или чистая выдумка, или чистое синтезирование. Здесь суть в выдуманном объекте. Аналогом может быть шаблон Service (сервис) в парадигме DDD.
        /// Какую проблему решает Pure Fabrication?
        /// Уменьшает зацепление(Low Coupling);
        /// Повышает связанность(High Cohesion);
        /// Упрощает повторное использование кода.
        /// К примеру у вас есть объект Customer и следую шаблону  информационный эксперт вы наделили его логикой которую мы показывали выше, как вы реализуете сохранение Customera в БД?
        /// Так вот следуя Pure Fabrication принципу, мы создадим Сервис или репозиторий который будет доставать и сохранять такой объект в базу данных.
        /// </summary>
        public class PureFabrication
        {
        
        }

        /// <summary>
        /// Indirection или посредник. Можно столкнуться с таким вопросом: «Как определить ответственность объекта и избежать сильной связанности между объектами, даже если один класс нуждается в функционале (сервисах), который предоставляет другой класс?»
        /// Решение: возложите ответственность на промежуточный объект, чтобы он осуществлял связь между другими компонентами или службами, чтобы они не были напрямую связаны.Такое решение можно сделать с помощью GoF паттерна медиатор
        /// Обратите внимание. Посредник поддерживает "low coupling", но снижает читабельность и понимание всей системы. Вы не знаете, какой класс обрабатывает команду из определения Controller. Это компромисс.
        /// </summary>
        public class Indirection
        {
            public class CustomerOrdersControllerOld : Controller
            {
                private readonly IOrdersService _ordersService;

                public CustomerOrdersControllerOld(IOrdersService ordersService)
                {
                    this._ordersService = ordersService;
                }
            }

            public class CustomerOrdersController : Controller
            {
                private readonly IMediator _mediator;

                public CustomerOrdersController(IMediator mediator)
                {
                    this._mediator = mediator;
                }

                public async Task<IActionResult> AddCustomerOrder(
                    [FromRoute] Guid customerId,
                    [FromBody] CustomerOrderRequest request)
                {
                    await _mediator.Send(new AddCustomerOrderCommand(customerId, request.Products));

                    return Created(string.Empty, null);
                }

                private IActionResult Created(string empty, object value)
                {
                    throw new NotImplementedException();
                }

            }

            public class AddCustomerOrderCommand
            {
                private Guid customerId;
                private object products;

                public AddCustomerOrderCommand(Guid customerId, object products)
                {
                    this.customerId = customerId;
                    this.products = products;
                }
            }

            public interface IMediator
            {
                Task Send(AddCustomerOrderCommand acoc);
            }

            public interface IOrdersService
            {
            }

            public class CustomerOrderRequest
            {
                public object Products { get; set;}
            }

        }

        /// <summary>
        /// Полиморфизм позволяет реализовывать одноименные публичные методы, позволяя различным классам выполнять различные действия при одном и том же вызове. То есть объекты классов Square и Circle могут отображаться(реализовывать метод render) по разному несмотря не то, что они оба подклассы Shape, метод render определен в Shape. (Overriding).
        /// Принцип полиморфизма является основополагающим в ООП.В этом контексте принцип тесно связан с GoF паттерном strategy.Это самый яркий пример реализации полиморфизма.
        /// </summary>
        public class Polymorphism
        {
        }

        /// <summary>
        /// Проблема: Как спроектировать объекты, подсистемы и системы таким образом, чтобы изменения или нестабильность этих элементов не оказывали нежелательного влияния на другие элементы?
        /// Решение: Определите точки прогнозируемого изменения или нестабильности, распределите обязанности по созданию стабильного интерфейса вокруг них
        /// По мнению многих это самый важный принцип который косвенно связан с остальными принципами GRASP.В настоящее время одним из наиболее важных показателей качества кода является простота изменений. Как архитекторы и программисты, мы должны быть готовы к постоянно меняющимся требованиям. Это не является «nice to have» атрибутом - это «must-have» в любом приложении и наша обязанность как программистов и архитекторов нашей системы это обеспечить. 
        /// </summary>
        public class ProtectedVariations
        {
        }
    }


}
