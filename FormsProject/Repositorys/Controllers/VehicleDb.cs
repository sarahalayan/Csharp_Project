using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsProject.Repositorys.Models;

namespace FormsProject.Repositorys.Controllers
{
    internal class VehicleDb
    {
        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles= new List<Vehicle>();
            try
            {
                var context = new InvEntities();
                vehicles = context.Vehicles.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or provide a more informative message to the user
                Console.WriteLine($"Error retrieving vehicles: {ex.Message}");
                throw; // Re-throw the exception for further handling (optional)
            }
            return vehicles;
        }
        ////lezem b3d ektob function li bt3ml filter 7asab shu l user b7ot
    }
}
