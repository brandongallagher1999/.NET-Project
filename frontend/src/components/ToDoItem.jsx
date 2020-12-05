import { useState, useEffect} from "react";
import "../App.css";

const ToDoItem = (props) =>
{

    return(
        <div className="box">
            <div className="inner-box">
                <p>{props.name}</p>
            </div>
            <div className="inner-box">
                <p> {props.description} </p>
            </div>
            <div className="inner-box">
                <p> {props.date}</p>
            </div>

        </div>
    );

}

export default ToDoItem;