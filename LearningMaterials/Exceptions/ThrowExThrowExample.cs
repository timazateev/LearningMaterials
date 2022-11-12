using System.Xml.Linq;

namespace LearningMaterials.Exceptions
{
    /// <summary>
    /// Можно также использовать синтаксис throw e в блоке catch, чтобы создать исключение, которое будет передано вызывающему объекту. В этом случае трассировка стека исходного исключения, которое доступно из свойства StackTrace, не сохраняется.
    /// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/throw
    /// https://learn.microsoft.com/ru-ru/dotnet/standard/exceptions/best-practices-for-exceptions 
    /// Использование предопределенных типов исключений .NET
    /// Завершайте имена классов исключений словом Exception
    /// Восстановление состояния, если методы не выполняются из-за исключения
    /// throw vs возврат кода ошибки. Код понятнее при throw, но при возврате кода не тратятся дополнительные ресурсы.
    /// </summary>
    public class ThrowExThrowExample
    {
        public ThrowExThrowExample(string s)
        {
            Value = s;
        }

        public string Value { get; set; }

        public char GetFirstCharacter()
        {
            try
            {
                return Value[0];
            }
            catch (NullReferenceException e)
            {
                throw;
            }
        }
    }

    public class Example
    {
        public static void Main()
        {
            var s = new ThrowExThrowExample(null);
            Console.WriteLine($"The first character is {s.GetFirstCharacter()}");
        }
    }
    // The example displays the following output:
    //    Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
    //       at Sentence.GetFirstCharacter()
    // 

    public class MoreThrowExamples
    {
        private static void DisplayFirstNumber(string[] args)
        {
            string arg = args.Length >= 1 ? args[0] :
                                       throw new ArgumentException("You must supply an argument");
            if (Int64.TryParse(arg, out var number))
                Console.WriteLine($"You entered {number:F0}");
            else
                Console.WriteLine($"{arg} is not a number.");
        }
        private string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }

        DateTime ToDateTime(IFormatProvider provider) =>
         throw new InvalidCastException("Conversion to a DateTime is not supported.");
    }
}

