using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication
{
   public class BinaryTree<T> : IEnumerable<T>  where T: IComparable, new(){

        class Node<T> where T : IComparable {
            public T value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node(T value) {
                this.value = value;
            }
            public int CompareTo(object other) {
                if(other == null) return 1;
                Node<T> otherNode = other as Node<T>;
                return this.value.CompareTo(otherNode.value);
            }
            public int CompareTo(T value) {
                return this.value.CompareTo(value);
            }
        }
    
        private Node<T> Root {get; set;} 
        
        public BinaryTree() { }
        private bool Contains(Node<T> CurrentNode, T value){
            if(CurrentNode.CompareTo(value) == 0) return true;
            else if(CurrentNode.CompareTo(value) == 1) return Contains(CurrentNode.Left, value);
            else return Contains(CurrentNode.Right, value);
        }
    
        public bool CheckIfContains(T value) {
            return Contains(Root, value);
        }
        // TODO: figure out how to Iterate over recursive data structs
        public IEnumerator<Node<T>> GetEnumerator() {
            yield return Root;
        }
        IEnumerator IEnumerable.GetEnumerator()  {  
            return GetEnumerator();  
        }  
   }
}
