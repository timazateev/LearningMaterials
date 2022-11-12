using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Patterns.GoF.BehavioralPatterns
{
    /// <summary>
    /// Позволяет избежать привязки отправителя запроса к его получателю, давая шанс обработать запрос нескольким объектам. 
    /// Связывает объекты-получатели в цепочку и передает запрос вдоль этой цепочки, пока его не обработают. 
    /// «Цепочка обязанностей» является довольно распространенным паттерном в .NET Framework, хотя не все знают, что часто пользуются им. 
    /// Цепочка обязанностей — это любое событие, аргументы которого позволяют уведомить инициатора, 
    /// что событие обработано с помощью метода Handle() или путем установки свойства Handled в True.
    /// </summary>
    internal class ChainOfResponsibility
    {
    }
}
