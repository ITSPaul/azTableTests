using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AzureTableQuery.Models
{
    public class AzStorageManager
    {
        // Parse the connection string and return a reference to the storage account.
        CloudStorageAccount storageAccount;
        CloudTableClient tableClient;

        public AzStorageManager()
        {
           var appset = ConfigurationManager.AppSettings["StorageConnectionString"];
           storageAccount = CloudStorageAccount.Parse(
           ConfigurationManager.AppSettings["StorageConnectionString"]);
           tableClient = storageAccount.CreateCloudTableClient();

        }

        public CloudTable getCloudTable(string tableName)
        {
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference(tableName);

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            return table;
        }

        public bool AddEntry(string tableName, TableEntity entry)
        {
            CloudTable table = getCloudTable(tableName);
            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(entry);

            // Execute the insert operation.
            if (table.Execute(insertOperation).Result != null)
                return true;
            return false;
        }


        public List<ExamAzureTE> getCloudEntities(string tableName)
        {
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = getCloudTable(tableName);

            TableQuery<ExamAzureTE> query = new TableQuery<ExamAzureTE>();
            var entities = table.ExecuteQuery(query);
            if(entities.Count() > 0)
            {
                return entities.ToList();
            }

            return null;
        }

        public List<CloudTable> getTablesList()
        {
            CloudTableClient tableClient = new CloudTableClient(storageAccount.TableEndpoint, storageAccount.Credentials);
            var result = tableClient.ListTables().ToList();
            return result;
        }


    }
}