using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterials.Delegates
{
    internal class TrainStation
    {
        delegate int Train();

        int Wagon1()
        {
            Console.WriteLine("wagon1 is running");
            return 1;
        }

        int Wagon2()
        {
            Console.WriteLine("wagon2 is running");
            return 2;
        }
        public void CreateTrain()
        {
            Train train = Wagon1;
            train += Wagon2;
            train += () => // пример с использованием лямбда выражения
            {
                Console.WriteLine("wagon3 is running");
                return 3;
            };

            Console.WriteLine("WagonNumber:" + train());
        }
    }
    internal class DelegateCodeExample
    {
        void DelegateExampleTrain()
        {
            var trainStation = new TrainStation();
            trainStation.CreateTrain();
            Console.ReadKey();

            //Output: 
            //wagon1 is running
            //wagon2 is running
            //wagon3 is running
            //WagonNumber:3

            //Делегат это по сути очередь в которую можно добавить сколько угодно методов.
            //При выполнении  train += Wagon2; мы добавляем 2й вагон в очередь. 
            //Причина почему на экран вывелась цифра "3" после выполнения всех методов в том что если функция имеет возвращаемое значение,
            //то возвращается значение с последней добавленной "в очередь" функции.
        }
    }
}
