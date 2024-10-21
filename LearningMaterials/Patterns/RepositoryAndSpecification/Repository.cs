using LearningMaterials.Patterns.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.Repository
{
    /// <summary>
    /// Если же у вас bounded context, или бизнес-логика требует более точечной реализации, то репозиторий, или репозиторий в комбинации спецификацией может стать тем решением которое вам нужно.
    /// </summary>
    interface IRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        void Add(Book book);
    }
}
