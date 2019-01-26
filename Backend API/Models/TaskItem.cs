using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    /// <summary>
    /// Defines the <see cref="TaskItem" />
    /// </summary>
    public class TaskItem : ITaskItem
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public double Efforts { get; set; }
        public string Issue { get; set; }
    }
}
