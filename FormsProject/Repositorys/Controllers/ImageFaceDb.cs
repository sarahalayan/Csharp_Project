using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsProject.Repositorys;
using FormsProject.Repositorys.Models;
namespace FormsProject.Repositorys.Controllers
{
    internal class ImageFaceDb
    {
        public ImageFace GetImageFaceByIdAndSerper(int serial, int serpers)
        {
            ImageFace? imageFace = null;
            try
            {
                using var context = new InvEntities();
                imageFace = context.ImageFaces.Where(p => p.Serial == serial & p.Serpers == serpers).FirstOrDefault();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            return imageFace;
        }
        public void AddNew (ImageFace imageFace)
        {
            try 
            { 
                ImageFace temp = GetImageFaceByIdAndSerper(imageFace.Serial, imageFace.Serpers);
                if(temp == null)
                {
                    using var context=new InvEntities();
                    context.ImageFaces.Add(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageFace item already exist");
                }
            
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void Update(ImageFace imageFace)
        {
            try
            {
                ImageFace temp = GetImageFaceByIdAndSerper(imageFace.Serial, imageFace.Serpers);
                if (temp != null)
                {
                    using var context = new InvEntities();
                    context.ImageFaces.Update(temp);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ImageFace item doesn't exist");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

    }
}
