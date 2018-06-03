using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab2
{
    [Serializable]

    abstract class Organization
    {
        string infoAboutTheBoss;
        int departamentCount;
        int personCount;
        int midSalary;

        public string infoBoss
        {
            get { return infoAboutTheBoss; }
        }

        public int depCount
        {
            get { return departamentCount; }
        }

        public int mSalary
        {
            get { return midSalary; }
        }

        public int persCount
        {
            get { return personCount; }
        }

        public Organization(string s, int a, int b, int salary)
        {
            this.infoAboutTheBoss = s;
            this.departamentCount = a;
            this.personCount = b;
            this.midSalary = salary;

        }

        public abstract int countYearExpenses();

        public override string ToString()
        {
            return string.Format("Boss is {0} | departament count is {1} |\n| people count is {2} | midSalary is {3} |\n| Расход за год: {4} |\n", infoAboutTheBoss, departamentCount, persCount, midSalary, countYearExpenses());
        }


    }
}
