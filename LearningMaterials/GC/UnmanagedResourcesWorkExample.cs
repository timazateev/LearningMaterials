using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.GC
{
    internal class UnmanagedResourcesWorkExample
    {
        // IDisposable and using to clean unmanaged resources
        // https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/unmanaged
        // using OR try/catch/finally https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/using-objects 
        //SafeHandle https://learn.microsoft.com/ru-ru/dotnet/api/system.runtime.interopservices.safehandle?view=net-6.0

        //IAsyncDisposable https://learn.microsoft.com/ru-ru/dotnet/api/system.iasyncdisposable.disposeasync?view=net-6.0#System_IAsyncDisposable_DisposeAsync
        //https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/implementing-disposeasync
        //Это позволяет запускать асинхронный (async) код при освобождении ресурсов, что в некоторых случаях необходимо для предотвращения взаимоблокировок.

        //Finalize https://learn.microsoft.com/ru-ru/dotnet/api/system.object.finalize?view=net-6.0
    }



}
