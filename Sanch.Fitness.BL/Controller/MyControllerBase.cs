using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
        protected IDataSaver manager = new DataBaseDataSaver();
        protected void Save<T>(List<T> item) where T : class 
        {
            manager.Save(item);
        }
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
