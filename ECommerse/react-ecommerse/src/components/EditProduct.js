import React from "react";
import { useHistory, useParams } from "react-router-dom";
import http from "../httpClient";

export default function EditProduct() {
  const { id } = useParams();
  const history = useHistory();
  const [productEdit, setProductEdit] = React.useState(null);
  const imageRef = React.useRef(null);
  //
  const [inputName, setInputName] = React.useState("");
  const [inputDes, setInputDes] = React.useState("");
  const [inputPrice, setInputPrice] = React.useState("");
  const [inputCategoryID, setInputCategoryID] = React.useState("");
  
  React.useEffect(() => {
    http.get("/product/" + id).then(({ data }) => {
    setProductEdit(data);
      setInputName(data.proName);
      setInputDes(data.proDescription);
      setInputPrice(data.proPrice);
      setInputCategoryID(data.categoryId);
    });
  }, [id]);

  const handleChangeName = (e) => setInputName(e.target.value);
  const handleChangePrice = (e) => setInputPrice(e.target.value);
  const handleChangeDes = (e) => setInputDes(e.target.value);
  const handleChangeCategoryID = (e) => setInputCategoryID(e.target.value);

  const handleCancel = () => history.goBack();

  const handleSubmit = () => {
      var productSubmit ={
          prodId: id,
          proName: inputName,
          proDescription: inputDes,
          proPrice: inputPrice,
          CategoryId: inputCategoryID,
          Image: imageRef.current.files[0]
      }
      http.put("/product/"+id,productSubmit);
      console.log(productSubmit);
  };
  return (
    <div>
      <h3 className="title is-4 pt-5">Product Detail</h3>
      <div style={{ width: "60%", marginBottom: "" }}>
        <div className="field">
          <label>Product Name</label>
          <div className="control">
            <input
              className="input"
              type="text"
              placeholder="Text input"
              value={inputName}
              onChange={handleChangeName}
            />
          </div>
        </div>
        <div className="field">
          <label>Price</label>
          <div className="control">
            <input
              className="input"
              type="number"
              placeholder="Text input"
              value={inputPrice}
              onChange={handleChangePrice}
            />
          </div>
        </div>
        <div className="field">
          <label>Description</label>
          <div className="control">
            <input
              className="input"
              type="text"
              placeholder="Text input"
              value={inputDes}
              onChange={handleChangeDes}
            />
          </div>
        </div>
        <div className="field">
          <label>Category ID</label>
          <div className="control">
            <input
              className="input"
              type="text"
              placeholder="Text input"
              value={inputCategoryID}
              onChange={handleChangeCategoryID}
            />
          </div>
        </div>
        <div className="field">
          <label>Image</label>
          <div className="control">
            <input
              className="input"
              type="file"
              placeholder="Text input"
              ref={imageRef}
            />
          </div>
        </div>
        <div className="field is-grouped">
          <div className="control">
            <button className="button is-link" onClick={handleSubmit}>Submit</button>
          </div>
          <div className="control">
            <button className="button is-link is-light" onClick={handleCancel}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
