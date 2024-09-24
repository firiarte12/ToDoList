using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entity;

public class ToDo : BaseEntity
{    
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty ;
    public string status { get; set; } = string.Empty;
}
