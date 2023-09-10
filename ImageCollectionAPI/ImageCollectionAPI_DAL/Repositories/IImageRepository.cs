using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageCollectionAPI_DAL.Models;

namespace ImageCollectionAPI_DAL.Repositories
{
    public interface IImageRepository
    {
        public void CreateImage(Image image);
        public Image? GetImage(long id);
        public ICollection<Image> GetAll();
        public void UpdateImage(Image image);
        public void DeleteImage(Image image);
    }
}
