using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsProject.Repositorys;
using FormsProject.Repositorys.Models;

namespace FormsProject.Repositorys.Controllers
{
    internal class ImageFpDb
    {
        public ImageFp GetImageFpByIdAndSerper(int serial, int serpers)
        {
            ImageFp? imageFp = null;
            try
            {
                using var context = new InvEntities();
                imageFp = context.ImageFps.Where(p => p.Serial == serial & p.Serpers == serpers).FirstOrDefault();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            return imageFp;
        }
        public void AddNew (ImageFp imageFp)
        {
            try 
            { 
                ImageFp temp = GetImageFpByIdAndSerper(imageFp.Serial, imageFp.Serpers);
                if(temp == null)
                {
                    using var context=new InvEntities();
                    context.ImageFps.Add(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageFp item already exist");
                }
            
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void Update(ImageAndFp imageFp)
        {
            try
            {
                ImageFp temp = GetImageFpByIdAndSerper(imageFp.Serial, imageFp.Serpers);
                if (temp != null)
                {
                    using var context = new InvEntities();
                    context.ImageFps.Update(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageFp item doesn't exist");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }
}
