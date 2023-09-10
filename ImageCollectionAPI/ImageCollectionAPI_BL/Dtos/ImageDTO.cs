using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCollectionAPI_BL.Dtos
{
    public class ImageDTO
    {
        public string? Description { get; set; }

        public IFormFile formFile { get; set; }

    }
}
