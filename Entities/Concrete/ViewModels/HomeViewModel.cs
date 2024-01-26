using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ViewModels
{
    public class HomeViewModel
    {
        public Person Person { get; set; }
        public List<Service> Services { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<SkillDetail> SkillDetails { get; set; }
        public List<WorkCategory> WorkCategories { get; set; }
        public List<Portfoli> Portfolis { get; set; }
        public List<Position> Positions { get; set; }
    }
}
