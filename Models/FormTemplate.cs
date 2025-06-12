using System;
using System.Collections.Generic;

namespace MaForme.Models
{
    // Represents a reusable form template blueprint
    public class FormTemplate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        // You can extend this with template metadata or serialized XAML structure if needed
        // For simplicity, assume templates are identified by Name and loaded from XAML Views

        public FormTemplate(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
