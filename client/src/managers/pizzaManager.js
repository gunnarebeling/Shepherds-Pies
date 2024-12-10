const api_Url = "/api/pizzas"
export const deletePizza = (id) => {
    return fetch(`${api_Url}/${id}`,{
        method: 'DELETE'
    })
}