import { useState, useEffect} from "react";
import "../App.css";

const ToDoItem = () =>
{
    
    const [desc, setDesc] = useState("some desc");
    const [user, setUser] = useState("brandon");
    const [date, setDate] = useState("today date");

    useEffect(()=> {

    });

    return(
        <div className="box">
            <div className="inner-box">
                <p>Name: {user}</p>
            </div>
            <div className="inner-box">
                <p> {desc} </p>
            </div>
            <div className="inner-box">
                <p> {date}</p>
            </div>

        </div>
    );

}

export default ToDoItem;