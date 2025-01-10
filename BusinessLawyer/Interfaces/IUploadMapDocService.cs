using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MigrateMap.Bal.Models.Request;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Interfaces
{
    public interface IUploadMapDocService
    {
        Task SaveMapDoc(object request);
        Task UpdateMapDoc(object request);
        
    }
}
