import React from "react";

const res = "https://localhost:5001/images/";
export default function ProductImage({ src }) {
  return <>{src ? <img width="150" src={res + src} /> : <span>no image</span>}</>;
}
