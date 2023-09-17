using ImageCollectionAPI_BL.Dtos;
using ImageCollectionAPI_DAL.Models;
using ImageCollectionAPI_DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace ImageCollectionAPI_BL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _serverPath;

        public ImageService(IImageRepository imageRepository, IConfiguration config)
        {
            _imageRepository = imageRepository;
            _serverPath = config.GetSection("Configuration").GetSection("ServerPath").Value;

        }



        public bool CreateImage(ImageDTO image)
        {
            string extension = image.formFile.FileName.Split('.')[1];

            if (extension != "jpg" && extension != "png")
                return false;

            string pathFile = Path.Combine(_serverPath, image.formFile.FileName); //Combine the file path in the folder where the image going to allocate with the file name

            try
            {
                //Copy the file choosed into server folder
                using(FileStream newFile =  System.IO.File.Create(pathFile))
                {
                    image.formFile.CopyTo(newFile);
                    newFile.Flush();
                }

                //Load the data of image in his sql table
                Image newImage = new Image();

                newImage.ImageId = 0; //Id = 0 means that the ID will be created automaticly
                newImage.Name = image.formFile.FileName.Split('.')[0];
                newImage.Extension = extension;
                newImage.Description = image.Description;
                newImage.Path = pathFile;

                _imageRepository.CreateImage(newImage);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool DeleteImage(long id)
        {
            Image? toDelete = _imageRepository.GetImage(id);
            if (toDelete != null)
            {

                try
                {

                    System.IO.File.Delete(toDelete.Path);

                }catch (Exception ex)
                {
                    Console.WriteLine("Error during deletion image: " + ex.Message);
                    return false;
                }

                _imageRepository.DeleteImage(toDelete);
                return true;
            }
            return false;
        }

        public ICollection<Image> GetAll()
        {
            return _imageRepository.GetAll();
        }

        public Image? GetImage(long id)
        {
            return _imageRepository.GetImage(id);
        }

        

        public bool UpdateImage(long id, string newName, string newDescription)
        {
            Image? toUpdate = _imageRepository.GetImage(id);

            if (toUpdate != null)
            {
                string newNameComplete = newName+"."+toUpdate.Extension;
                string newPath = Path.Combine(_serverPath, newNameComplete);

                try
                {
                    System.IO.File.Move(toUpdate.Path, newPath);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error during image move: "+ex.Message);
                    return false;
                }
                

                toUpdate.Name = newName;
                toUpdate.Description = newDescription;
                toUpdate.Path = newPath;

                _imageRepository.UpdateImage(toUpdate);
                return true;
            }

            return false;
        }
    }
}
