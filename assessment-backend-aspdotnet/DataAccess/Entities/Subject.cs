using System;
using System.Collections.Generic;

namespace assessment_backend_aspdotnet.DataAccess.Entities;

public partial class Subject
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Teacher { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
