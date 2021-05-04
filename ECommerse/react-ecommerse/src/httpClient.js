import axios from "axios";
import { toast } from "react-toastify";

var http = axios.create({
  baseURL: "https://backend19e581e1a3fc4593a4e56901eb69aedb.azurewebsites.net",
});

http.interceptors.response.use(
  function (response) {
    if (response.config.method !== "get") toast.success("Successful!");
    return response;
  },
  function (error) {
    toast.error("Failed");
    return Promise.reject(error);
  }
);

export default http;
