import React from "react";
import { useHistory, useParams } from "react-router-dom";
import http from "../httpClient";

export default function EditProduct() {
  const { id } = useParams();
  const history = useHistory();
  const imageRef = React.useRef(null);
  const [listCates, setCates] = React.useState([]);
  //
  const [inputName, setInputName] = React.useState("");
  const [inputDes, setInputDes] = React.useState("");
  const [inputPrice, setInputPrice] = React.useState("");
  const [inputCategoryID, setInputCategoryID] = React.useState("");
  const [productId, setProductId] = React.useState(0);
  //
  React.useEffect(() => {
    if (Number(id) !== 0) {
      console.log(id);
      http.get("/product/" + id).then(({ data }) => {
        setProductId(data.proID);
        setInputName(data.proName);
        setInputDes(data.proDescription);
        setInputPrice(data.proPrice);
        setInputCategoryID(data.categoryId);
      });
    }
  }, [id]);

  React.useEffect(() => {
    http.get("/category").then(({ data }) => {
      setCates(data);
    });
  });

  const handleChangeName = (e) => setInputName(e.target.value);
  const handleChangePrice = (e) => setInputPrice(e.target.value);
  const handleChangeDes = (e) => setInputDes(e.target.value);
  const handleChangeCategoryID = (e) => setInputCategoryID(e.target.value);

  const handleCancel = () => history.goBack();

  const handleSubmit = () => {
    if (!inputName && !inputCategoryID && !inputPrice) {
      window.alert("Please fill the form below");
      return;
    }

    var productSubmit = {
      proID: productId,
      proName: inputName,
      proDescription: inputDes,
      proPrice: inputPrice,
      CategoryId: inputCategoryID,
      Image: imageRef.current.files[0] ?? null,
    };
    var formData = new FormData();
    for (const key in productSubmit) {
      formData.append(key, productSubmit[key]);
    }
    if (productSubmit.proID === 0) {
      http
        .post("/product", formData, {
          headers: {
            "Content-Type": "multipart/form-data;",
          },
        })
        .then(() => {
          history.goBack();
        });
    } else {
      http
        .put("/product/" + id, formData, {
          headers: {
            "Content-Type": "multipart/form-data;",
          },
        })
        .then(() => {
          history.goBack();
        });
    }
  };

  return (
    <div>
      <h3 className="title is-4 pt-5">Product Detail</h3>
      <div style={{ width: "60%", marginBottom: "" }}>
        <div className="field">
          <label>Product Name</label>
          <div className="control">
            <input
              className={"input " + (!inputName && "is-danger")}
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
              className={"input " + (!inputPrice && "is-danger")}
              type="number"
              placeholder="Text input"
              value={inputPrice}
              onChange={handleChangePrice}
            />
          </div>
        </div>
        <div className="field">
          <label>Description </label>
          <span style={{fontSize:0.5}}>Summary/Des</span>
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
            <div className="select">
              <select
                className={"input " + (!inputCategoryID && "is-danger")}
                value={inputCategoryID}
                onChange={handleChangeCategoryID}
              >
                <option value={0}>Choose Category</option>
                {listCates.map((item) => (
                  <option value={item.id}>{item.name}</option>
                ))}
              </select>
            </div>
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
            <button className="button is-link" onClick={handleSubmit}>
              Submit
            </button>
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
