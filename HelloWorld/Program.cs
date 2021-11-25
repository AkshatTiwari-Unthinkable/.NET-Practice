using System;

namespace HelloWorld
{
    interface ICustomer1
    {
        void Print1();
    }

    interface ICustomer2
    {
        void Print2();
    }

    public class Customer : ICustomer1,ICustomer2
    {
        public void Print1()
        {
            Console.WriteLine("Method of interface 1");
        }

        public void Print2()
        {
            Console.WriteLine("Method of Interface 2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ICustomer1 refer1 = new Customer();
            refer1.Print1();
            ICustomer2 refer2 = new Customer();
            refer2.Print2();
        }
    }
}
