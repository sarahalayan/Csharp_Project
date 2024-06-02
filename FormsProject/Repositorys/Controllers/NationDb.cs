using FormsProject.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsProject.Repositorys.Controllers
{
    internal class NationDb
    {
        public Nation GetNationByCode(int code)
        {
            Nation? nation = null;
            try
            {
                using var context = new InvEntities();
                nation = context.Nations.Where(p => p.Code == code).FirstOrDefault();

            }
            catch
            {
                MessageBox.Show($"nation with code =${code} doesn't exist");
            }
        }
     }
 }
