using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDPractice
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
