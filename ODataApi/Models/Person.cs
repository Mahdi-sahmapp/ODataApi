using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataApi.Models
{
    [Table("Person")]
    public partial class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }
        public string? Phone { get; set; }

        public virtual City? City { get; set; }
    }
}
