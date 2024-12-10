/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, FormFeedback } from 'reactstrap';
import { getAllSizes } from '../../managers/sizeManager';
import { getAllCheeses } from '../../managers/cheeseManager';
import { getAllSauces } from '../../managers/sauceManager';
import { formatPrice } from '../../managers/formatingManager';
import { ToppingsSelection } from './ToppingsSelection';
import * as Yup from "yup";

export const CreatePizza = ({formData, setFormData}) => {
  const [modal, setModal] = useState(false)
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [allSizes, setAllSizes] = useState([])
  const [allCheese, setAllCheese] = useState([])
  const [allSauce, setAllSauce] = useState([])
  const [errors, setErrors] = useState({});
  
  const [pizzaForm, setPizzaForm] = useState({
        id: 0,
        sizeId: 0,
        cheeseId: 0,
        sauceId: 0,
        toppings: []
  });
  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);
  const toggle = () => {
    setModal(!modal)
    setErrors({})
  };

  useEffect(() => {
    getAllSizes().then(setAllSizes)
    getAllCheeses().then(setAllCheese)
    getAllSauces().then(setAllSauce)
    
  }, [])

  const handleChange = (e) => {
    const {name , value} = e.target
    let copy = {...pizzaForm,
        [name]: value
    }
    setPizzaForm(copy)
  }

  const validationSchema = Yup.object().shape({
    sizeId: Yup.number().typeError("must choose a size"),
    cheeseId: Yup.number().typeError("must choose a cheese type"),
    sauceId: Yup.number().typeError("must choose a sauce"),
    });

  const onAddPizza = async () => {
    setErrors({})
    try {
          await validationSchema.validate(pizzaForm, ({abortEarly: false}))
          let copy = {...formData}
          pizzaForm.id = formData.pizzas?.length ? formData.pizzas.length + 1 : 1
          copy.pizzas.push(pizzaForm)
          setFormData(copy)
          toggle()
      
    } catch (validationErrors) {
      const formattedErrors = validationErrors.inner.reduce((acc, err) => {
            acc[err.path] = err.message
            return acc
        }, {})

        setErrors(formattedErrors)
    }
  }

  return (
    <div>
      <Button color="primary" onClick={toggle}>
        add pizza
      </Button>
      <Modal isOpen={modal} toggle={toggle}>
        <ModalHeader toggle={toggle}>Create Pizza</ModalHeader>
        <ModalBody>
            <Form >
                <FormGroup>
                    <Label>Size</Label>
                    <Input
                    type="select"
                    name="sizeId"
                    value={pizzaForm.sizeId}
                    onChange={handleChange}
                    invalid= {!!errors?.sizeId}
                
                    >
                    <option value="#">Choose a Size</option>
                    {allSizes.map(e => <option key={`size-${e.id}`} value={e.id}>{`${e.type}  ${formatPrice(e.price)}`}</option>)}
                
                    </Input>
                    <FormFeedback type='invalid'>{errors.sizeId}</FormFeedback>
                </FormGroup>
                <FormGroup>
                    <Label>Sauce</Label>
                    <Input
                    type="select"
                    name="sauceId"
                    value={pizzaForm.sauceId}
                    onChange={handleChange}
                    invalid= {!!errors?.sauceId}
                
                    >
                    <option value="#">Choose a Sauce</option>
                    {allSauce.map(e => <option key={`sauce-${e.id}`} value={e.id}>{e.type}</option>)}
                
                    </Input>
                    <FormFeedback type='invalid'>{errors.sauceId}</FormFeedback>
                </FormGroup>
                <FormGroup>
                    <Label>Cheese</Label>
                    <Input
                    type="select"
                    name="cheeseId"
                    value={pizzaForm.cheeseId}
                    onChange={handleChange}
                    invalid= {!!errors?.cheeseId}
                
                    >
                    <option value="#">Choose a Cheese</option>
                    {allCheese.map(e => <option key={`cheese-${e.id}`} value={e.id}>{e.type}</option>)}
                
                    </Input>
                    <FormFeedback type='invalid'>{errors.cheeseId}</FormFeedback>
                </FormGroup>
                <FormGroup>
                    <ToppingsSelection pizzaForm={pizzaForm} setPizzaForm={setPizzaForm} toggleDropdown={toggleDropdown} setDropdownOpen={setDropdownOpen} dropdownOpen={dropdownOpen}/>
                </FormGroup>
            </Form>
        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={toggle}>
            Close
          </Button>
          <Button color="primary" onClick={onAddPizza}>
            Save Changes
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
};