using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class SetOfStacks<T>
    {
        private readonly List<Stack<T>> _stacks;
        private readonly int _capacity;

        public SetOfStacks(int capacity)
        {
            _stacks = new List<Stack<T>>();
            _capacity = capacity;
        }

        public T Pop()
        {
            while(_stacks.Count != 1 && _stacks.Last().Count == 0)
                _stacks.RemoveAt(_stacks.Count - 1);

            return _stacks.Last().Pop();
        }

        public T PopAt(int index)
        {
            if (index < _stacks.Count && _stacks[index].Count > 0)
                _stacks[index].Pop();
            throw new InvalidOperationException();
        }

        public void Push(T item)
        {
            if (_stacks.Count == _capacity)
                _stacks.Add(new Stack<T>(_capacity));
            _stacks.Last().Push(item);
        }
    }
}
