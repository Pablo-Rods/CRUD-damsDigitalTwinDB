using System;
using System.Collections.Generic;

namespace CRUD_damsDigitalTwinDB.models;

public partial class SensorDatum
{
    public Guid Id { get; set; }

    public string SensorId { get; set; } = null!;

    public double? Value { get; set; }

    public DateTime? DateTime { get; set; }

    public string SeriesName { get; set; } = null!;

    public virtual Sensor Sensor { get; set; } = null!;
}
