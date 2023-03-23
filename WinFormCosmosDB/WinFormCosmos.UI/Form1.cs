using Microsoft.Azure.Cosmos;
using Microsoft.VisualBasic.Devices;
using System.Net;
using WinFormCosmos.Entities;
using WinFormCosmos.Model;

namespace WinFormCosmos.UI
{
    public partial class Form1 : Form
    {
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://localhost:8081";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "NorthWind";
        private string containerId = "Products";

        public Form1()
        {
            InitializeComponent();
            GetStartedDemoAsync();
        }

        private async void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MainManager.Instance.InitProducts();
                foreach (var product in MainManager.Instance.productsList)
                {
                    await AddProductToContainerAsync(product);
                }
                MessageBox.Show($"Import completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing products: {ex.Message}");
            }
        }

        private async void cheaperBtn_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(cheaperTxtBox.Text, out decimal price))
            {
                try
                {
                    var products = await QueryProductsCheaperThanAsync(price);
                    productsGridView.DataSource = products;
                    MessageBox.Show($"Select products cheaper than {price} completed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting products cheaper than {price}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid price value.");
            }
        }

        private async void supplierIdBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(supplierIdTxtBox.Text, out int supplierId))
            {
                try
                {
                    var products = await QueryProductsBySupplierIDAsync(supplierId);
                    productsGridView.DataSource = products;
                    MessageBox.Show($"Select all products completed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting all products: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid supplierId value.");
            }
        }

        private async void nameBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTxtBox.Text))
            {
                try
                {
                    var products = await QueryProductsStartWithAsync(nameTxtBox.Text.Trim());
                    productsGridView.DataSource = products;
                    MessageBox.Show($"Select all products completed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting all products: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid search string.");
            }
        }

        private async void allBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var products = await QueryProductsAsync();
                productsGridView.DataSource = products;
                MessageBox.Show($"Select all products completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting all products: {ex.Message}");
            }
        }

        public async Task GetStartedDemoAsync()
        {
            // Create a new instance of the Cosmos Client
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "CosmosDBDotnetQuickstart" });
            await CreateDatabaseAsync();
            await CreateContainerAsync();
        }

        private async Task CreateDatabaseAsync()
        {
            // Create a new database
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine("Created Database: {0}\n", database.Id);
        }

        private async Task CreateContainerAsync()
        {
            // Create a new container
            container = await database.CreateContainerIfNotExistsAsync(containerId, "/ProductName", 400);
            Console.WriteLine("Created Container: {0}\n", container.Id);
        }

        private async Task AddProductToContainerAsync(Product product)
        {
            try
            {
                ItemResponse<Product> productResponse = await container.ReadItemAsync<Product>(product.Id, new PartitionKey(product.ProductName));
                Console.WriteLine("Product in database with id: {0} already exists\n", productResponse.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                //product.Id = Guid.NewGuid().ToString();
                ItemResponse<Product> productResponse = await container.CreateItemAsync<Product>(product, new PartitionKey(product.ProductName));
                Console.WriteLine("Created Product in database with id: {0} Operation consumed {1} RUs.\n", productResponse.Resource.Id, productResponse.RequestCharge);
            }
        }

        private async Task<List<Product>> QueryProductsAsync()
        {
            var sqlQueryText = "SELECT * FROM Products";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

            List<Product> products = new List<Product>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Product product in currentResultSet)
                {
                    products.Add(product);
                    Console.WriteLine("\tRead {0}\n", product);
                }
            }

            return products;
        }

        private async Task<List<Product>> QueryProductsCheaperThanAsync(decimal price)
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.UnitPrice < @price";
            var queryDefinition = new QueryDefinition(sqlQueryText).WithParameter("@price", price);

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

            List<Product> products = new List<Product>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Product product in currentResultSet)
                {
                    products.Add(product);
                    Console.WriteLine("\tRead {0}\n", product);
                }
            }

            return products;
        }

        private async Task<List<Product>> QueryProductsStartWithAsync(string letters)
        {
            var sqlQueryText = $"SELECT * FROM c WHERE STARTSWITH(c.ProductName, @letters)";
            var queryDefinition = new QueryDefinition(sqlQueryText).WithParameter("@letters", letters);

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

            List<Product> products = new List<Product>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Product product in currentResultSet)
                {
                    products.Add(product);
                    Console.WriteLine("\tRead {0}\n", product);
                }
            }

            return products;
        }

        private async Task<List<Product>> QueryProductsBySupplierIDAsync(int supplierID)
        {
            var sqlQueryText = $"SELECT * FROM c where c.SupplierID= @supplierID";
            var queryDefinition = new QueryDefinition(sqlQueryText).WithParameter("@supplierID", supplierID);

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            FeedIterator<Product> queryResultSetIterator = this.container.GetItemQueryIterator<Product>(queryDefinition);

            List<Product> products = new List<Product>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Product> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Product product in currentResultSet)
                {
                    products.Add(product);
                    Console.WriteLine("\tRead {0}\n", product);
                }
            }

            return products;
        }     
        //this.cosmosClient.Dispose();
    }
}