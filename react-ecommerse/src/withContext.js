import React from "react";
import Context from "./Context";
//this is context wrapper
// is used to wrap component
const withContext = (WrappedComponent) => {
  const WithHOC = (props) => {
    return (
      <Context.Consumer>
        {(context) => <WrappedComponent {...props} context={context} />}
      </Context.Consumer>
    );
  };

  return WithHOC;
};

export default withContext;
