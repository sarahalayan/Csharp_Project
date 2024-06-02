using FormsProject.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsProject.Repositorys.Controllers
{
    internal class ImageAndFpDb
    {
        public ImageAndFp GetImageAndFpByIdAndSerper(int serial, int serpers)
        {
            ImageAndFp? imageandfp = null;
            try
            {
                using var context = new InvEntities();
                imageandfp = context.ImageAndFps.Where(p => p.Serial == serial & p.Serpers == serpers).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return imageandfp;
        }
        public void AddNew(ImageAndFp imageandfp)
        {
            try
            {
                ImageAndFp temp = GetImageAndFpByIdAndSerper(imageandfp.Serial, imageandfp.Serpers);
                if (temp == null)
                {
                    using var context = new InvEntities();
                    context.ImageAndFps.Add(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageAndFp item already exist");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void Update(ImageAndFp imageandfp)
        {
            try
            {
                ImageAndFp temp = GetImageAndFpByIdAndSerper(imageandfp.Serial, imageandfp.Serpers);
                if (temp != null)
                {
                    using var context = new InvEntities();
                    context.ImageAndFps.Update(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageAndFp item doesn't exist");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }
}
