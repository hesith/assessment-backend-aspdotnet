using System;
using System.Collections.Generic;

namespace assessment_backend_aspdotnet.DataAccess.Entities;

public partial class Enrollment
{
    public decimal Id { get; set; }

    public decimal StudentId { get; set; }

    public decimal SubjectId { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
