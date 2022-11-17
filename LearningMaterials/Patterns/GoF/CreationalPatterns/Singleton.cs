﻿namespace LearningMaterials.Patterns.GoF.CreationalPatterns
{
    /// <summary>
    /// при отсутствии состояния и наличии небольшого числа операций статические методы являются более подходящим решением. 
    /// Если же глобальный объект обладает состоянием, то реализация на основе паттерна «Синглтон» будет проще. 
    /// Существует компромиссное решение: статический класс с небольшим набором методов может выполнять роль фасада над реализацией на основе синглтона. 
    /// ThreadPool.QueueUserWorkItem является хорошим примером такого подхода.
    /// Применимость: паттерн или антипаттерн
    ///Синглтон без видимого состояния - Нет ничего критического использовании синглтона, через который можно получить доступ к стабильной справочной информации или некоторым утилитам.
    ///Настраиваемый контекст.Аналогично нет ничего критического в протаскивании инфраструктурных зависимостей в виде Ambient Context, то есть в использовании синглтона, возвращающего абстрактный класс или интерфейс, который можно установить в начале приложения или при инициализации юнит-теста.
    ///Минимальная область использования.Ограничьте использование синглтона минимальным числом классов/модулей.Чем меньше у синглтона прямых пользователей, тем легче будет от него избавиться и перейти на более продуманную модель управления зависимостями. Помните, что чем больше у классов поль- зователей, тем сложнее его изменить. Если уж вы вынуждены использовать синглтон, возвращающий бизнес-объект, то пусть лишь несколько высокоуровневых классов-медиаторов используют синглтоны напрямую и передают его экземпляр в качестве зависимостей классам более низкого уровня.
    ///Сделайте использование синглтона явным. Если передать зависимость через аргументы конструктора не удается, то сделайте использование синглтона явным.Вместо обращения к синглтону из нескольких методов сделайте статическую переменную и проинициализируйте ее экземпляром синглтона.
    /// </summary>
    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static object syncRoot = new Object();

        private Singleton() { }

        private int Num;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }

                return instance;
            }
        }

        public void SetSomeValue(int i)
        {
            Num = i;
        }
        public int GetSomeValue()
        {
            return Num;
        }
    }
}