using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.CreationalPatterns
{
    /// <summary>
    /// Прототип —​ позволяет создавать новые объекты путем клонирования уже существующих. По сути данный паттерн предлагает технику клонирования объектов.
    /// Когда использовать Прототип?
    /// Класс порождаемого объекта определяется в момент выполнения.
    /// Когда желательно избежать наследования создателя объекта.В этом случае, Прототип является конкурентом Абстрактной фабрики.
    /// Когда клонирование объекта является более предпочтительным вариантом нежели его создание и инициализация с помощью конструктора.
    /// Когда создание копии объекта проще и быстрее, чем порождение его стандартным путем, используя операцию new и включая инициализацию полей.
    /// Неполное копирование(Shallow copy) - ValueTypes ссылаются на те же объекты и Полное копирование (Deep copy) ValueTypes ссылаются на новые объекты. 
    /// </summary>
    public class Prototype
    {
        class Client
        {
            void Operation()
            {
                AbstractPrototype prototype = new ConcretePrototype1(1);
                AbstractPrototype clone = prototype.Clone();
                prototype = new ConcretePrototype2(2);
                clone = prototype.Clone();
            }
        }

        abstract class AbstractPrototype
        {
            public int Id { get; private set; }
            public AbstractPrototype(int id)
            {
                this.Id = id;
            }
            public abstract AbstractPrototype Clone();
        }

        class ConcretePrototype1 : AbstractPrototype
        {
            public ConcretePrototype1(int id)
                : base(id)
            { }
            public override AbstractPrototype Clone()
            {
                return new ConcretePrototype1(Id);
            }
        }

        class ConcretePrototype2 : AbstractPrototype
        {
            public ConcretePrototype2(int id)
                : base(id)
            { }
            public override AbstractPrototype Clone()
            {
                return new ConcretePrototype2(Id);
            }
        }

        //В .NET существует два типа переменных: Value type и reference type. Для значимых типов при копировании всегда создается копия полная копия (deep copy).
        //А вот переменные ссылочного типа при копировании имеют особенность. Она заключается в том, что передается ссылка на существующий экземпляр.
        //При этом копия объекта не создается. Поэтому различают два варианта клонирования:
        //Неполное копирование(Shallow copy). В результате, ссылочные переменные копии указывают на те же объекты, что и в прототипе.
        //Этот вариант реализован в protected методе MemberwiseClone() класса Object.
        //Полное копирование (Deep copy). При этом ссылочные переменные копии получат ссылки на собственные объекты, которые так же были полностью скопированы.
        //Такое клонирование медленнее и сложнее.Особенно это заметно, если вложенные объекты самостоятельно не поддерживают свое полное копирование.
        //Кроме того, необходимо определять и особо учитывать кольцевые ссылки.Т.е.ситуации, когда два или более вложенных объектов ссылаются друг на друга.
        //Но, несмотря на эти возможные сложности, данный вариант позволяет создать копию, которая полностью независима от прототипа.
        //Стоит отметить, что для полного копирования (именно то что и должно реализовыватся прототипом) нужно использовать следующий подход:
        //DeepCopy 
        public object Clone()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
    }
}
