import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";

const authAxios: AxiosInstance = axios.create({});

const getToken = () => {
    const token = localStorage.getItem("auth");
    return token !== "none" ? `Bearer ${token}` : null;
}

const onRequest = (config: AxiosRequestConfig): AxiosRequestConfig => {
    if (!config) {
        config = {}
    }
    if (!config.headers) {
        config.headers = {}
    }
    if (!config.headers.Authorization) {
        config.headers.Authorization = getToken();
    }
    return config;
}

const onRequestError = (error: AxiosError): Promise<AxiosError> => {
    return Promise.reject(error);
}

const onResponse = (response: AxiosResponse): AxiosResponse => {
    return response;
}

const onResponseError = (error: AxiosError): Promise<AxiosError> => {
    return Promise.reject(error);
}

authAxios.interceptors.request.use(onRequest, onRequestError);
authAxios.interceptors.response.use(onResponse, onResponseError);

export default authAxios;
