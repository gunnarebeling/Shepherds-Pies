const api_Url = "/api/sizes"
export const getAllSizes = () => {
    return fetch(api_Url).then(res => res.json())
}