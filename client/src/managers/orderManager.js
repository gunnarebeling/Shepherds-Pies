const api_Url = "/api/orders"

export const getAllOrders = () => {
    return fetch(api_Url).then(res => res.json())
}

export const getOrderDetails = (id) => {
    return fetch(`${api_Url}/${id}`).then(res => res.json())
}