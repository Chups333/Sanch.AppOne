using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пища
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Название еды
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Protiens { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Каллории за 100 грамм продукта
        /// </summary>
        public double Callories { get; }
        /// <summary>
        /// Простой конструктор
        /// </summary>
        /// <param name="name">Название еды</param>
        public Food(string name) : this(name, 0, 0, 0, 0){ }
        /// <summary>
        /// Сложный конструктор
        /// </summary>
        /// <param name="name">Название еды</param>
        /// <param name="protiens">Протеины</param>
        /// <param name="fats">Жиры</param>
        /// <param name="carbohydrates">Углеводы</param>
        /// <param name="callories">Каллории</param>
        public Food(string name, double callories, double protiens, double fats, double carbohydrates)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название еды не может быть пустым или null", nameof(name));
            }

            if (protiens < 0)
            {
                throw new ArgumentException("Протеины не могут быть меньше нуля", nameof(protiens));
            }

            if (fats < 0)
            {
                throw new ArgumentException("Жиры не могут быть меньше нуля", nameof(fats));
            }

            if (carbohydrates < 0)
            {
                throw new ArgumentException("Углеводы не могут быть меньше нуля", nameof(carbohydrates));
            }

            if (callories < 0)
            {
                throw new ArgumentException("Каллории не могут быть меньше нуля", nameof(callories));
            }
            #endregion

            Name = name;
            Protiens = protiens / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Callories = callories / 100.0;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
