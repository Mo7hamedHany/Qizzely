using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.DataTransferObjects
{
    public class AnswerDto
    {
        //public int Id { get; set; }
        public List<int?> McqAnswers { get; set; }
        public List<bool?> TofAnswers { get; set; }
    }
}
