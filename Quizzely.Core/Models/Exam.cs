using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Models
{
    public class Exam : BaseEntity<int>
    {
        public string Name { get; set; }

        public int NoOfQuestions { get; set; }
    }
}
