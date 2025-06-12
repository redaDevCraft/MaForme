using System;

namespace MaForme.Models
{
    // Represents a user-created instance of a template with editable data
    public class FormInstance
    {
        public Guid InstanceId { get; set; } = Guid.NewGuid();
        public Guid TemplateId { get; set; }
        public string InstanceName { get; set; } // e.g. "Invoice for Client A"
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Store form data as JSON or a dictionary or your preferred format
        public string SerializedData { get; set; }

        public FormInstance(Guid templateId, string instanceName)
        {
            TemplateId = templateId;
            InstanceName = instanceName;
        }
    }
}
