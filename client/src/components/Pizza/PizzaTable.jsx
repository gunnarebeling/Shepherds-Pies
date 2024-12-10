/* eslint-disable react/prop-types */
import { Button, FormGroup, Table } from "reactstrap"
import { getAllSizes } from "../../managers/sizeManager"
import { getAllCheeses } from "../../managers/cheeseManager"
import { getAllSauces } from "../../managers/sauceManager"
import { useEffect, useState } from "react"
import { formatPrice } from "../../managers/formatingManager"

export const PizzaTable = ({formData, setFormData}) => {
    const [allSizes, setAllSizes] = useState([])
    const [allCheese, setAllCheese] = useState([])
    const [allSauce, setAllSauce] = useState([])
    const [pizzas, setPizzas] = useState([])

    useEffect(() => {
        getAllSizes().then(setAllSizes)
        getAllCheeses().then(setAllCheese)
        getAllSauces().then(setAllSauce)
        
    }, [])

    useEffect(() => {
        const newPizzas = formData.pizzas?.map(p =>{
        const sauce = allSauce.find(s => s.id === parseInt(p.sauceId))
        const size = allSizes.find(s => s.id === parseInt(p.sizeId) )
        const cheese = allCheese.find(c => c.id === parseInt(p.cheeseId) )
        const price = (p.toppings.length * 0.50) + size.price
            let pizza={
                id: p.id,
                sauce: sauce,
                size: size,
                cheese: cheese,
                price: formatPrice(price),
                toppings: p.toppings


            }
            return pizza
        })
        setPizzas(newPizzas)

        
    }, [allSauce,allCheese,allSizes, formData])

    const handleDelete = (e) => {
        const pizzaId = parseInt(e.target.dataset.id)
        let copy = {...formData}
        const filteredpizzas = copy.pizzas.filter(p => p.id !== pizzaId)
        copy.pizzas = filteredpizzas
        setFormData(copy)
    }
  
    return(
        <FormGroup>
            <h4>Pizza</h4>
            <Table>
                <thead>
                    <tr>
                        <th>size</th>
                        <th>Cheese</th>
                        <th>Sauce</th>
                        <th>Toppings</th>
                        <th>Price</th>

                    </tr>
                </thead>
                <tbody>
                    {pizzas?.map(p => {
                        
                        return(
                            <tr key={p.id}>
                                <th>{p.size?.type}</th>
                                <td>{p.cheese?.type}</td>
                                <td>{p.sauce?.type}</td>
                                <td>{
                                    <ul key={`pizza-${p.size?.id}`}>
                                        {p.toppings?.map(t => {
                                            return (
                                                <li key={t.id}>{t.type}</li>
                                            )
                                        })}
                                    </ul>
                                    
                                    }
                                </td>
                                <td>{p.price}</td>
                                <td>
                                    <Button data-id={p.id} onClick={handleDelete}>Delete</Button>
                                </td>
                            </tr>
                        )
            
                    })}

                </tbody>
            </Table>
        </FormGroup>
    )
}