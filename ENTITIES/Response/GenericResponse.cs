using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Response
{
    public class GenericResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class GenericResponse<T> : GenericResponse
    {
        public T Model { get; set; }
    }
}
