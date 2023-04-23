using System;
using System.Collections.Generic;

namespace ODataApi.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string? City1 { get; set; }
        public byte? State { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
