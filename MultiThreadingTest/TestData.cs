using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreadingTest
{
    public class TestData
    {
        static TestData DataDic { get; set; }

        static Dictionary<int, int> DataList;
        TestData()
        {
            DataList = new Dictionary<int, int>();
            for (int i = 0; i < 100; i++)
            {
                DataList.Add(i, i);
            }
        }

        static int GetData()
        {
            Random rd = new Random();
            int index = rd.Next(DataList.Count);
            if (DataList.Keys.Count == 1)
            {

            }
            return 0;
        }
    }
}
