using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestData.Init();
            Parallel.For(0, 50, new ParallelOptions { MaxDegreeOfParallelism = 5 }, WorkerToDo);

            Console.WriteLine("主线程结束");
            Console.Read();
        }

        private static void WorkerToDo(int i)
        {
            var key = TestData.Data.GetData();
            Console.WriteLine("线程：{0}，获取到数据{1}", Task.CurrentId, key);
            TestData.Data.RemoveData(key);
        }
    }
}
