using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class StackException : Exception {
        private string message;
        public StackException(string msg) {
            this.message = msg;
        }
    }
    public class Stack<T> : IEnumerable<T> {
        private T[] values;
        private int top;
        public Stack(int size) {
            if(size <= 0) {
                throw new StackException("Stack must have size greater than one!");
            }
            values = new T[size];
        }
        public void Push(T t) {
            if(top == values.Length) throw new StackException("Stack is full.");
            values[top++] = t;
        }
        public T Pop() {
            if(top == 0) throw new StackException("Stack is empty.");
            return values[--top];
        }
        public IEnumerator<T> GetEnumerator() {
            for(int i = top -1; i >= 0; i--) {
                yield return values[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()  {  
            return GetEnumerator();  
        }  
        public IEnumerable<T> TopToBottom {
            get { return this; }
        }
        public IEnumerable<T> BottomToTop {
            get {
                for(int i = 0; i <= top; i++) {
                    yield return values[i];
                }
            }
        }
        public IEnumerable<T> TopN(int count) {
            int startIndex = count >= top ? 0 : top - count;
            for(int index = top -1; index >= startIndex; index--) {
                yield return values[index];
            }
        }
    }
}
