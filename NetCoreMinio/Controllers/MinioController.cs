using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreMinio.Interfaces;

namespace NetCoreMinio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinioController : Controller
    {
        IMinio _SMinio;

        public MinioController(IMinio _SMinio)
        {
            this._SMinio = _SMinio;
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> Upload_File(IFormFile file)
        {
            bool response = false;
            string bucketName = "bucket123";
            if (!await _SMinio.Upload_File(file, bucketName, file.FileName))
                return new JsonResult(response);
            else
                response = true;
                return new JsonResult(response);
        }

        [HttpDelete("deletefile")]
        public async Task<IActionResult> Delete_File(string bucketName,string fileName)
        {
            bool response = false;
            if (!await _SMinio.Delete_File(bucketName, fileName))
                return new JsonResult(response);
            else
                response = true;
                return new JsonResult(response);
        }

        [HttpPost("existsbucket")]
        public async Task<IActionResult> Exists_BucketName(string bucketName)
        {
            bool response = false;
            if (!await _SMinio.Exists_Bucket(bucketName))
                return new JsonResult(response);
            else
                response = true;
                return new JsonResult(response);
        }
    }
}
