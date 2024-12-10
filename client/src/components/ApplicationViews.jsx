/* eslint-disable react/prop-types */
import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { UserContext } from "../App";
import { useContext } from "react";
import { OrdersList } from "./Orders/OrdersList";
import { OrderDetails } from "./Orders/OrderDetails";
import { Home } from "./Home";
import { CreateOrder } from "./Orders/CreateOrder";

export default function ApplicationViews() {
  const { loggedInUser, setLoggedInUser } = useContext(UserContext)


  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home/>
            </AuthorizedRoute>
          }
        />
        <Route path="/orders">
          <Route index element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrdersList/>
            </AuthorizedRoute>
            }/>
          <Route path=":id" element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrderDetails/>
            </AuthorizedRoute>
            }/>
          <Route path="create" element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateOrder loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
            }/>

        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />

    </Routes>
  );
}
