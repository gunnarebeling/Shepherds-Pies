import { useEffect, useState } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
// eslint-disable-next-line react/prop-types
export const FilterDate = ({allOrders, setFilter}) => {
    const [OrderDate, setOrderDate] = useState(new Date ())

    useEffect(() => {
        let copy = [...allOrders]
        const date = OrderDate.toISOString().split('T')[0]
        copy = copy.filter(a => a.orderDate.split('T')[0] === date)
        setFilter(copy)
        
    }, [OrderDate])
    return (
        <div>
      <label>Select a Date:</label>
      <DatePicker
        selected={OrderDate}
        onChange={(date) => setOrderDate(date)}
        dateFormat="yyyy/MM/dd"
      />
    </div>

    )
}