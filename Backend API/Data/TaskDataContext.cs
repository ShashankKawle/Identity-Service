using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend_API.Models
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext (DbContextOptions<TaskDataContext> options): base(options)
        {
        }

        public DbSet<TaskItem> TaskItem { get; set; }
    }
}
