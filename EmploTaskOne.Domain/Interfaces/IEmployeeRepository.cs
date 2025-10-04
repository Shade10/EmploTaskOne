﻿using EmploTaskOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploTaskOne.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
    }
}
