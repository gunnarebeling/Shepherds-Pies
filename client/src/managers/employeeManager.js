const api_Url = "/api/employees"
export const getAllEmployees = () => {
    return fetch(api_Url).then(res => res.json())
}