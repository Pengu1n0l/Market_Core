using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market_Core
{
    class Departments
    {
        private int _id_departement;
        private string _name;
        private string _manager;

        [Key]
        public int id_department
        {
            get
            {
                return _id_departement;
            }
            set
            {
                _id_departement = value;
            }
        }
        public string Name_department
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Manager
        {
            get
            {
                return _manager;

            }
            set
            {
                _manager = value;
            }
        }
        public Departments(int id_departement, string name, string manager)
        {
            id_department = id_departement;
            Manager = manager;
            Name_department = name;
        }
        public Departments(string name, string manager)
        {

            Name_department = name;
            Manager = manager;

        }
        public Departments()
        {

        }

   
    }
}
