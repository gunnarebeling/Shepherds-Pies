/* eslint-disable react/no-unescaped-entities */
/* eslint-disable react/prop-types */
import { useContext, useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
Button,
Collapse,
Nav,
NavLink,
NavItem,
Navbar,
NavbarBrand,
NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import { UserContext } from "../App";

export default function NavBar() {
const [open, setOpen] = useState(false);
const { loggedInUser, setLoggedInUser } = useContext(UserContext)

const toggleNavbar = () => setOpen(!open);

return (
    <div>
    <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
        🍕 Shepherd's Pies
        </NavbarBrand>
        {loggedInUser ? (
        <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
            <Nav navbar>
            <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/orders">
                Orders
            </NavLink>
            </NavItem>
            <NavItem onClick={() => setOpen(false)}>
            <NavLink tag={RRNavLink} to="/orders/create">
                Create Order
            </NavLink>
            </NavItem>
            
            </Nav>
            </Collapse>
        
            <Button
            color="primary"
            onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                setLoggedInUser(null);
                setOpen(false);
                });
            }}
            >
            Logout
            </Button>
        </>
        ) : (
        <Nav navbar>
            <NavItem>
            <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
            </NavLink>
            </NavItem>
        </Nav>
        )}
        
    </Navbar>
    </div>
);
}