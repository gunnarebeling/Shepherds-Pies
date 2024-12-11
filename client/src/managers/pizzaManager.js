const api_Url = "/api/pizzas"
export const deletePizza = (id) => {
    return fetch(`${api_Url}/${id}`,{
        method: 'DELETE'
    })
}

export const updatePizza = (pizzaForm) => {
    return fetch(`${api_Url}/${pizzaForm.id}`,{
        method: 'PUT',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(pizzaForm)
    })
}