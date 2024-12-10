/* eslint-disable react/prop-types */
import { useContext, useEffect, useState } from "react"
import { Button, Form, FormFeedback, FormGroup, Input, Label, Table } from "reactstrap"
import { getAllEmployees } from "../../managers/employeeManager"
import { UserContext } from "../../App"
import { CreatePizza } from "../Pizza/CreatePizza"
import { PizzaTable } from "../Pizza/PizzaTable"
import { postOrder } from "../../managers/orderManager"
import { useNavigate } from "react-router-dom"
import { getAllSizes } from "../../managers/sizeManager"
import { formatPrice } from "../../managers/formatingManager"

export const CreateOrder = () => {
    const [allEmployees, setAllEmployees] = useState([])
    const [delivery, setDelivery] = useState(false)
    const {loggedInUser} = useContext(UserContext)
    const [allSizes, setAllSizes] = useState([])
    const [total, setTotal] = useState(0)
    const [tipPercent, setTipPercent] =useState(0)
    const [customTip, setCustomTip] = useState(0)
    const [submitTip, setSubmitTip] = useState(0)

    const navigate = useNavigate()
    const [formData, setFormData] = useState({
        deliveryEmployeeId: 0,
        orderEmployeeId: 0,
        pizzas: [],
        tip: 0
    })
    

    useEffect(() => {
        getAllEmployees().then(setAllEmployees)
        getAllSizes().then(setAllSizes)
    }, [])
    useEffect(() => {
        let total = formData.pizzas?.reduce((total, p) =>{
            const size = allSizes.find(s => s.id === parseInt(p.sizeId))
            total += size.price + (p.toppings.length * 0.50)
            return  total
        },0)
        let newTotal = 0
        if (tipPercent || customTip) {
            
            let tip = (total * tipPercent) + customTip
            tip = Math.round(tip * 100) / 100
            setSubmitTip(tip)
            newTotal = total + tip
        }else{
            newTotal = total
        }
            
      

        if (newTotal > 0) {
           newTotal = formatPrice(newTotal)
        }
        setTotal(newTotal)
    }, [formData, tipPercent, customTip])

    const handleDelivery = () => {
        let copy = {...formData,
            deliveryEmployeeId: 0
        }
        setFormData(copy)
        setDelivery(d => !d)
    }

    const handleChange = (e) => {
        const {name, value} = e.target
        let copy = {...formData,
            [name]: value
        }
        setFormData(copy)
    }
    const handleSubmit = (e) => {
        e.preventDefault()
        if (formData.pizzas.length === 0) {
            window.alert("must have at least one pizza")
        }else{
            let copy = {...formData}
    
            copy.orderEmployeeId = loggedInUser.id
            copy.deliveryEmployeeId = formData.deliveryEmployeeId === 0 ? null : parseInt(formData.deliveryEmployeeId)
            copy.tip = submitTip
            
    
            postOrder(copy).then(
                navigate("/orders")
            )

        }
    }
    const handleTipButton = (e) => {

         setTipPercent(parseFloat(e.target.dataset.percent) / 100)
         setCustomTip(0)
    }
    const handleCustomTip = (e) => {
        setCustomTip(parseFloat(e.target.value))
        setTipPercent(0)
    }
    const handleNoTip = () => {
        setCustomTip(0)
        setTipPercent(0)
    }
    
    return (
        <div className="container ">
            <div>
                <h4>Create Order</h4>
            </div>
            <Form onSubmit={handleSubmit}>
                <FormGroup>
                    <Label>Delivery</Label>
                    <Input 
                    type="checkbox"
                    name="delivery"
                    onChange={handleDelivery}
                    value = {delivery}
                    />
                    {delivery && 
                    <>
                    <Input
                    type="select"
                    name="deliveryEmployeeId"
                    value={formData.deliveryEmployeeId}
                    onChange={handleChange}
                    // isInvalid= {true}
                
                    >
                    <option value="#">Choose Delivery Driver</option>
                    {allEmployees.map(e => <option key={`employee-${e.id}`} value={e.id}>{e.fullName}</option>)}
                
                    </Input>
                    {/* <FormFeedback type='invalid'></FormFeedback> */}
                    </>}
                </FormGroup>
                        <PizzaTable formData={formData} setFormData={setFormData}/>
              
                        <CreatePizza formData={formData} setFormData={setFormData}/>
                    <FormGroup className="my-4">
                        <h4 className="m-1">add tip</h4>
                        <div className="d-flex justify-content-between">
                            <div>
                                <div>
                                    <Button className="mr-2" data-percent="15" onClick={handleTipButton}>15%</Button>
                                    <Button className="m-2" data-percent="20" onClick={handleTipButton}>20%</Button>
                                    <Button className="m-2" data-percent="23" onClick={handleTipButton}>23%</Button>
                                    <Input
                                        type="number"
                                        id="amount"
                                        name="amount"
                                        min="0"
                                        step="0.01"
                                        value={customTip}
                                        onChange={handleCustomTip}
                                    />
                                </div>
                                <div className="d-flex justify-content-center ">

                                    <Button className="m-2 " onClick={handleNoTip}>no tip</Button>
                                </div>

                            </div>
                            <div className="d-flex">
                                <h3 className="me-2">Total: </h3>
                                <h3>{total}</h3>
                            </div>

                        </div>
                    </FormGroup>
                    <div className="d-flex justify-content-center ">
                        <Button variant="primary" type="submit">Submit</Button>

                    </div>
            </Form>

        </div>
       
    
    )
}