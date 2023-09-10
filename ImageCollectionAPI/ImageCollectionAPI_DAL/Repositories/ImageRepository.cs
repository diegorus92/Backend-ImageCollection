using ImageCollectionAPI_DAL.Data;
using ImageCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCollectionAPI_DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly CollectionContext _context;

        public ImageRepository(CollectionContext context)
        {
            _context = context;
        }



        public void CreateImage(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void DeleteImage(Image image)
        {
            _context.Images.Remove(image);
            _context.SaveChanges();
        }

        public ICollection<Image> GetAll()
        {
            ICollection<Image> images = _context.Images.ToList();
            return images;
        }

        public Image? GetImage(long id)
        {
            Image? image = _context.Images.Find(id);
            return image != null ? image : null;
        }

        public void UpdateImage(Image image)
        {
            _context.Images.Update(image);
            _context.SaveChanges();
        }
    }
}
