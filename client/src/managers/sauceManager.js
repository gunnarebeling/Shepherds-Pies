const api_Url = "/api/sauces"
export const getAllSauces = () => {
    return fetch(api_Url).then(res => res.json())
}