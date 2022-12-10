import axiosInstance from "../connectionConfigs/axiosInstance";
import config from "../connectionConfigs/config.json";
const baseUrl = config.api.returningRequest;

const CreateReturnRequest = async (id) => {
    let url = baseUrl + `${id}`;
    const response = await axiosInstance.post(url);
    //localStorage.setItem("userName", response.data.username);
    return response.data;
};

export {
    CreateReturnRequest
};