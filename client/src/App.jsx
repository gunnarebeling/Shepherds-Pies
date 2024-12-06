import { createContext, useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { Spinner } from "reactstrap";

import ApplicationViews from "./components/ApplicationViews";
import { tryGetLoggedInUser } from "./managers/authManager";
import NavBar from "./Components/NavBar";
export const UserContext = createContext();

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <UserContext.Provider value= {{loggedInUser, setLoggedInUser}}>
        <NavBar />
        <ApplicationViews/>
      </UserContext.Provider>
    </>
  );
}

export default App;
