using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestPr
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, Tvalue>
    {
        private List<TKey> listofKey;
        private List<string> listofStr;
        private Dictionary<TKey, Tvalue> dictofKey;
        private Dictionary<string, Tvalue> dictofString;
        private GenerateElement<TKey, Tvalue> generEl;

        public TestCollections(GenerateElement<TKey, Tvalue> gener)
        {
            int count;
            do
            {
                Console.WriteLine("Enter lenght of collection");
            } while (!int.TryParse(Console.ReadLine(), out count) || count <= 0);
            listofKey = new List<TKey>(count);
            listofStr = new List<string>(count);
            dictofKey = new Dictionary<TKey, Tvalue>(count);
            dictofString = new Dictionary<string, Tvalue>(count);

            generEl = gener;
            KeyValuePair<TKey, Tvalue> kvp;
            for (int i = 1; i < count+1; i++)
            {
                kvp = generEl.Invoke(i);
                listofKey.Add(kvp.Key);
                listofStr.Add(kvp.Key.ToString());
                dictofKey.Add(kvp.Key, kvp.Value);
                dictofString.Add(kvp.Key.ToString(), kvp.Value);
            }





        }
        

        public void ListsTime()
        {
            TKey none = generEl(listofKey.Count+2).Key;
            Stopwatch sw=new Stopwatch();
            sw.Start();
            listofKey.Contains(listofKey.First());
            sw.Stop();
            Console.WriteLine("First element List<TKey> : "+sw.Elapsed);
            sw.Restart();
            listofStr.Contains(listofStr.First());
            sw.Stop();
            Console.WriteLine("First element List<string> : "+sw.Elapsed);



            sw.Restart();
            listofKey.Contains(listofKey[listofKey.Count/2]);
            sw.Stop();
            Console.WriteLine("Middle element List<TKey> : " + sw.Elapsed);
            sw.Restart();
            listofStr.Contains(listofStr[listofStr.Count/2]);
            sw.Stop();
            Console.WriteLine("Middle element List<string> : " + sw.Elapsed);




            sw.Restart();
            listofKey.Contains(listofKey.Last());
            sw.Stop();
            Console.WriteLine("Last element List<TKey> : " + sw.Elapsed);
            sw.Restart();
            listofStr.Contains(listofStr.Last());
            sw.Stop();
            Console.WriteLine("Last element List<string> : " + sw.Elapsed);




            sw.Restart();
            listofKey.Contains(none);
            sw.Stop();
            Console.WriteLine("Not element List<TKey> : " + sw.Elapsed);
            sw.Restart();
            listofStr.Contains("qwertyuiop");
            sw.Stop();
            Console.WriteLine("Not element List<string> : " + sw.Elapsed);

      

        }

        public void DictsTime()
        {
            Dictionary<TKey, Tvalue>.KeyCollection keyColl = dictofKey.Keys;
            TKey none = generEl(listofKey.Count + 2).Key;
            Dictionary<string, Tvalue>.KeyCollection keyStrColl = dictofString.Keys;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictofKey.ContainsKey(keyColl.First());
            sw.Stop();
            Console.WriteLine("First element Dictionary< TKey, TValue> : "+sw.Elapsed);
            sw.Restart();
            dictofString.ContainsKey(keyStrColl.First());
            sw.Stop();
            Console.WriteLine("First element Dictionary< string, TValue> : " + sw.Elapsed);

            sw.Restart();
            dictofKey.ContainsKey(keyColl.ElementAt(keyColl.Count/2));
            sw.Stop();
            Console.WriteLine("Middle element Dictionary< TKey, TValue> : " + sw.Elapsed);
            sw.Restart();
            dictofString.ContainsKey(keyStrColl.ElementAt(keyColl.Count / 2));
            sw.Stop();
            Console.WriteLine("Middle element Dictionary< string, TValue> : " + sw.Elapsed);



            sw.Restart();
            dictofKey.ContainsKey(keyColl.Last());
            sw.Stop();
            Console.WriteLine("Last element Dictionary< TKey, TValue> : " + sw.Elapsed);
            sw.Restart();
            dictofString.ContainsKey(keyStrColl.Last());
            sw.Stop();
            Console.WriteLine("Last element Dictionary< string, TValue> : " + sw.Elapsed);



            sw.Restart();
            dictofKey.ContainsKey(none);
            sw.Stop();
            Console.WriteLine("Not element List<TKey> : " + sw.Elapsed);
            sw.Restart();
            dictofString.ContainsKey("qwertyuiop");
            sw.Stop();
            Console.WriteLine("Not element List<string> : " + sw.Elapsed);




        }

        public void DictValueTime()
        {
            Dictionary<TKey, Tvalue>.ValueCollection valueColl = dictofKey.Values;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictofKey.ContainsValue(valueColl.First());
            sw.Stop();
            Console.WriteLine("First element by value Dictionary< TKey, TValue> : "+sw.Elapsed);

            sw.Restart();
            dictofKey.ContainsValue(valueColl.ElementAt(valueColl.Count/2));
            sw.Stop();
            Console.WriteLine("Middle element by value Dictionary< TKey, TValue> : " + sw.Elapsed);

            sw.Start();
            dictofKey.ContainsValue(valueColl.Last());
            sw.Stop();
            Console.WriteLine("Last element by value Dictionary< TKey, TValue> : " + sw.Elapsed);



        }


    }

}
