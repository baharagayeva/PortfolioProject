﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }

        //Relationships
        public List<Person> Persons { get; set; }
    }
}
