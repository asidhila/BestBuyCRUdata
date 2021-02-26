using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;
using System.Linq;
using IntroSQL;

namespace BestBuyCRUDdata
{
   public class DapperDepartmentRepository : IDepartmentRepository
    {
        // Field or (local variable for making queries to the DB
        private readonly IDbConnection _connection;
        private object newDepartmentName;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            // Constructor
            _connection = connection;
        }
        public IEnumerable<Department>GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM department");

            return depos;
        }

     
        public void InsertDepartment(string newDepartment)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
              new { departmentName = newDepartmentName });

        }
    }
}
