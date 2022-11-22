import axiosInstance from "../connectionConfigs/axiosInstance";
import config from '../connectionConfigs/config.json';
// const baseUrl = config.api.asset;
const baseUrl = 'https://localhost:61631/api/Assets'

const getAsset = async() => {
    let url = `${baseUrl}`
    const response = await axiosInstance.get(url)

    return response.data;
}

const createAsset = async(requestData) => {
    let url = `${baseUrl}`
    const response = await axiosInstance.post(url, requestData)

    return response.data;
}

const updateAsset = async(id) => {
    let url = `${baseUrl}/${id}`
    // Handle this method
    // const reponse = await axiosInstance.delete(url, requestBody)

    // return reponse.data;
}

const deleteAsset = async(id) => {
    let url = `${baseUrl}/api/Assets/${id}`
    const reponse = await axiosInstance.delete(url)

    return reponse.data;
}

export {
    getAsset,
    createAsset,
    updateAsset,
    deleteAsset
}


