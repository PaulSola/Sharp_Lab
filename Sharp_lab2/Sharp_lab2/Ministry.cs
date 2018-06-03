using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab2
{
    [Serializable]

    class Ministry : Organization
    {

        int ministryCosts;

        public Ministry(string s, int a, int b, int salary, int minCosts) : base(s, a, b, salary) { this.ministryCosts = minCosts; }


        public override int countYearExpenses()
        {
            return persCount * mSalary * 12 + 10000 + ministryCosts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Ministry org = obj as Ministry; // возвращает null если объект нельзя привести к типу Ministry
            if (org as Organization == null)
                return false;

            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount && org.ministryCosts == this.ministryCosts;
        }

        public bool Equals(Ministry org) // аргумент типа Ministry
        {
            if (org == null)
                return false;
            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount;
        }

        public static bool operator ==(Ministry first, Ministry second)
        {
            if ((Object)first == null || (Object)second == null)//проверить на null
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(Ministry first, Ministry second)
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
            hash += this.depCount * 100 + this.persCount * 200 + this.mSalary * 300 + this.ministryCosts * 400;
            return hash;
        }

        public Ministry DeepCopy()
        {
            Ministry obj = new Ministry(this.infoBoss, this.depCount, this.persCount, this.mSalary, this.ministryCosts);
            return obj;
        }

    }
}
