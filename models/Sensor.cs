using System;
using System.Collections.Generic;

namespace CRUD_damsDigitalTwinDB.models;

public partial class Sensor
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Measurement { get; set; }

    public string? Units { get; set; }

    public double? X { get; set; }

    public double? Y { get; set; }

    public double? Z { get; set; }

    public virtual ICollection<SensorDatum> SensorData { get; set; } = new List<SensorDatum>();
}
