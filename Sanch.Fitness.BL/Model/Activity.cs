using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CalloriesPerMinute { get; }

        public Activity(string name, double calloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя активности не может быть пустым", nameof(name));
            }

            if (calloriesPerMinute < 0)
            {
                throw new ArgumentException("Каллории не могут быть меньше нуля", nameof(calloriesPerMinute));
            }

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
