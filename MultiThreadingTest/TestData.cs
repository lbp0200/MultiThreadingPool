using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreadingTest
{
    public class TestData
    {
        public static TestData Data { get; private set; }
        static object objLock = new object();
        int seed = 0;
        static Dictionary<int, int> DataList;
        TestData()
        {
            DataList = new Dictionary<int, int>();
            for (int i = 0; i < 100; i++)
            {
                DataList.Add(i, i);
            }
        }
        public static void Init()
        {
            if (Data == null)
            {
                Data = new TestData();
            }
        }
        public int GetData()
        {
            lock (objLock)
            {
                Random rd = new Random(seed++);
                int index = rd.Next(DataList.Count);
                int key = DataList.Keys.ToList()[index];
                if (DataList.ContainsKey(key))
                {
                    return DataList[key];
                }
                else
                {
                    return -1;
                }
            }
        }

        public void RemoveData(int key)
        {
            lock (objLock)
            {
                if (DataList.ContainsKey(key))
                {
                    DataList.Remove(key);
                    Console.WriteLine("删除Key：{0}，剩余：{1}", key, DataList.Count);
                }
            }
        }
    }
}
