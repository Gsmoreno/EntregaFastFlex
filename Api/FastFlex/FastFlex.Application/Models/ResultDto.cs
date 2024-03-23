using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFlex.Models.Models
{
    public class ResultDto
    {
        public bool Sucess { get; set; }
        public string? Mensagem { get; set; }
    }

    public class Result<T>
    {
        public bool Sucess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

    }
}