import React from "react";
import http from "../httpClient";


export default function User() {
  const [user, setUser] = React.useState([]);

  React.useEffect(() => {
    http.get("/user").then(({ data }) => {
      console.log(data)
      setUser(data);
    });
  }, []);
//Could not get the user data from BackEnd

  return (
    <div className="container">
      <table className="table" style={{ width: "100%" }}>
        <thead>
          <tr>
            <th>
              <abbr title="User ID">User ID</abbr>
            </th>
            <th>
              <abbr title="Email Address">Email Address</abbr>
            </th>
            <th>
              <abbr title="Product Image">Customer Name</abbr>
            </th>
            <th>
              <abbr title="Full Name">Phone Number </abbr>
            </th>
          
          </tr>
        </thead>
        {user && user.map((acc) => (
          <tbody key={acc.id}>
            <tr>
              <td>{acc.id}</td>
              <td>{acc.userName}</td>
              <td>{acc.email}</td>
              <td>{acc.phoneNumber ?? "No phone"}</td>
            </tr>
          </tbody>
        ))}
      </table>
    </div>
  );
}
