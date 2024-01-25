using cinchiglemaMS6.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinchiglemaMS6
{
    public class PersonRepository
    {
        string dbPath; // ruta
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }
        public void Init()
        {
            if (conn is not null)
                return; 
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }
        public PersonRepository (string dbPath1)
        {
            dbPath = dbPath1;
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try 
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");
                Persona person = new() { Name = name};
                result = conn.Insert(person);
                StatusMessage = string.Format("{0} records added (Nombre: {1}", result, name);
            }
            catch (Exception ex)
            { 
            StatusMessage = string.Format ("ERROR{1}", name, ex.Message);
            }
        }

        public List<Persona> GetAllPeople() {
        try
            {  Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("ERROR", ex.Message);
            }
            return new List<Persona>();
        }
    }
}
