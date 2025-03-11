using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.Application.Dto
{
    public class HuHuDto
    {
    }
    public class UploadImagesRequest
    {
        public IFormFile? MsterImage { get; set; } 
        public IFormFile? Template { get; set; }
    }
}
