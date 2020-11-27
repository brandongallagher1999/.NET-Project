import './App.css';
import ToDoItem from "./components/ToDoItem";
import 'bulma/css/bulma.css';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import HomePage from "./components/HomePage";
import LoginPage from './components/LoginPage';

function App() {
  return (

    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={HomePage}></Route>
        <Route path="/login" component= {LoginPage}></Route>
      </Switch>
    </BrowserRouter>
    
    
  );
}

export default App;
