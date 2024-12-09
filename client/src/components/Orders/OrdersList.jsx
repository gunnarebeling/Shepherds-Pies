import { useEffect, useState } from "react"
import { getAllOrders } from "../../managers/orderManager"
import { FilterDate } from "./FilterDate"
import { Table } from "reactstrap"
import { Link } from "react-router-dom"


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

    const formatTime = (dateTime) => {
        
        const date = new Date(dateTime.slice(0,-1));
      
        let hours = date.getHours();
        const minutes = date.getMinutes().toString().padStart(2, "0");
        const ampm = hours >= 12 ? "PM" : "AM";
      
       
        hours = hours % 12 || 12; 
      
        return `${hours}:${minutes} ${ampm}`;
      };
      const formatPrice = (price) => {
        return price.toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
          });
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
                                    <Link to={`${o.id}`} >details</Link>
                                </td>
                                <td>
                                    <Link to={`${o.id}/edit`} >edit/cancel</Link>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </Table>
       
        </div>
    )
}