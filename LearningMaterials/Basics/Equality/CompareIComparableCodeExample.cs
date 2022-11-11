namespace LearningMaterials.Basics.Equality
{
    public class CompareIComparableCodeExample
    {
        void CompareByIComparable()
        {
            var obj1 = new TestClassIComparable
            {
                Count = 2
            };
            var obj2 = new TestClassIComparable
            {
                Count = 2
            };

            Console.WriteLine(obj1.CompareTo(obj2));
        }
    }

    internal class TestClassIComparable : IComparable<TestClassIComparable>
    {
        public int Count { get; set; }

        public int CompareTo(TestClassIComparable other)
        {
            return ReferenceEquals(this, other) ? 0 : Count.CompareTo(other.Count);
        }
    }
}