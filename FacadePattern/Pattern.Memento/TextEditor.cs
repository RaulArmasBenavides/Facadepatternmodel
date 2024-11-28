using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Memento
{
    public class TextEditor
    {
        private string _content;

        public void SetContent(string content)
        {
            _content = content;
        }

        public string GetContent()
        {
            return _content;
        }

        public Memento Save()
        {
            return new Memento(_content);
        }

        public void Restore(Memento memento)
        {
            _content = memento.State;
        }
    }

    public class History
    {
        private readonly Stack<Memento> _mementos = new();

        public void Push(Memento memento)
        {
            _mementos.Push(memento);
        }

        public Memento Pop()
        {
            return _mementos.Pop();
        }

        public bool HasHistory()
        {
            return _mementos.Count > 0;
        }
    }
}
