using AzureTableQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AzureTableQuery.Controllers
{
    [EnableCors("http://localhost:49812", "*","*")]    
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
            return azm.getTablesList().Select(t => new { name = t.Name });
        }

        [Route("ListNamesFromTable/TableName/{name}")]
        public dynamic getTablesListNames(string name)
        {
            AzStorageManager azm = new AzStorageManager();
            return azm.getCloudEntities(name).
                Select(s => new { id = s.Name }).Distinct();
        }

        [Route("ListEntriesFromTableForEntity/TableName/{name}/Entity/{id}")]
        public dynamic getTablesListNames(string name, string id)
        {
            AzStorageManager azm = new AzStorageManager();
            return azm.getCloudEntities(name).
                Where(s => s.Name == id).
                Select(s => new { s.ip, s.Name, Date = s.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss") }).
                OrderBy(o => o.Date);
        }
    }
}
