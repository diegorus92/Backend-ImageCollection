using ImageCollectionAPI_BL.Dtos;
using ImageCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageCollectionAPI_BL.Services
{
    public interface IImageService
    {
        public bool CreateImage(ImageDTO image);
        public Image? GetImage(long id);
        public ICollection<Image> GetAll();
        public bool UpdateImage(long id, string newName, string newDescription);
        public bool DeleteImage(long id);
    }
}
