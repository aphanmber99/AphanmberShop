import React from "react";
import { useHistory, useParams } from "react-router-dom";
import http from "../httpClient";


export default function EditCategory() {
  const { ID } = useParams();
  const history = useHistory();

  const [inputName, setInputName] = React.useState("");
  const [categoryId, setCategoryId] = React.useState(0);

  React.useEffect(() => {
      if(ID !== 0){
        http.get("/category/" + ID).then(({ data }) => {
            setInputName(data.name);
            setCategoryId(data.id);
          });
      }
  }, [ID]);

  const handleSubmit = () => {
    var categorySubmit = {
      ID: categoryId,
      Name: inputName,
    };
    if(categoryId === 0){
        http.post("/category",categorySubmit).then(()=>{
            history.goBack();
        })
    }
    else{
        http.put("/category/" + ID, categorySubmit).then(()=>{
            history.goBack();
        });
    }
  };

  const handleChangeName = (e) => setInputName(e.target.value);
  const handleCancel = () => history.goBack();

  return (
    <div>
      <h3 className="title is-4 pt-5">Category Detail</h3>
      <div style={{ width: "60%", marginBottom: "" }}>
        <div className="field">
          <label>Name</label>
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
