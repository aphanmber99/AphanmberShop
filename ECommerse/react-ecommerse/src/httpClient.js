import axios from "axios";

var http = axios.create({
    baseURL:"https://localhost:5001"
})
export default http;