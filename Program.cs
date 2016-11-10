using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordExamples
{
    class Program
    {
        public static readonly string ERROR_MESSAGE = "You got an error";

        public const string BETTER_ERROR_MESSAGE = "You have an error";     //Better way to hard-code strings!

        static void Main(string[] args)
        {
            int a = 10;
            for (int i = 0; i < 10; i++)
            {
                a = MethodDemonstratingFinally(a);
                Console.WriteLine("variable a is currently {0}", a);
            }
            //Console.ReadLine();

            InternalExample.Class2.CallClass1();    //I can call class 2 because it is public
                                                    //InternalExample.Class1  //Can't create an internal class from another assembly.  It's encapsulated.

            //ErrorMessage = "You have an error";   //Doesn't work, it's read-only
            //BETTER_ERROR_MESSAGE = "Sir, you have an error!";     //Doesn't work, constants are locked in!

            //TypeCastingExamples();

            ClassWithProtectedBase cwpb = new ClassWithProtectedBase();
            cwpb.SaySalary();
            



            

            int number = 100;
            MultiplyBy10(number);
            Console.WriteLine(number);
            MyObject o = new MyObject();

            o.MyNumber = 1;
            MultiplyBy10(o);
            Console.WriteLine(o);



            Console.ReadLine();

        }

        public static void TessaSaysHello()
        {
            Console.WriteLine("Hello from Tessa");
        }

        public static void MultiplyBy10(int number)
        {
            number = number * 10;
        }

        public static void MultiplyBy10(MyObject obj)
        {
            obj.MyNumber = obj.MyNumber * 10;

        }






        private static void TypeCastingExamples()
        {
            object u = new UninheritableClass();
            Type t = u.GetType();
            if (typeof(UninheritableClass) == t)
            {
                Console.WriteLine("u is an uninheritable class");
            }

            //byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\joewe\\Desktop\\week1classes.dll");


            if (u is UninheritableClass) //I'm using "IS" to examine Type information and test that my variable is an object of a given type.
            {
                ((UninheritableClass)u).SayHello();
            }

            u = "Hello";
            //((UninheritableClass)u).SayHello(); //OH NO, Runtime Exception

            UninheritableClass uc = u as UninheritableClass;    //Preferred way to do this!  Test and TypeCast in one step!
            if (uc != null)
            {
                uc.SayHello();
            }
        }

        public static int MethodDemonstratingFinally(int a)
        {
            Random r = new Random();
            int randomNumber = r.Next(0, 2);
            try
            {
                if (randomNumber == 1)
                    throw new Exception("I'm forcing an exception to be thrown randomly");
                //a++;
            }
            catch(OutOfMemoryException)
            {
                Console.WriteLine("We ran out of memory");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                //a++;  //Moved this to the finally block
            }
            finally
            {
                a++;
            }

            return a;


        }
    }

    public class MyObject
    {
        public int MyNumber;
    }

    //public class MyNewClass : UninheritableClass        //Doesn't work!
    //{

    //}

    public sealed class UninheritableClass
    {
        public UninheritableClass()
        {
            
        }

        public void SayHello()
        {
            Console.WriteLine("Hi, everybody!");
        }
    }

    public class ClassWithProtectedBase : ProtectedBaseClass
    {
        public void SaySalary()
        {
            Console.WriteLine(SalaryInformation);
        }
    }

    public class ProtectedBaseClass
    {
        protected decimal SalaryInformation = 100;
    }
}

