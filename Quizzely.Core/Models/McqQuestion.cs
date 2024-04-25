using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Models
{
    public class McqQuestion : BaseQuestion
    {
        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }
    }
}
