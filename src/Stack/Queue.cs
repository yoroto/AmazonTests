using System;
using System.Collections.Generic;

namespace Stack
{
    public class Queue<T>
    {
        private readonly Stack<T> _pushT;
        private readonly Stack<T> _popT;

        public Queue()
        {
            _pushT = new Stack<T>();
            _popT = new Stack<T>();
        }

        public T Pop() => Get(_popT.Pop);

        public T Peek() => Get(_popT.Peek);

        private T Get(Func<T> op)
        {
            if (_popT.Count == 0)
                Move();
            return op();
        }

        public void Push(T item)
            => _pushT.Push(item);

        private void Move()
        {
            while(_pushT.Count != 0)
                _popT.Push(_pushT.Pop());
        }
    }
}
