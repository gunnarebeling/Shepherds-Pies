import { useEffect, useState } from "react"
import { completeOrder, getOrderDetails, updateDriverForOrder } from "../../managers/orderManager"
import { Link, useParams } from "react-router-dom"
import { Button, Input, Table } from "reactstrap"
import { formatPrice, formatTime } from "../../managers/formatingManager"
import { deletePizza } from "../../managers/pizzaManager"
import { UpdatePizza } from "../Pizza/updatePizza"
import { getAllEmployees } from "../../managers/employeeManager"


export const OrderDetails = () => {
    const [order, setOrder] = useState({})
    const [toggle, setToggle] = useState(false)
    const [newDriver, setnewDriver] = useState(0)
    const [allEmployees, setAllEmployees] = useState([])
    const {id} = useParams()

    
    useEffect(() => {
        getOrderDetails(id).then(setOrder)
        getAllEmployees().then(setAllEmployees)
    },[])
    useEffect(() => {
        setnewDriver(order.deliveryEmployeeId)
    },[order])

    const handleDelete = (e) => {
        if (order.pizzas.length === 1) {
            window.alert("must have at least one pizza on order")
        } else {
            const pizzaId = parseInt(e.target.dataset.id)
            deletePizza(pizzaId).then(() =>{
                getOrderDetails(id).then(setOrder)
            })
        }
    }
    const handleChange = (e) => {
        const driverid = parseInt(e.target.value)
        setnewDriver(driverid)
    }
    const handleSet = () => {
        updateDriverForOrder(id, newDriver).then(() => {
            getOrderDetails(id).then(setOrder)
            setToggle(t => !t)
        })
    } 
    const handleComplete = () => {
        completeOrder(id).then(() => {
            getOrderDetails(id).then(setOrder)
        })
    }

    return (
        <div className="container">
            <div className="d-flex">
                <h4 className="m-2">{order.orderDate?.split('T')[0]}</h4>
                <h4 className="m-2">{order.orderDate && formatTime(order.orderDate)}</h4>
            </div>
            <div className="d-flex">
                <h4 className="m-2">Order Details</h4>
                {order.deliveryEmployee && <Link className="m-2" onClick={() => setToggle(t => !t)}>edit driver</Link>}
                {toggle && 
                    <div className="d-flex">
                    <Input
                    type="select"
                    name="deliveryEmployeeId"
                    value={newDriver}
                    onChange={handleChange}
                    // isInvalid= {true}
                
                    >
                    {allEmployees.map(e => <option key={`employee-${e.id}`} value={e.id}>{e.fullName}</option>)}
                
                    </Input>
                    <Button onClick={handleSet}>set</Button>
                    </div>
                }

            </div>
            <Table>
                <tbody>
                    <tr>
                        <th>Ordered By</th>
                        <td>{order.orderEmployee?.fullName}</td>
                    </tr>
                    <tr>
                        <th>Delivery Person</th>
                        <td>{order.deliveryEmployee ? order.deliveryEmployee?.fullName : "dine-in"}</td>
                    </tr>
                    <tr>
                        <th>Total Cost with tip</th>
                        <td>{order.total && formatPrice(order.total)}</td>
                    </tr>
                    <tr>
                        <th>Tip amount</th>
                        <td>{order.tip && formatPrice(order.tip)}</td>
                    </tr>
                    <tr>
                        <th>Completed</th>
                        <td>{order.completed ? "completed" : "not completed"}</td>
                        <td><Button onClick={handleComplete}>Complete</Button></td>
                    </tr>
                </tbody>
            </Table>
            <div>
                <h5>Items</h5>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>size</th>
                        <th>Cheese</th>
                        <th>Sause</th>
                        <th>Toppings</th>
                        <th>Price</th>

                    </tr>
                </thead>
                <tbody>
                    {order.pizzas?.map(p => {
                        return (
                            <tr key={p.id}>
                                <th >{p.size?.type}</th>
                                <td>{p.cheese?.type}</td>
                                <td>{p.sauce?.type}</td>
                                <td>{
                                    p.toppings?.length > 0 ? 
                                    (<ul>
                                        {p.toppings?.map(t => {
                                            return <li key={t.id}>{t.type}</li>
                                        })}
                                    </ul>) :
                                    "no toppings"
                                    }
                                </td>
                                <td>{formatPrice(p.pizzaTotal)}</td>
                                <td><UpdatePizza pizza={p} setOrder={setOrder} order={order}/></td>
                                <td><Link className="m-2" onClick={handleDelete}>delete</Link></td>
                
                            </tr>
                        )
                    })}

                </tbody>
            </Table>
        </div>
    )
}