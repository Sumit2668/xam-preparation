using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class Property
    {
        public string prop_name { get; set; }
        public string prop_desc { get; set; }
        public bool IsVisible { get; set; }
    }

    public class Heading
    {
        public string name { get; set; }
        public ObservableCollection<Property> properties { get; set; }
    }

    public class MainHeading
    {
        public string control_name { get; set; }
        public ObservableCollection<Heading> headings { get; set; }
    }
}
