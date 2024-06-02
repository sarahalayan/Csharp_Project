using FormsProject.Repositorys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsProject.Repositorys.Controllers
{
    internal class InvestDb
    {
        public IEnumerable<Invest> GetInvests()
        {
            var invests = new List<Invest>();
            try
            {
                using var context = new InvEntities();
                invests = context.Invests.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or provide a more informative message to the user
                Console.WriteLine($"Error retrieving vehicles: {ex.Message}");
                throw; // Re-throw the exception for further handling (optional)
            }
            return invests;
        }

        public Invest GetInvestBySerial(int serial)
        {
            Invest? invest = null;
            try
            {
                using var context = new InvEntities();
                invest = context.Invests.Where(p => p.Serial == serial).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return invest;
        }
        public async Task<int> AddNewInvest( DateOnly dfile, DateOnly dmahdar, string crime, string madbout, string resume, string rem)
        {
            try
            {
                using var context = new InvEntities();
                // Get the maximum serial number for the Invest table
                int maxSerial = await context.Invests.MaxAsync(i => (int?)i.Serial) ?? 0; // Handle null case

                // Create a new Invest object with incremented serial number
                var newInvest = new Invest
                {
                    Serial = maxSerial + 1,
                    Dfile = dfile,
                    Dmahdar = dmahdar,
                    Crime = crime,
                    Madbout = madbout,
                    Resume = resume,
                    Rem = rem
                };

                context.Invests.Add(newInvest);
                await context.SaveChangesAsync();

                return newInvest.Serial; // Return the newly assigned serial number


            }
            catch (Exception ex)
            {
                // Handle exceptions here (e.g., log the error)
                Console.WriteLine($"Error adding new record to Invest: {ex.Message}");
                throw; // Re-throw the exception for further handling (optional)
            }
        }

        public void UpdateInvest(int serial,DateOnly dfile, DateOnly dmahdar, string crime, string madbout, string resume, string rem)
        {
            try
            {
                using var context = new InvEntities();
                Invest invest = GetInvestBySerial(serial);
                if (invest != null)
                {


                    // Create a new Invest object with incremented serial number
                    var newInvest = new Invest
                    {
                        Serial = serial,
                        Dfile = dfile,
                        Dmahdar = dmahdar,
                        Crime = crime,
                        Madbout = madbout,
                        Resume = resume,
                        Rem = rem
                    };

                    context.Invests.Update(newInvest);
                    context.SaveChanges();

                }


            }
            catch 
            {
                MessageBox.Show($"Invest with serial= ${serial} doesn't exist");
            }
        }
        public void DeleteInvest(int serial)
        {
            Invest invest = GetInvestBySerial(serial);
            if (invest != null)
            {
                using var context = new InvEntities();
                context.Invests.Remove(invest);
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show($"Invest with serial= ${serial} doesn't exist");
            }
        }

        public async Task<IEnumerable<Invest?>> GetInvestswithUniqueCrimes()
        {
                using var context = new InvEntities();

                try
                {
                    // Use Select and Distinct to get unique crime values
                    var uniqueCrimes = await context.Invests.Select(i => i.Crime).Distinct().ToListAsync();
                    return (IEnumerable<Invest?>)uniqueCrimes;
                }
                catch (Exception ex)
                {
                    // Handle exceptions here (e.g., log the error)
                    Console.WriteLine($"Error retrieving unique crimes: {ex.Message}");
                    throw; // Re-throw the exception for further handling (optional)
                }
            
        } 
        

    }
}
