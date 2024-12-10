const api_Url = "/api/toppings"
export const getAllToppings = () => {
    return fetch(api_Url).then(res => res.json())
}