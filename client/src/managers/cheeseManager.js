const api_Url = "/api/cheeses"
export const getAllCheeses = () => {
    return fetch(api_Url).then(res => res.json())
}