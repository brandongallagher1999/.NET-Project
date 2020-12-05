import { useState, useEffect, Fragment} from "react";
import ToDoItem from "./ToDoItem";

import "../App.css";

const axios = require("axios");

const ToDoList = () =>
{
    const [items, setItems] = useState([]);

    //READ
    useEffect(() => {
        const getItems = async () => {
            await axios.get("http://localhost:3001/api/items/all")
            .then(i => setItems(i.data));
        }
        getItems();
    }, []);


    return (
        <Fragment>
            { items.map(item => {
                return <ToDoItem name={item.name} description={item.description} date={item.date}></ToDoItem>
            })}
        </Fragment>
    );

}

export default ToDoList;