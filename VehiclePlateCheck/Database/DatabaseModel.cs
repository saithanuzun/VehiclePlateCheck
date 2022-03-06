using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using VehiclePlateCheck.Models;

namespace VehiclePlateCheck.Database
{
    public class DatabaseModel:VehiclePlate
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
