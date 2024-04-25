using Quizzely.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.DataTransferObjects
{
    public class McqDto
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        [Range(1,3)]
        public int CorrectAnswer { get; set; }

        public string ExamName { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }
    }
}
