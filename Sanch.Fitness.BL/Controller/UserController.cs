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
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController : MyControllerBase
    {
        /// <summary>
        /// Список пользователей приложения
        /// </summary>
        public List<User> Users { get; }//-небезопасно(лучше Ienumirable)
        /// <summary>
        /// Активный пользователь
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user">Пользователь</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns>Пользователи</returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>("users.dat") ?? new List<User>();
        }

        /// <summary>
        /// Ввод подробных данных
        /// </summary>
        /// <param name="genderName">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public void SetNawUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save("users.dat", Users);
        }
    }
}
