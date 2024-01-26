using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class SkillDetail:BaseEntity
    {
        public int Level { get; set; } 
        public int SkillID { get; set; }

        //Relationships
        public Skill Skill { get; set; }
    }
}
