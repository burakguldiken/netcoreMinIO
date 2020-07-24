using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMinio.Interfaces
{
    public interface IMinio
    {
        Task<bool> Upload_File(IFormFile formFile, string bucketName, string fileName);
        Task<bool> Delete_File(string bucketName, string fileName);
        Task<bool> Exists_Bucket(string bucketName);
    }
}
