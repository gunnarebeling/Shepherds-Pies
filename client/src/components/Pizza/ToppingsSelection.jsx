/* eslint-disable react/prop-types */
import  { useEffect, useState } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Input, Label } from 'reactstrap';
import { getAllToppings } from '../../managers/toppingManager';

export const ToppingsSelection = ({pizzaForm, setPizzaForm, dropdownOpen, toggleDropdown}) => {
  const [selectedToppings, setSelectedToppings] = useState([]);
  const [allToppings, setAllToppings] = useState([])

  useEffect(() => {
    getAllToppings().then(setAllToppings)
  }, [])
  useEffect(() => {
    const selectToppings = allToppings.map(t => {
        if (pizzaForm.toppings.some(ft => ft.id === t.id)) {
          return {id: t.id, checked: true, type: t.type}
        } else {
          
          return {id: t.id, checked: false, type: t.type}
        }
    })
    setSelectedToppings(selectToppings)
  }, [allToppings])

  const handleCheckboxChange = (event) => {
    event.stopPropagation()
    const { name, } = event.target;
    const copy = [...selectedToppings]
    const foundTopping = copy.find(t => t.id === parseInt(name))
    foundTopping.checked = !foundTopping.checked
    
    setSelectedToppings(copy)
    let pizza = {...pizzaForm}
    let toppings = []
     selectedToppings.forEach(t => {
        if (t.checked && !pizza.toppings.some(t => t.toppingId === parseInt(t.id))) {
           toppings.push({id: parseInt(t.id), type: t.type })
        }
    })
    
    pizza.toppings = toppings
    setPizzaForm(pizza)
  };


  return (
    <div>
      <Dropdown isOpen={dropdownOpen} toggle={toggleDropdown}>
        <DropdownToggle caret>
          Select Toppings
        </DropdownToggle>
        <DropdownMenu>
          <DropdownItem header>Select Items: $0.50 each</DropdownItem>
          {selectedToppings.map(t => {
           return (<DropdownItem key={t.id} toggle={false}>
                    <Label check>
                    <Input
                        type="checkbox"
                        name={t.id}
                        checked={t.checked}
                        onChange={handleCheckboxChange}
                    />{t.type}
                    </Label>
                    </DropdownItem>)

          })}
          
        </DropdownMenu>
      </Dropdown>
    </div>
  );
};
