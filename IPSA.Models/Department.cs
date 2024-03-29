﻿namespace IPSA.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string EmloyeeRole { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
