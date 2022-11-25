using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.GC
{
    /// <summary>
    /// https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/
    /// Memory allocation and Memory release
    /// 3 generations: old, young middle
    /// 3 phases: mark phase, sweep phase, compact phase
    /// Algorithms: Sweep (mark, sweep), Compact (3 phases)
    /// Large Object Heap - memory space for objects > 85 Kb
    /// Configuration https://learn.microsoft.com/ru-ru/dotnet/core/runtime-config/garbage-collector#background-gc
    /// Объект удаляется сборщиком мусора, когда на него не остается ссылок.
    /// </summary>
    public class GarbageCollectorWorkExample
    {

    }

    /// <summary>
    /// Dispose - обеспечивает явный контроль над ресурсами, используемыми объектом, а Finalize - неявный, используемый сборщиком мусора.
    /// </summary>
    public class DisposeOrFinalize
    { }
}
