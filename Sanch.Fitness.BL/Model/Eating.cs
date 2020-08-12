using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Время приема пищи
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// Список принятой еды
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// Пользователь который принимает пищу
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Конструктор приема пищи
        /// </summary>
        /// <param name="user"></param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Добавление еды
        /// </summary>
        /// <param name="food">Название еды</param>
        /// <param name="weight">Вес</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
