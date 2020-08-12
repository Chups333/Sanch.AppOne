using Sanch.Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Controller
{
    public class DataBaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().Where(l => true).ToList();

            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);

                //var type = item.GetType();
                //if (type == typeof(User))
                //{
                //    db.Users.Add(item as User);
                //}
                //else if (type == typeof(Gender))
                //{
                //    db.Genders.Add(item as Gender);
                //}
                //else if (type == typeof(Food))
                //{
                //    db.Foods.Add(item as Food);
                //}
                //else if (type == typeof(Exercise))
                //{
                //    db.Exercises.Add(item as Exercise);
                //}
                //else if (type == typeof(Eating))
                //{
                //    db.Eatings.Add(item as Eating);
                //}
                //else if (type == typeof(Activity))
                //{
                //    db.Activities.Add(item as Activity);
                //}

                db.SaveChanges();
            }
        }

    }
}
