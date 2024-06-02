using FormsProject.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsProject.Repositorys.Controllers
{
    internal class VillageDb
    {
        public Village GetVillageByCode(int code)
        {
            Village? village = null;
            try
            {
                using var context = new InvEntities();
                village = context.Villages.Where(p => p.Code == code).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return village;
        }
    }
}
