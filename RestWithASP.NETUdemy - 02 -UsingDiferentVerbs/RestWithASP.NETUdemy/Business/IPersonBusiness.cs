﻿using RestWithASP.NETUdemy.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.NETUdemy.Business.Implementation
{
    public interface IPersonBusiness
    {
        Person Create(Person person);

        Person FindById(long Id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long Id);

    }
}
