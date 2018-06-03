using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab2
{
    [Serializable]

    class University : Organization
    {
        int universityCosts;

        public University(string s, int a, int b, int salary, int univCosts) : base(s, a, b, salary) { this.universityCosts = univCosts; }

        public override int countYearExpenses()
        {
            return persCount * mSalary * 12 + 20000 + universityCosts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            University org = obj as University; // возвращает null если объект нельзя привести к типу University
            if (org as University == null)
                return false;

            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount && org.universityCosts == this.universityCosts;
        }

        public bool Equals(University org) // аргумент типа University
        {
            if (org == null)
                return false;
            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount;
        }

        public static bool operator == (University first, University second)
        {
            if ((Object)first == null || (Object)second == null)//проверить на null
                return false;

            return first.Equals(second);
        }

        public static bool operator != (University first, University second)
        {
            if ((Object)first == null || (Object)second == null)//проверить на null
                return false;

            return first.Equals(second);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int bird = 1;

            foreach (char c in this.infoBoss)
            {
                hash += System.Convert.ToInt32(c) * bird;
                bird += 1;
            }
            hash += this.depCount * 100 + this.persCount * 200 + this.mSalary * 300 + this.universityCosts * 400;
            return hash;
        }

        public University DeepCopy()
        {
            University obj = new University(this.infoBoss, this.depCount, this.persCount, this.mSalary, this.universityCosts);
            return obj;
        }

    }
}

      