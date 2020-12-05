import { useState, useEffect, Fragment} from "react";
import ToDoItem from "./ToDoItem";

import "../App.css";

const axios = require("axios");

const ToDoList = () =>
{
    const [items, setItems] = useState([]);

    //READ
    useEffect(() => {


        var config = {
            method: 'get',
            url: 'https://localhost:5001/api/items/all',
            headers: { }
          };
          
          axios(config)
          .then(function (response) {
            setItems(response);
          });

        // const getItems = async () => {
        //     await axios.get("http://localhost:3001/api/items/all")
        //     .then(i => setItems(i.data));
        // }
        // getItems();
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