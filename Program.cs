using System;
using System.Linq;
using CRUD_damsDigitalTwinDB.models;

using var db = new DamsDigitaltwinsDbContext();

//Create
Console.WriteLine("Insert a new sensor");
db.Add(new Sensor { Name = "Prueba", Measurement = "ninguna", Units = "1m/s", X = 123.45, Y = 123.45, Z = 123.45, Id = "MisPruebas2" });
db.SaveChanges();

//Read
Console.WriteLine("Querying a Sensor");
var sensor = db.Sensors.
    OrderBy(x => x.Id).
    First(x => x.Id == "MisPruebas2");
Console.WriteLine(sensor.Name);

//Update
Console.WriteLine("Update the created sensor");
sensor.Name = "Holaaaa";
db.SaveChanges();
var sensor2 = db.Sensors.
    OrderBy(x => x.Id).
    First(x => x.Id == "MisPruebas2");
Console.WriteLine(sensor2.Name);

// Delete
Console.WriteLine("Delete the sensor");
db.Remove(sensor2);
db.SaveChanges();


