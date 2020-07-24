using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel;
using NetCoreMinio.Entity;
using NetCoreMinio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMinio.Services
{
    public class SMinio : IMinio
    {
        EMinio minioConn = new EMinio();

        MinioClient minioClient;

        public SMinio()
        {
            minioClient = new MinioClient(minioConn.minioIp, minioConn.secretKey, minioConn.accessKey);
        }

        public async Task<bool> Upload_File(IFormFile formFile,string bucketName,string fileName)
        {
            bool response = true;
            try
            {
                bool bucketFound = await minioClient.BucketExistsAsync(bucketName);
                if (!bucketFound)
                    minioClient.MakeBucketAsync(bucketName, "Tr-tr").Wait();
                using (Stream stream = formFile.OpenReadStream())
                {
                    await minioClient.PutObjectAsync(bucketName, fileName, stream, stream.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = false;
            }
            return response;
        }


        public async Task<bool> Delete_File(string bucketName,string fileName)
        {
            bool response = true;
            try
            {
                await minioClient.RemoveObjectAsync(bucketName, fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = false;
            }

            return response;
        }

        public async Task<bool> Exists_Bucket(string bucketName)
        {
            bool response = true;
            try
            {
                response =  await minioClient.BucketExistsAsync(bucketName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = false;
            }

            return response;
        }
    }
}
