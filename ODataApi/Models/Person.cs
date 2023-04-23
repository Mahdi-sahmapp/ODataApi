using System;
using System.Collections.Generic;

namespace ODataApi.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }
        public string? Phone { get; set; }

        public virtual City? City { get; set; }
    }
}
