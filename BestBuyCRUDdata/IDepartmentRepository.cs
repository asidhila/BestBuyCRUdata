using BestBuyCRUDdata;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    public interface IDepartmentRepository
    {
        //Saying we need a method called GetAllDepartments that returns a collection
        //That conforms to IEnumerable<T>
        
        public void InsertDepartment(string newDepartment);
        public IEnumerable<Department> GetAllDepartments();
        
    }
}


