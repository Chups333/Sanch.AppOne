using Sanch.Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Controller
{
    public class EatingController : MyControllerBase
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        private readonly User user;
        /// <summary>
        /// Список принятой еды
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// Прием пищи
        /// </summary>
        public Eating Eating { get; }
        /// <summary>
        /// Контроллер записи приемов пищи
        /// </summary>
        /// <param name="user">Имя пользователя</param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }
       
        /// <summary>
        /// Добавление продукта 
        /// </summary>
        /// <param name="food">Название продукта</param>
        /// <param name="weight">Вес</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        /// <summary>
        /// Загрузка из файла 
        /// </summary>
        /// <returns>Список приемов</returns>
        private Eating GetEating()
        {
            return Load<Eating>("eatings.dat") ?? new Eating(user);
        }

        /// <summary>
        /// Загрузка из файла 
        /// </summary>
        /// <returns>Еда</returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>("foods.dat") ?? new List<Food>();
        }
        /// <summary>
        /// Сохранение списка приемов еды
        /// </summary>
        private void Save()
        {
            Save("foods.dat", Foods);
            Save("eatings.dat", Eating);
        }

    }
}
