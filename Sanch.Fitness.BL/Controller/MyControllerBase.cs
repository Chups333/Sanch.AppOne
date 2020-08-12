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
    /// Свой контроллер для повторяющихся методов
    /// </summary>
    public abstract class MyControllerBase
    {
        /// <summary>
        /// Метод сохранения
        /// </summary>
        /// <param name="name">Имя файла</param>
        /// <param name="item">Тип</param>
        protected void Save(string name, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }

        }
        /// <summary>
        /// Метод загрузки из файла
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="name">Имя файла</param>
        /// <returns>Еда</returns>
        protected T Load<T>(string name)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default;
                }
            }

        }
    }
}
