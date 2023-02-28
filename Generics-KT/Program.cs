using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics_KT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ElementNotFoundException : Exception
    {

    }

    public class TestKeyValuePairs<T1, T2>
        where T1 : class
        where T2 : class
    {
        public T1 Key { get; private set; }
        public T2 Value { get; private set; }

        public TestKeyValuePairs(T1 key, T2 value)
        {
            Key = key; Value = value;
        }
    }

    public class TestDictionary<T1, T2> : IEnumerable<TestKeyValuePairs<T1, T2>>, 
        IEnumerator<TestKeyValuePairs<T1, T2>>
        where T1 : class
        where T2 : class
    {
        public List<TestKeyValuePairs<T1, T2>> Data = new List<TestKeyValuePairs<T1, T2>>();

        public TestKeyValuePairs<T1, T2> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Add(T1 key, T2 value)
        {
            foreach (TestKeyValuePairs<T1, T2> pair in Data)
                if (pair.Key.Equals(key))
                    throw new Exception("key already exists");
            Data.Add(new TestKeyValuePairs<T1, T2>(key, value));
        }
        public void Remove(T1 key)
        {
            foreach (TestKeyValuePairs<T1, T2> pair in Data)
                if (pair.Key.Equals(key))
                    Data.Remove(pair);
        }
        public void Remove(T2 value)
        {
            foreach (TestKeyValuePairs<T1, T2> pair in Data)
                if (pair.Value.Equals(value))
                    Data.Remove(pair);
        }
        public TestKeyValuePairs<T1, T2> Find(T1 key)
        {
            foreach (TestKeyValuePairs<T1, T2> pair in Data)
                if (pair.Key.Equals(key))
                    return pair;
            throw new ElementNotFoundException();
        }
        /*это какой-то странный метод, который вернёт лишь первую пару(value же может дублироваться), 
         * но плывём по тз*/
        public TestKeyValuePairs<T1, T2> Find(T2 value)
        {
            foreach (TestKeyValuePairs<T1, T2> pair in Data)
                if (pair.Value.Equals(value))
                    return pair;
            throw new ElementNotFoundException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TestKeyValuePairs<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
