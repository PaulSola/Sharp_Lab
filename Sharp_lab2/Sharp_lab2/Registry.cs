using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sharp_lab2
{
    [Serializable]

    class Registry
    {

        //   Organization[] arrayObj = { unic, plant, minist };
        Organization[] ObjArray;
        public Registry()
        {
            Organization unic = new University("Нормальный, приходит вовремя", 3, 100, 1300, 20000);
            Organization plant = new Plant("Отличный, ценит работников", 5, 70, 1000, 10000);
            Organization minist = new Ministry("Неприемлемый, грабит", 10, 450, 1100, 200000);

            ObjArray = new Organization[] { unic, plant, minist };

            //printInfo(unic);
            //printInfo(plant);
            //printInfo(minist);
        }

        public Registry DeepCopy()
        {

            using (var ms = new System.IO.MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Registry)formatter.Deserialize(ms);
            }

        }

        public void printInfo(Organization org)
        {

            Console.WriteLine("Info about our boss: " + org.infoBoss + " \nCount of departaments is "
                + org.depCount + "\n Count of people is " + org.persCount + "\n Middle Salary is : " + org.mSalary + "\n Summary count Year Expenses is : " + org.countYearExpenses() + "\n");

        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < ObjArray.Length; i++)
                res = string.Concat(res, string.Concat(ObjArray[i] + "\n"));
            return res;
        }

    }

    class CastException : InvalidCastException
    {
        public CastException()
            : base() { }

        public CastException(string message)
            : base(message) { }

        public CastException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public CastException(string message, Exception innerException)
            : base(message, innerException) { }

        public CastException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

    class ArrTypeMismatchException : ArrayTypeMismatchException
    {
        public ArrTypeMismatchException()
            : base() { }

        public ArrTypeMismatchException(string message)
            : base(message) { }

        public ArrTypeMismatchException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ArrTypeMismatchException(string message, Exception innerException)
            : base(message, innerException) { }

        public ArrTypeMismatchException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }


    class DivideByZero : DivideByZeroException
    {
        public DivideByZero()
            : base() { }

        public DivideByZero(string message)
            : base(message) { }

        public DivideByZero(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public DivideByZero(string message, Exception innerException)
            : base(message, innerException) { }

        public DivideByZero(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

    class MyException3 : OutOfMemoryException
    {
        public MyException3()
            : base() { }

        public MyException3(string message)
            : base(message) { }

        public MyException3(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MyException3(string message, Exception innerException)
            : base(message, innerException) { }

        public MyException3(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }

}
