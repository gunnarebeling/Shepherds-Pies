const api_Url = "/api/orders"

export const getAllOrders = () => {
    return fetch(api_Url).then(res => res.json())
}

export const getOrderDetails = (id) => {
    return fetch(`${api_Url}/${id}`).then(res => res.json())
}

export const postOrder = (order) => {
    return fetch(api_Url,{
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    })
}

export const deleteOrder = (id) => {
    return fetch(`${api_Url}/${id}`,{
        method: 'DELETE'
    })
}
export const updateDriverForOrder = (id, driverId) => {
    return fetch(`${api_Url}/${id}/driver/${driverId}`,{
        method: 'PUT'
    })
}
export const completeOrder = (id) => {
    return fetch(`${api_Url}/${id}/complete`,{
        method: 'PUT'
    })
}