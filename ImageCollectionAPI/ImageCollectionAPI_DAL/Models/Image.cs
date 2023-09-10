using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCollectionAPI_DAL.Models
{
    public class Image
    {
        public long ImageId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string? Description { get; set; }
        public string Path { get; set; }

        [NotMapped] //Para no agregar esta property en la tabla sql
        public IFormFile formFile { get; set; }
    }
}
