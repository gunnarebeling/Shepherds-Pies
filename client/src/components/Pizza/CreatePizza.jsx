/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';
import { getAllSizes } from '../../managers/sizeManager';
import { getAllCheeses } from '../../managers/cheeseManager';
import { getAllSauces } from '../../managers/sauceManager';
import { formatPrice } from '../../managers/formatingManager';
import { ToppingsSelection } from './ToppingsSelection';

export const CreatePizza = ({formData, setFormData}) => {
  const [modal, setModal] = useState(false)
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [allSizes, setAllSizes] = useState([])
  const [allCheese, setAllCheese] = useState([])
  const [allSauce, setAllSauce] = useState([])
  
  const [pizzaForm, setPizzaForm] = useState({
        id: 0,
        sizeId: 0,
        cheeseId: 0,
        sauceId: 0,
        toppings: []
  });
  const toggleDropdown = () => setDropdownOpen(!dropdownOpen);
  const toggle = () => setModal(!modal);

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
  const onAddPizza = () => {
    let copy = {...formData}
    pizzaForm.id = formData.pizzas?.length ? formData.pizzas.length + 1 : 1
    copy.pizzas.push(pizzaForm)
    setFormData(copy)
    toggle()
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
                    // isInvalid= {true}
                
                    >
                    <option value="#">Choose a Size</option>
                    {allSizes.map(e => <option key={`size-${e.id}`} value={e.id}>{`${e.type}  ${formatPrice(e.price)}`}</option>)}
                
                    </Input>
                    {/* <FormFeedback type='invalid'></FormFeedback> */}
                </FormGroup>
                <FormGroup>
                    <Label>Sauce</Label>
                    <Input
                    type="select"
                    name="sauceId"
                    value={pizzaForm.sauceId}
                    onChange={handleChange}
                    // isInvalid= {true}
                
                    >
                    <option value="#">Choose a Sauce</option>
                    {allSauce.map(e => <option key={`sauce-${e.id}`} value={e.id}>{e.type}</option>)}
                
                    </Input>
                    {/* <FormFeedback type='invalid'></FormFeedback> */}
                </FormGroup>
                <FormGroup>
                    <Label>Cheese</Label>
                    <Input
                    type="select"
                    name="cheeseId"
                    value={pizzaForm.cheeseIdId}
                    onChange={handleChange}
                    // isInvalid= {true}
                
                    >
                    <option value="#">Choose a Cheese</option>
                    {allCheese.map(e => <option key={`cheese-${e.id}`} value={e.id}>{e.type}</option>)}
                
                    </Input>
                    {/* <FormFeedback type='invalid'></FormFeedback> */}
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