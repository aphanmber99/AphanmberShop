import React from "react";
import { Link } from "react-router-dom";
import http from "../httpClient";
import ProductImage from "./ProductImage";

export default function ProductList() {
  const [listProductt, setProducts] = React.useState([]);

  React.useEffect(() => {
    http.get("/product").then(({ data }) => {
      setProducts(data);
      console.log(data);
    });
  }, []);

  return (
    <div className="container">
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
              <abbr title="Product Image">Description</abbr>
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
                    <Link to={"/product/"+item.proID}>Edit</Link>
                  </button>
                  <button className="button is-danger">Delete</button>
                </div>
              </td>
            </tr>
          </tbody>
        ))}
      </table>
    </div>
  );
}
