import React from "react";

import { Link } from "react-router-dom";
import http from "../httpClient";
//import ProductImage from "./ProductImage";

export default function Category() {
  const [listCategory, setListCategory] = React.useState([]);

  React.useEffect(() => {
    _fetchCategoryData();
  }, []);

  const _fetchCategoryData = () => {
    http.get("/category").then(({ data }) => {
      setListCategory(data);
      console.log(data);
    });
  };

  const handleDelete = (groupID) => {
    var result = window.confirm("Item will delete?");
    if (result) {
      http.delete("/category/" + groupID).then(() => {
        _fetchCategoryData();
      });
    }
  };

  return (
    <div className="container">
      <button className="button is-success">
        <Link to="/category/0">New Category</Link>
      </button>
      <table className="table" style={{ width: "100%" }}>
        <thead>
          <tr>
            <th>
              <abbr title="Category ID">ID</abbr>
            </th>
            <th>
              <abbr title="Category Name">Category Name</abbr>
            </th>
            <th></th>
          </tr>
        </thead>
        {listCategory &&
          listCategory.map((group) => (
            <tbody key={group.id}>
              <tr>
                <td>{group.id}</td>
                <td>{group.name}</td>
                <td>
                  <div className="buttons">
                    <button className="button is-primary">
                      <Link to={"/category/" + group.id}>Edit</Link>
                    </button>
                    <button
                      className="button is-danger"
                      onClick={() => handleDelete(group.id)}
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
