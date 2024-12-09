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
          <Route index element={<OrdersList/>}/>
          <Route path=":id" element={<OrderDetails/>}/>

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
