using AzureTableQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureTableQuery.Controllers
{
    
    [RoutePrefix("api/az")]
    public class azTablesController : ApiController
    {
        [Route("GetAzureEntries/TableName/{name}")]
        public dynamic GetAzureEntries(string name)
        {
            AzStorageManager azm = new AzStorageManager();
            return azm.getCloudEntities(name).
                Select(s => new { s.ip, s.Name, Date = s.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss") });

        }


        [Route("ListTables")]
        public dynamic getTablesList()
        {
            AzStorageManager azm = new AzStorageManager();
            return azm.getTablesList().Select(t => t.Name);
        }



    }
}
