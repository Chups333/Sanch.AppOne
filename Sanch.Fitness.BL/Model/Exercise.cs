using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("Активность не может быть пустым",nameof(activity));
            }

            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым",nameof(user));
            }

            if (start < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("Невозможный старт", nameof(start));
            }

            if (finish < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("Невозможный финиш", nameof(finish));
            }
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
