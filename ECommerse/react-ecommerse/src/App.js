import "./App.css";
import 'react-toastify/dist/ReactToastify.css';
import React from "react";
import { Component } from "react";
import { Switch, Route, Link, BrowserRouter as Router } from "react-router-dom";
import { ToastContainer } from 'react-toastify';


//components
//Manage User, Category, Product

import Login from "./components/Login";
import ProductList from "./components/ProductList";
import EditProduct from "./components/EditProduct";
import Context from "./Context";
import User from "./components/User";
import Category from "./components/Category";
import EditCategory from "./components/EditCategory";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: null,
      cart: {},
      category: [],
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
                  <Link to="/User" className="navbar-item">
                    User
                  </Link>
                </span>
                <span>
                  <Link to="/Category" className="navbar-item">
                    Category
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
              <Route exact path="/category" >
                <Category/>
              </Route>
              <Route path="/category/:ID">
                <EditCategory/>
              </Route>
              <Route path="/User">
                <User/>
              </Route>
              <Route path="/login">
                <Login/>
              </Route>
              <Route path="*" components={Login} />
            </Switch>
            <ToastContainer autoClose={2500} />
            </div>
          </div>
        </Router>
      </Context.Provider>
    );
  }
}
