using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.DataTransferObjects
{
    public class TofDto
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public new bool CorrectAnswer { get; set; }

        public string ExamName { get; set; }
    }
}
