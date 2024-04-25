using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Models
{
    public class BaseQuestion : BaseEntity<int>
    {
        public string Header { get; set; }

        public string Body { get; set; }

        public int CorrectAnswer { get; set; }

        public Exam Exam { get; set; }

        public int ExamId { get; set; }
    }
}
