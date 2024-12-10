import { useEffect, useState } from "react"
import { deleteOrder, getAllOrders } from "../../managers/orderManager"
import { FilterDate } from "./FilterDate"
import { Table } from "reactstrap"
import { Link } from "react-router-dom"
import { formatPrice, formatTime } from "../../managers/formatingManager"


export const OrdersList = () => {
    const [allOrders, setAllOrders] = useState([])
    const [filteredOrders, setFilter] = useState([])
    const today = new Date().toISOString().split('T')[0]
    useEffect(() => {
        getAllOrders().then(setAllOrders)
    }, [])

    useEffect(() => {
        let copy = [...allOrders]
        copy = copy.filter(a => a.orderDate?.split('T')[0] === today)
        setFilter(copy)

    }, [allOrders])

    const handleDelete = (e) => {
        const id = e.target.dataset.id
        deleteOrder(id).then(() => {
            getAllOrders().then(setAllOrders)
        })
    }


    return (
        <div className="container">
            <div className="sub-menu bg-light px-1">
                <h4>Orders</h4>
                <div className="m-2">
                    <FilterDate allOrders={allOrders} setFilter={setFilter}/>
                </div>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>Time</th>
                        <th>Dine-in/Delivery</th>
                        <th>Total</th>
                        <th>details</th>

                    </tr>
                </thead>
                <tbody>
                    {filteredOrders.map(o => {
                        return (
                            <tr key={`appointment-${o.id}`}>
                                <th scope="row">{formatTime(o.orderDate)}</th>
                                <td>{o.deliveryEmployee ? "Delivery" : "Dine-In"}</td>
                                <td>{formatPrice(o.total)}</td>
                                <td>
                                    <Link to={`/orders/${o.id}`} >details</Link>
                                </td>
                                <td>
                                    <Link data-id={o.id} onClick={handleDelete}>delete</Link>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
       
        </div>
    )
}