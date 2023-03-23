import "./App.css";
import { useState } from "react";
import { CosmosClient } from "@azure/cosmos";

const endpoint = "https://localhost:8081";
const primaryKey =
  "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
const databaseId = "NorthWind";
const containerId = "Products";

function App() {
  const client = new CosmosClient({ endpoint, key: primaryKey });
  const container = client.database(databaseId).container(containerId);

  const [products, setProducts] = useState([]);
  const [searchText, setSearchText] = useState("");
  const [searchPrice, setSearchPrice] = useState(0);
  const [searchSupplierId, setSearchSupplierId] = useState("");

  const queryProductsByName = async () => {
    try {
      const querySpec = {
        query: `SELECT * FROM Products p WHERE STARTSWITH(p.ProductName, @name)`,
        parameters: [
          {
            name: "@name",
            value: searchText.trim(),
          },
        ],
      };
      const { resources } = await container.items.query(querySpec).fetchAll();
      setProducts(resources);
      alert(`Select products by name completed successfully.`);
    } catch (error) {
      alert(`Error selecting products by name: ${error.message}`);
    }
  };

  const queryProductsCheaperThan = async () => {
    try {
      const querySpec = {
        query: `SELECT * FROM Products p WHERE p.UnitPrice < @price`,
        parameters: [
          {
            name: "@price",
            value: parseFloat(searchPrice),
          },
        ],
      };
      const { resources } = await container.items.query(querySpec).fetchAll();
      setProducts(resources);
      alert(
        `Select products cheaper than ${searchPrice} completed successfully.`
      );
    } catch (error) {
      alert(
        `Error selecting products cheaper than ${searchPrice}: ${error.message}`
      );
    }
  };

  const queryProductsBySupplierId = async () => {
    try {
      const querySpec = {
        query: `SELECT * FROM Products p WHERE p.SupplierID = @supplierId`,
        parameters: [
          {
            name: "@supplierId",
            value: parseInt(searchSupplierId),
          },
        ],
      };
      const { resources } = await container.items.query(querySpec).fetchAll();
      setProducts(resources);
      alert(`Select products by supplier ID completed successfully.`);
    } catch (error) {
      alert(`Error selecting products by supplier ID: ${error.message}`);
    }
  };

  const queryAllProducts = async () => {
    try {
      const { resources } = await container.items.readAll().fetchAll();
      setProducts(resources);
      alert(`Select all products completed successfully.`);
    } catch (error) {
      alert(`Error selecting products by supplier ID: ${error.message}`);
    }
  };

  return (
    <div className="App">
      <h1>Product Search</h1>
      <form>
        <label>
          Search by Name:
          <input
            type="text"
            value={searchText}
            onChange={(e) => setSearchText(e.target.value)}
          />
        </label>
        <button type="button" onClick={queryProductsByName}>
          Search
        </button>
      </form>
      <form>
        <label>
          Search by Price:
          <input
            type="text"
            value={searchPrice}
            onChange={(e) => setSearchPrice(e.target.value)}
          />
        </label>
        <button type="button" onClick={queryProductsCheaperThan}>
          Search
        </button>
      </form>
      <form>
        <label>
          Search by Supplier ID:
          <input
            type="text"
            value={searchSupplierId}
            onChange={(e) => setSearchSupplierId(e.target.value)}
          />
        </label>
        <button type="button" onClick={queryProductsBySupplierId}>
          Search
        </button>
      </form>
      <button type="button" onClick={queryAllProducts}>
        Show All Products
      </button>
      <table>
        <thead>
          <tr>
            <th>Product ID</th>
            <th>Product Name</th>
            <th>Supplier ID</th>
            <th>Category ID</th>
            <th>Quantity Per Unit</th>
            <th>Unit Price</th>
            <th>Units In Stock</th>
            <th>Units On Order</th>
            <th>Reorder Level</th>
            <th>Discontinued</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product) => (
            <tr key={product.ProductID}>
              <td>{product.ProductID}</td>
              <td>{product.ProductName}</td>
              <td>{product.SupplierID}</td>
              <td>{product.CategoryID}</td>
              <td>{product.QuantityPerUnit}</td>
              <td>{product.UnitPrice}$</td>
              <td>{product.UnitsInStock}</td>
              <td>{product.UnitsOnOrder}</td>
              <td>{product.ReorderLevel}</td>
              <td>{product.Discontinued ? "Yes" : "No"}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
