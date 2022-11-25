using System.Collections;

namespace LearningMaterials.Exercise
{
    public class MyEnumeration<T> : IEnumerable<T>
    {
        public MyEnumeration(T[] arr)
        {
            mylist = new List<T>(arr);
        }

        List<T> mylist = new();

        public T this[int index]
        {
            get { return mylist[index]; }
            set { mylist.Insert(index, value); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return mylist.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static IEnumerable<T> NewWhere(IEnumerable<T> listToSelect, Func<T, bool> predicate)
        {
            int index = -1;
            foreach (T element in listToSelect)
            {
                checked
                {
                    index++;
                }

                if (predicate(element))
                {
                    yield return element;
                }
            }
        }
    }
}
