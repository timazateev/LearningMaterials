using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.GC
{

    internal class GarbageCollectorWorkExample
    {
        //https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/
        // Memory allocation and Memory release
        // 3 generations: old, young middle
        // 3 phases: mark phase, sweep phase, compact phase
        // Algorithms: Sweep (mark, sweep), Compact (3 phases)

        // Large Object Heap - memory space for objects > 85 Kb
        // Configuration https://learn.microsoft.com/ru-ru/dotnet/core/runtime-config/garbage-collector#background-gc
    }
}
