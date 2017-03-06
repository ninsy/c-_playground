using System;

namespace ConsoleApplication
{
    public class Program
    {   
        public enum Type {INT, STRING, DOUBLE };
        public static void Main(string[] args)
        {
            Stack<string> sStack = null;
            Stack<int> iStack = null;
            Stack<double> dStack = null;
            ConsoleKey key;
            
            
            do {
                Console.WriteLine("F1/F2/F3/F4/ESC");
                key = Console.ReadKey().Key;
                try {
                    switch(key) {
                        case ConsoleKey.F1:                     
                            // INIT
                            Type choice = pickType();
                            switch(choice) {
                                case Type.INT: iStack = initStackInt(); break;
                                case Type.DOUBLE: dStack = initStackDouble(); break;
                                case Type.STRING: sStack = initStackString(); break;    
                            }
                            break;
                
                        case ConsoleKey.F2:
                            // PUSH
                            string input = Console.ReadLine();
                            if(sStack != null) sStack.Push(input);
                            if(dStack != null) dStack.Push(Double.Parse(input));
                            if(iStack != null) iStack.Push(Int32.Parse(input));
                            break;
                        case ConsoleKey.F3:
                            // POP
                            if(sStack != null) sStack.Pop();
                            if(dStack != null) dStack.Pop();
                            if(iStack != null) iStack.Pop();
                            break;
                        case ConsoleKey.F4:
                            // PRINT
                            if(sStack != null) {
                                foreach(string chars in sStack) {
                                    Console.Write($"{chars} ");
                                }
                            }
                            if(iStack != null) {
                                foreach(int number in iStack) {
                                    Console.Write($"{number} ");                                    
                                }
                            }
                            if(dStack != null) {
                                foreach(int number in dStack) {
                                    Console.Write($"{number} ");                                    
                                }
                            }
                            break;
                    }
                } catch(StackException e) {
                    Console.WriteLine(e.ToString());
                }
                
            } while(key != ConsoleKey.Escape);

        }
        public static Type pickType() {
            Console.WriteLine("Pick type: I: int, D: double, S: string");
            switch(Console.ReadKey().Key) {
                case ConsoleKey.I: return Type.INT;
                case ConsoleKey.D: return Type.DOUBLE;
                case ConsoleKey.S: return Type.STRING;
                default: return Type.INT;                
            }
        }
        public static Stack<string> initStackString() {
            Console.Write("Insert stack size: ");    
            int size = Int32.Parse(Console.ReadLine());
            return new Stack<string>(size);
        }
        public static Stack<int> initStackInt() {
            Console.Write("Insert stack size: ");    
            int size = Int32.Parse(Console.ReadLine());
            return new Stack<int>(size);
        }
        public static Stack<double> initStackDouble() {
            Console.Write("Insert stack size: ");    
            int size = Int32.Parse(Console.ReadLine());
            return new Stack<double>(size);
        }
    }
}
