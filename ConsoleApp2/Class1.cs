using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface A {
        public void Run() {
            Console.WriteLine("Hello");
        }
        public void run2();
    }

    public class Class1:A
    {
        public void run2() { 
            Console.WriteLine("World");
        }
        public static void Main() {
            Class1 c = new Class1();
            c.run2();
            // c.Run();
        }
    }
}