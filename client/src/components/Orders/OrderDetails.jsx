import { useEffect, useState } from "react"
import { getOrderDetails } from "../../managers/orderManager"
import { Link, useParams } from "react-router-dom"
import { Table } from "reactstrap"
import { formatPrice, formatTime } from "../../managers/formatingManager"

export const OrderDetails = () => {
    const [order, setOrder] = useState({})
    const {id} = useParams()

    useEffect(() => {
        getOrderDetails(id).then(setOrder)
    },[])

    return (
        <div className="container">
            <div className="d-flex">
                <h4 className="m-2">{order.orderDate?.split('T')[0]}</h4>
                <h4 className="m-2">{order.orderDate && formatTime(order.orderDate)}</h4>
            </div>
            <div className="d-flex">
                <h4 className="m-2">Order Details</h4>
                <Link className="m-2">edit</Link>

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
                                <td><Link className="m-2">edit </Link></td>
                                <td><Link>delete</Link></td>
                
                            </tr>
                        )
                    })}

                </tbody>
            </Table>
        </div>
    )
}