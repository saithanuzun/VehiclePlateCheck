using SQLite;
using VehiclePlateCheck.Models;

namespace VehiclePlateCheck.Database
{
    public class DatabaseModel:VehiclePlate
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
