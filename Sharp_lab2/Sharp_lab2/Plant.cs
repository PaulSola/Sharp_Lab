using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab2
{
    [Serializable]

    class Plant : Organization
    {
        int plantCosts;

        public Plant(string s, int a, int b, int salary, int pCosts) : base(s, a, b, salary) { this.plantCosts = pCosts; }

        public override int countYearExpenses()
        {

            return persCount * mSalary * 12 + 5000 + plantCosts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Plant org = obj as Plant; // возвращает null если объект нельзя привести к типу Plant
            if (org as Organization == null)
                return false;

            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount && org.plantCosts == this.plantCosts;
        }

        public bool Equals(Plant org) // аргумент типа Plant
        {
            if (org == null)
                return false;
            return org.depCount == this.depCount && org.infoBoss == this.infoBoss && org.mSalary == this.mSalary && org.persCount == this.persCount && org.plantCosts == this.plantCosts;
        }

        public static bool operator == (Plant first, Plant second)
        {
            if ((Object)first == null || (Object)second == null)//проверить на null
                return false;

            return first.Equals(second);
        }

        public static bool operator != (Plant first, Plant second)
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
            hash += this.depCount * 100 + this.persCount * 200 + this.mSalary * 300 + this.plantCosts * 400;
            return hash;
        }

        public Plant DeepCopy()
        {
            Plant obj = new Plant(this.infoBoss, this.depCount, this.persCount, this.mSalary, this.plantCosts);
            return obj;
        }

    }
}

