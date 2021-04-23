import "./App.css";
import React from "react";
import { Component } from "react";
import { Switch, Route, Link, BrowserRouter as Router } from "react-router-dom";

//components
//Manage User, Category, Product
import AddProduct from "./components/AddProduct";
import Login from "./components/Login";
import ProductList from "./components/ProductList";
import Cart from "./components/Cart";
import EditProduct from "./components/EditProduct";
import Context from "./Context";


export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: null,
      cart: {},
      product: [],
    };
    this.routerRef = React.createRef();
  }

  render() {
    return (
      <Context.Provider
        value={{
          ...this.state,
          login: this.login,
          addProduct: this.addProduct,
        }}
      >
        <Router ref={this.routerRef}>
          <div className="App">
            <nav
              className="navbar container"
              role="navigation"
              aria-label="main navigation"
            >
              <div className="navbar-brand">
                <b className="navbar-item is size-4">Ecommerse</b>
                <label
                  role="button"
                  className="navbar-burger burger"
                  arial-expanded="false"
                  data-target="navbarBasicExample"
                  onClick={(e) => {
                    e.preventDefault();
                    this.setState({ showMenu: !this.state.showMenu });
                  }}
                >
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                </label>
              </div>
              <div className="is-flex is-align-items-center">
                <span>
                  <Link to="/" className="navbar-item">
                    Product
                  </Link>
                </span>
                <span>
                  {this.state.user && this.state.user.accessLevel < 1 && (
                    <Link to="/add-product" className="navbar-item">
                      Add Product
                    </Link>
                  )}
                </span>
                <span>
                  <Link to="/cart" className="navbar-item">
                    Carr
                  </Link>
                </span>
                <span>
                  {!this.state.user ? (
                    <Link to="/login" className="navbar-item">
                      Login
                    </Link>
                  ) : (
                    <Link to="/" onClick={this.logout} className="navbar-item">
                      Logout
                    </Link>
                  )}
                </span>
              </div>
            </nav>
            <div className="container">
            <Switch>
              <Route exact path="/" >
                <ProductList/>
              </Route>
              <Route path="/product/:id">
                <EditProduct/>
              </Route>
              <Route path="/add-product" >
                <AddProduct/>
              </Route>
              <Route path="/cart">
                <Cart/>
              </Route>
              <Route path="/login">
                <Login/>
              </Route>
              <Route path="*" components={Login} />
            </Switch>
            </div>
           
          </div>
        </Router>
      </Context.Provider>
    );
  }
}
