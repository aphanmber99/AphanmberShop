import axios from "axios";
import { toast } from "react-toastify";

var http = axios.create({
  baseURL: "https://localhost:5001",
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
