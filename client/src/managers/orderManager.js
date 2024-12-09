const api_Url = "/api/orders"

export const getAllOrders = () => {
    return fetch(api_Url).then(res => res.json())
}