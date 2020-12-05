import './App.css';
import 'bulma/css/bulma.css';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import HomePage from "./components/HomePage";
import LoginPage from './components/LoginPage';
import CrudPage from "./components/CrudPage";
import NavBar from "./components/NavBar";

import {Fragment} from "react";

function App() {
  return (

    <Fragment>
      <NavBar>
      </NavBar>
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={HomePage}></Route>
          <Route path="/login" component= {LoginPage}></Route>
          <Route path="/crud" component={CrudPage}></Route>
        </Switch>
      </BrowserRouter>
    </Fragment>

    
    
  );
}

export default App;
