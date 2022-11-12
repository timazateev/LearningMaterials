using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.StructuralPatterns.Decorator
{
    /// <summary>
    /// Динамически добавляет объекту новые обязанности. Является гибкой альтернативой порождению подклассов с целью расширения функциональности.
    /// Когда надо динамически добавлять к объекту новые функциональные возможности. При этом данные возможности могут быть сняты с объекта
    /// Когда применение наследования неприемлемо.Например, если нам надо определить множество различных функциональностей 
    /// и для каждой функциональности наследовать отдельный класс, то структура классов может очень сильно разрастись.Еще больше она может разрастись, 
    /// если нам необходимо создать классы, реализующие все возможные сочетания добавляемых функциональностей.
    /// Декоратор позволяет динамически расширять поведение объектов. Он идеально подходит для расширения поведения всех методов интерфейса, 
    /// которое не является частью основной функциональности. Если кэшировать нужно лишь результаты одного метода класса, то использование декоратора будет слишком тяжеловесным.
    /// Декораторы применяются для добавления всем методам интерфейса некоторого поведения, которое не является частью основной функциональности.
    /// Декораторы отлично подходят для решения следующих задач:
    /// -кэширования результатов работы;
    /// -замера времени исполнения методов;
    /// -логирования аргументов;
    /// -управления доступом пользователей;
    /// -модификации аргументов или результата работы методов упаковки/распаковки, шифрования и т.п.
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }
    class ConcreteComponent : Component
    {
        public override void Operation()
        { }
    }
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
                component.Operation();
        }
    }
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
}
