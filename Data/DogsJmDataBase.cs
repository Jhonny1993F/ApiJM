using ApisJM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApisJM.Data
{
    public class DogsJmDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public DogsJmDataBase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<DogsJM>();
        }
        public int AddNewDogs(DogsJM dogs)
        {
            Init();
            if (dogs.id != null)
            {
                return conn.Update(dogs);
            }
            else
            {
                return conn.Insert(dogs);
            }
        }
        public List<DogsJM> GetAllDogs()
        {
            Init();
            List<DogsJM> dogs = conn.Table<DogsJM>().ToList();
            return dogs;
        }
        public int DeleteItem(DogsJM item)
        {
            Init();
            return conn.Delete(item);
        }
    }
}
