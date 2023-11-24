import axios, { AxiosRequestConfig, AxiosResponse } from "axios";
import Cookies from "js-cookie";
import { Router } from "next/router";
import { getCmsToken } from "./token";
import { successMsg } from "@/helper/message";

const baseURL = "https://localhost:44309/api/",
  isServer = typeof window === "undefined";

const api = axios.create({
  baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});

// api.interceptors.request.use(async (config) => {
//   if (isServer) {

//   } else {
//     const token = await Cookies.get("Token");

//     console.log("tokentoken", token, typeof(token));

//     if (token !== 'undefined') {
//       config.headers["Authorization"] = `Bearer ${token}`;
//     }else{
//       await window.location.replace("/account/login");    
//     }
    
//   }

//   return config;
// });

// api.interceptors.response.use(
//   (response: AxiosResponse) => {
//     const { statusCode, message } = response.data;
//     const config = response.config || {};
//     if (statusCode === 200 && message === 'token_expired' && !config?.url?.includes('/auth/refreshToken')) {      
    
//     }
//     if(statusCode === 401){
//        window.location.replace("/account/login");
//        console.log("401")
//     }
//     return response;
//   },
//   (error) => {
//     return Promise.reject(error);
//   },
// );

export const middlewareRequest = async (config: any) => {
  const tokenAccess: any = getCmsToken()

  if (config.url && config.url.includes('login')) {
    return {
      ...config,
      headers: {
        ...config.headers,
        'Accept-Language': 'vi',
      },
    }
  }

  return {
    ...config,
    headers: {
      ...config.headers,
      'Accept-Language': 'vi',
      Authorization: `Bearer ${tokenAccess}`,
    },
  }
}

export const middlewareResponseError = async (error: any) => {
  const {
    config,
    response: { status },
  } = error

  const originalRequest = config
console.log(error, 'error')
  if (
    status === 401 
  ) {
    window.location.replace('/account/login')
    return Promise.reject(error)
  }

}

export const resTest = async(res : any) => {
  const { config, response } = res
    if(res.data.ErrorCode !== -1){
      console.log(res, "đây này response")
      return res
    }
   else return Promise.reject(res)
}

api.interceptors.request.use(middlewareRequest, (error: any) =>
  Promise.reject(error)
)

api.interceptors.response.use((res) => resTest(res), middlewareResponseError)

export const authApi = (options: AxiosRequestConfig) => {
  return api({
    baseURL:baseURL ,
    ...options,
  })
}
export default api;
