using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.DataTransferObjects
{
    public class ExamDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(1)]
        public int NoOfQuestions { get; set; }
    }
}
