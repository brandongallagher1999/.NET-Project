import '../App.css';
import ToDoItem from "./ToDoItem";
import ToDoList from "./ToDoList";
const HomePage = () =>
{

    return (
        <div>
            <div className="container-1">
                <ToDoList></ToDoList>
            </div>
        </div>
    );

}

export default HomePage;