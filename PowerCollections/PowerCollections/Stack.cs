using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] storage;

        public int Count { get; private set; } = 0;
        public int Capacity => storage.Length;

        public Stack(int capacity = 100)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Длина стека должна быть больше нуля");
            storage = new T[capacity];
        }

        public void Push(T value)
        {
            if (Count >= Capacity)
                throw new InvalidOperationException("Стек переполнен");

            storage[Count++] = value;
        }

        public T Pop()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Стек пуст");

            return storage[--Count];
        }

        public T Top()
        {
            if (Count <= 0)
                throw new InvalidOperationException("Стек пуст");

            return storage[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
