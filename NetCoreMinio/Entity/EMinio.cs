using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMinio.Entity
{
    public class EMinio
    {
        public string minioIp { get; set; }
        public string secretKey { get; set; }
        public string accessKey { get; set; }

        public EMinio()
        {
            minioIp = "127.0.0.1:9000";
            secretKey = "minioadmin";
            accessKey = "minioadmin";
        }
    }
}
