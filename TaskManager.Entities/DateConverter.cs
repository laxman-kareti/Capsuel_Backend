using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TaskManager.Entities
{
    public class DateConverter : IsoDateTimeConverter

    {
        public DateConverter()
        {
            this.DateTimeFormat = "yyyy-MM-dd";
        }

    }
}
