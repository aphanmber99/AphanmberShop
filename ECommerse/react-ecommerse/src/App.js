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
          removeFromCart: this.removeFromCart,
          addToCart: this.addToCart,
          login: this.login,
          addProduct: this.addProduct,
          clearCart: this.clearCart,
          checkOut: this.checkOut,
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
                  class="navbar-burger burger"
                  arial-expanded="false"
                  data-target="navbarBasicExample"
                  onclick={(e) => {
                    e.preventDefault();
                    this.setState({ showMenu: !this.state.showMenu });
                  }}
                >
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                </label> 
              </div>
              <div className = {'navvar-menu ${this.state.showMenu ? "is-active" : ""}'}>
                <Link to = "/products" className ="navbar-item">Product
                </Link>
                {this.state.user && this.state.user.accessLevel < 1 && (
                  <Link to = "/add-product" className = "navbar-item">Add Product
                  </Link>
                )}

                <Link to ="/cart" className= "navbar-item">Cart
                <span className="tag is primary"
                style ={{marginLeft: "5px"}}
                >
                  {Object.keys(this.state.cart).length}
                </span>
                </Link>
                {!this.state.user ?(
               <Link to = "/login" className = "navbar-item">Login
               </Link> ):(
                 <Link to="/" onClick={this.logout} className = "navbar-item">Logout</Link>
               )}
              </div>
            </nav>
            <Switch>
              <Route exact path ="/" components = {ProductList}/>
              <Route exact path ="/login" components = {Login}/>
              <Route exact path ="/add-product" components = {AddProduct}/>
              <Route exact path="/cart" component={Cart} />
              <Route exact path ="/products" components = {ProductList}/>
            </Switch>
          </div>
        </Router>
      </Context.Provider>
    );
  }
}
