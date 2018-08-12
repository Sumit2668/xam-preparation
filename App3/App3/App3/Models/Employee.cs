using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    [Table("Employee")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
    }
}
