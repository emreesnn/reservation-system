import axios from "axios";

const API = axios.create({
    baseURL: "https://localhost:7000/api", 
});

// JWT token'ı her isteğe ekle
API.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default API;
