import axios from "axios";
import Cookies from "js-cookie";
import { Router } from "next/router";

const baseURL = "https://localhost:44309/api/",
  isServer = typeof window === "undefined";

const api = axios.create({
  baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});

api.interceptors.request.use(async (config) => {
  if (isServer) {

  } else {
    const token = Cookies.get("Token");

    console.log("tokentoken", token);

    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }else{
      // window.location.replace("/account/login");
      alert(1)
        
    }
    
  }

  return config;
});

export default api;
