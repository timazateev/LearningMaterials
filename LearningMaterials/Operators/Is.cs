using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Operators
{
    /// <summary>
    /// Выражение o is Employee проверяет, является ли переменная o объектом типа Employee. 
    /// </summary>
    public class IsExample
    {

        void RunExample()
        {
            Employee o = new Employee();
            if (o is Employee)
            {
                Employee e = (Employee)o;
            }
        }
    }

    internal class Employee
    {
    }
}
