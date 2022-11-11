namespace LearningMaterials.Basics.Equality
{
    public class EqualityComparerCodeExample
    {
        void EqualsByEqualityComparer()
        {
            var obj1 = new TestClassEqualityComparer
            {
                Count = 2
            };
            var obj2 = new TestClassEqualityComparer
            {
                Count = 2
            };

            Console.WriteLine(obj1.Equals(obj2));
        }
    }

    class TestClassEqualityComparer : IEqualityComparer<int>
    {
        public int Count { get; set; }

        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return obj.GetHashCode();
        }
    }

    //Если структура содержит поля, которые являются ссылочными типами, следует переопределить метод Equals(Object).
    //Это может повысить производительность и позволить более точно представить значение равенства для типа.
    //Так как при большом количестве полей, выполнение ValueType.Equals может быть очень затратным по времени.
    //При переопределении так же не забывайте переопределять и метод GetHashCode который используется в таких типах данных как
    //Dictionary для сравнения объектов.
}
