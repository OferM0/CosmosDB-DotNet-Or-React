using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WinFormCosmos.Dal
{
    //public class CosmosQuery
    //{
    //    // The Azure Cosmos DB endpoint for running this sample.
    //    private static readonly string EndpointUri = "https://localhost:8081";

    //    // The primary key for the Azure Cosmos account.
    //    private static readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    //    // The Cosmos client instance
    //    private CosmosClient cosmosClient;

    //    // The database we will create
    //    private Database database;

    //    // The container we will create.
    //    private Container container;

    //    // The name of the database and container we will create
    //    private string databaseId = "NorthWind";
    //    private string containerId = "Products";

    //    private async Task CreateDatabaseAsync()
    //    {
    //        // Create a new database
    //        this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
    //        Console.WriteLine("Created Database: {0}\n", this.database.Id);
    //    }

    //    private async Task CreateContainerAsync()
    //    {
    //        // Create a new container
    //        this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName", 400);
    //        Console.WriteLine("Created Container: {0}\n", this.container.Id);
    //    }

    //    private async Task AddProductToContainerAsync(Product product)
    //    {
    //        try
    //        {
    //            ItemResponse<Product> productResponse = await this.container.ReadItemAsync<Product>(product.Id, new PartitionKey(product.UnitPrice));
    //            Console.WriteLine("Product in database with id: {0} already exists\n", productResponse.Resource.Id);
    //        }
    //        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
    //        {
    //            ItemResponse<Product> productResponse = await this.container.CreateItemAsync<Product>(product.Id, new PartitionKey(product.UnitPrice));
    //            Console.WriteLine("Created Product in database with id: {0} Operation consumed {1} RUs.\n", productResponse.Resource.Id, productResponse.RequestCharge);
    //        }
    //    }

    //    private async Task QueryProductsAsync()
    //    {
    //        var sqlQueryText = "SELECT * FROM Products";

    //        Console.WriteLine("Running query: {0}\n", sqlQueryText);

    //        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
    //        FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

    //        List<Product> products = new List<Product>();

    //        while (queryResultSetIterator.HasMoreResults)
    //        {
    //            FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
    //            foreach (Product product in currentResultSet)
    //            {
    //                products.Add(product);
    //                Console.WriteLine("\tRead {0}\n", product);
    //            }
    //        }
    //    }

    //    private async Task QueryProductsCheaperThanAsync(string price)
    //    {
    //        var sqlQueryText = $"SELECT * FROM Products where UnitPrice < {price}";

    //        Console.WriteLine("Running query: {0}\n", sqlQueryText);

    //        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
    //        FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

    //        List<Product> products = new List<Product>();

    //        while (queryResultSetIterator.HasMoreResults)
    //        {
    //            FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
    //            foreach (Product product in currentResultSet)
    //            {
    //                products.Add(product);
    //                Console.WriteLine("\tRead {0}\n", product);
    //            }
    //        }
    //    }

    //    private async Task QueryProductsStartWithAsync(string letters)
    //    {
    //        var sqlQueryText = $"SELECT * FROM Products where ProductName like %{letters}%";

    //        Console.WriteLine("Running query: {0}\n", sqlQueryText);

    //        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
    //        FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

    //        List<Product> products = new List<Product>();

    //        while (queryResultSetIterator.HasMoreResults)
    //        {
    //            FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
    //            foreach (Product product in currentResultSet)
    //            {
    //                products.Add(product);
    //                Console.WriteLine("\tRead {0}\n", product);
    //            }
    //        }
    //    }

    //    private async Task QueryProductsBySupplierIDAsync(string SupplierID)
    //    {
    //        var sqlQueryText = $"SELECT * FROM Products where SupplierID={supplierID}";

    //        Console.WriteLine("Running query: {0}\n", sqlQueryText);

    //        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
    //        FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

    //        List<Product> products = new List<Product>();

    //        while (queryResultSetIterator.HasMoreResults)
    //        {
    //            FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
    //            foreach (Product product in currentResultSet)
    //            {
    //                products.Add(product);
    //                Console.WriteLine("\tRead {0}\n", product);
    //            }
    //        }
    //    }      
    //    //this.cosmosClient.Dispose();
    //}
}
