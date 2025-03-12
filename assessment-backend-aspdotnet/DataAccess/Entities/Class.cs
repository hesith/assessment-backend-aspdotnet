using System;
using System.Collections.Generic;

namespace assessment_backend_aspdotnet.DataAccess.Entities;

public partial class Class
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Grade { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
