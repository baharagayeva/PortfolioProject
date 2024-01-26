using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Experience : BaseEntity
    {
        public string CompanyName { get; set; }
        public int PositionID { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        [NotMapped]
        public bool IsContinue => LeaveDate == null;

        //Relationships
        public Position Position { get; set; }
    }
}
