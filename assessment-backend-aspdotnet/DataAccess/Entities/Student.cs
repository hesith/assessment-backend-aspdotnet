using System;
using System.Collections.Generic;

namespace assessment_backend_aspdotnet.DataAccess.Entities;

public partial class Student
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Age { get; set; }

    public string? Address { get; set; }

    public decimal? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
