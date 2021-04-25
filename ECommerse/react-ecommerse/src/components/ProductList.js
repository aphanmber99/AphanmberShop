import React from "react";
import { Link } from "react-router-dom";
import http from "../httpClient";
import ProductImage from "./ProductImage";

export default function ProductList() {
  const [listProductt, setProducts] = React.useState([]);

  React.useEffect(() => {
    _fetchProductData();
  }, []);

  const _fetchProductData = () => {
    http.get("/Product").then(({ data }) => {
      setProducts(data);
    });
  };

  const handleDelete = (itemId) => {
    var result = window.confirm("Item will delete?");
    if (result) {
      http.delete("/product/" + itemId).then(() => {
        _fetchProductData();
      });
    }
  };

  return (
    <div className="container">
      <div style={{padding: "20px 20px"}}>
      <button className="button is-success">
          <Link to="/product/0">New Product</Link>
      </button>
      </div>
      <table className="table" style={{ width: "100%" }}>
        <thead>
          <tr>
            <th>
              <abbr title="Product ID">ID</abbr>
            </th>
            <th>
              <abbr title="Product Name">Product Name</abbr>
            </th>
            <th>
              <abbr title="Product Price">Price</abbr>
            </th>
            <th>
              <abbr title="Product Image">Image</abbr>
            </th>
            <th>
              <abbr title="Product Description">Description</abbr>
            </th>
            <th></th>
          </tr>
        </thead>

        {listProductt.map((item) => (
          <tbody>
            <tr>
              <td>{item.proID}</td>
              <td>{item.proName}</td>
              <td>{item.proPrice}</td>
              <td>
                <ProductImage src={item.image} />
              </td>
              <td>{item.proDescription}</td>
              <td>
                <div className="buttons">
                  <button className="button is-primary">
                    <Link to={"/product/" + item.proID}>Edit</Link>
                  </button>
                  <button
                    className="button is-danger"
                    onClick={() => handleDelete(item.proID)}
                  >
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        ))}
      </table>
    </div>
  );
}
