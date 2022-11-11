using System.Collections;

namespace LearningMaterials.Basics.Equality
{
    //IStructuralEquatable работает в паре с интерфейсом IEqualityComparer.
    //Интерфейс IStructuralEquatable реализуют такие классы как System.Array или System.Tuple.IStructuralEquality декларирует то,
    //что тип может составлять более крупные объекты, которые реализуют семантику значимых типов
    //и вряд ли когда-либо нам потребуется его самостоятельно реализовывать.

    //Пример реализации этого интерфейса можно подсмотреть в System.Array:

    //bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    //{
    //    if (other == null)
    //    {
    //        return false;
    //    }
    //    if (object.ReferenceEquals(this, other))
    //    {
    //        return true;
    //    }
    //    Array array = other as Array;
    //    if (array == null || array.Length != this.Length)
    //    {
    //        return false;
    //    }
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        object value = this.GetValue(i);
    //        object value2 = array.GetValue(i);
    //        if (!comparer.Equals(value, value2))
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
}
