using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.StructuralPatterns.Proxy
{
    /// <summary>
    /// «Заместитель» является одним из немногих паттернов проектирования, который с течением времени претерпел довольно серьезные изменения. В классическом труде «банды четырех» описаны три основных сценария использования паттерна «Заместитель».
    /// Удаленный заместитель (remote proxies) — ​отвечает за кодирование запроса и его аргументов для работы с компонентом в другом адресном пространстве.
    /// Виртуальный заместитель(virtual proxies) —​ может кэшировать дополнительную информацию о реальном компоненте, чтобы отложить его создание.
    /// Защищающий заместитель (protection proxies) — проверяет, имеет ли вызывающий объект необходимые для выполнения запроса права.​ 
    /// Subject: определяет общий интерфейс для Proxy и RealSubject. Поэтому Proxy может использоваться вместо RealSubject
    /// RealSubject: представляет реальный объект, для которого создается прокси
    /// Proxy: заместитель реального объекта.Хранит ссылку на реальный объект, контролирует к нему доступ, может управлять его созданием и удалением.
    /// Client: использует объект Proxy для доступа к объекту RealSubject
    /// </summary>
    class Client
    {
        void Main()
        {
            Subject subject = new Proxy();
            subject.Request();
        }
    }
    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        { }
    }
    class Proxy : Subject
    {
        RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
                realSubject = new RealSubject();
            realSubject.Request();
        }
    }

    // Пример
    /// <summary>
    /// Класс Lazy можно считать универсальным строительным блоком, с помощью которого легко создавать виртуальные классы-заместители
    /// </summary>
    public interface IHeavyweight
    {
        void Foo();
    }

    public class Heavyweight : IHeavyweight
    {
        public void Foo()
        { }
    }
    // Виртуальный заместитель, который будет создавать
    // тяжеловесный объект лишь при необходимости
    public class HeavyweightProxy : IHeavyweight
    {
        private readonly Lazy<Heavyweight> _lazy = new Lazy<Heavyweight>();
        public void Foo()
        {
            _lazy.Value.Foo();
        }
    }
}

