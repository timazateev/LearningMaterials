using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.StructuralPatterns.Flyweight
{
    /// <summary>
    /// Паттерн Приспособленец (Flyweight) - шаблон проектирования, который позволяет использовать разделяемые объекты сразу в нескольких контекстах.
    /// Данный паттерн используется преимущественно для оптимизации работы с памятью.
    /// Приспособленец это экземпляр объекта, который выдает себя за группу самостоятельных экземпляров.
    /// Участники
    /// Flyweight: определяет интерфейс, через который приспособленцы-разделяемые объекты могут получать внешнее состояние или воздействовать на него
    /// ConcreteFlyweight: конкретный класс разделяемого приспособленца.Реализует интерфейс, объявленный в типе Flyweight, и при необходимости добавляет внутреннее состояние. Причем любое сохраняемое им состояние должно быть внутренним, не зависящим от контекста
    /// UnsharedConcreteFlyweight: еще одна конкретная реализация интерфейса, определенного в типе Flyweight, только теперь объекты этого класса являются неразделяемыми
    /// FlyweightFactory: фабрика приспособленцев - создает объекты разделяемых приспособленцев. 
    ///  Так как приспособленцы разделяются, то клиент не должен создавать их напрямую.Все созданные объекты хранятся в пуле. 
    ///  В примере выше для определения пула используется объект Hashtable, но это не обязательно. Можно применять и другие классы коллекций. 
    ///  Однако в зависимости от сложности структуры, хранящей разделяемые объекты, особенно если у нас большое количество приспособленцев, 
    ///  то может увеличиваться время на поиск нужного приспособленца - наверное это один из немногих недостатков данного паттерна.
    ///  Если запрошенного приспособленца не оказалось в пуле, то фабрика создает его.
    /// Client: использует объекты приспособленцев.Может хранить внешнее состояние и передавать его в качестве аргументов в методы приспособленцев.
    /// </summary>
    class FlyweightFactory
    {
        Hashtable flyweights = new Hashtable();
        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteFlyweight());
            return flyweights[key] as Flyweight;
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }

    class ConcreteFlyweight : Flyweight
    {
        int intrinsicState;
        public override void Operation(int extrinsicState)
        {
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        int allState;
        public override void Operation(int extrinsicState)
        {
            allState = extrinsicState;
        }
    }

    class Client
    {
        void Main()
        {
            int extrinsicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fd = f.GetFlyweight("D");
            fd.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);
        }
    }
}
