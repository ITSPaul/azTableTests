using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureTableQuery.Models
{
    public class ExamAzureTE : TableEntity
    {
        public string ExamName { get; set; }
        public string ip { get; set; }

        public string Name { get; set; }

        public string CopyID { get; set; }
    }
}