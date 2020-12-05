import {Fragment, useEffect, useState} from "react";
import CrudItem from "./CrudItem";
import {useForm} from "react-hook-form";
const axios = require("axios");



const CrudPage = () => 
{
    const [items, setItems] = useState([]);

    const [createName, setCreateName] = useState("");
    const [createDesc, setCreateDesc] = useState("");
    const [createDate, setCreateDate] = useState("");

    const [updateId, setUpdateId] = useState("");
    const [updateName, setUpdateName]  = useState("");
    const [updateDesc, setUpdateDesc] = useState("");
    const [updateDate, setUpdateDate] = useState("");

    const [deleteId, setDeleteId] = useState("");

    //CREATE
    const Create = async () =>
    {
        const data = {name : createName, description: createDesc, date: createDate};
        await axios.post(
            "https://localhost:5001/api/items/create",
            data)
        .then(() => window.location.href = "http://localhost:3000/test");
    }

    //DELETE
    const Delete = async () =>
    {
        console.log(deleteId);
        await axios.delete(
            `https://localhost:5001/api/items/delete/${deleteId}`)
        .then(() => window.location.href = "http://localhost:3000/test");
    }

    //UPDATE
    const Update = async () =>
    {
        
        const data = {id : updateId, name : updateName, description : updateDesc, date : updateDate};
        console.log(data);
        await axios.put(
            "https://localhost:5001/api/items/update",
            data)
        .then(() => window.location.href = "http://localhost:3000/test");
    }

    //READ
    useEffect(() => {
        const getItems = async () => {
            await axios.get("https://localhost:5001/api/items/all")
            .then(i => setItems(i.data));
        }

        getItems();
    }, []);

    return (
        <Fragment>
            <table className="table">
                <thead>
                    <th>
                        ID
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Description
                    </th>
                    <th>
                        Date
                    </th>
                </thead>
                <tbody>
                    { items.map(item => ( <CrudItem id={item._id} name={item.name} description={item.description} date={item.date}></CrudItem>))}
                </tbody>
            </table>

            <p style={{fontSize: "25px", color: "red"}}>Create</p>
            <form onSubmit={Create} style={{width: "400px"}}>
                <input id="name" className="input" type="text" name="name" onChange={e=> setCreateName(e.target.value)} placeholder="Name"></input><br></br>
                <input id="description" className="input" type="text" name="description" onChange={e => setCreateDesc(e.target.value)} placeholder="Description"></input><br></br>
                <input id="date" className="input" type="text" name="date"  onChange={e=> setCreateDate(e.target.value)} placeholder="Date"></input><br></br>

                <input id="submit" className="submit" type="submit" name="submit" value="Create"></input>
            </form>

            <p style={{fontSize: "25px", color: "red"}}>Update</p>
            <form onSubmit={Update} style={{width: "400px"}}>
                <input id="id" className="input" type="text" name="id" onChange={e=> setUpdateId(e.target.value)}  placeholder="id"></input><br></br>
                <input id="name" className="input" type="text" name="name" onChange={e=> setUpdateName(e.target.value)} placeholder="Name"></input><br></br>
                <input id="description" className="input" type="text" name="description" onChange={e=> setUpdateDesc(e.target.value)} placeholder="Description"></input><br></br>
                <input id="date" className="input" type="text" name="date" onChange={e=> setUpdateDate(e.target.value)} placeholder="Date"></input><br></br>

                <input id="submit" className="submit" type="submit" name="submit" value="Update"></input>
            </form>

            <p style={{fontSize: "25px", color: "red"}}>Delete</p>
            <form onSubmit={Delete} style={{width: "400px"}}>
                <input id="id" className="input" type="text" name="id" onChange={e=> setDeleteId(e.target.value)} placeholder="id"></input><br></br>

                <input id="submit" className="submit" type="submit" name="submit" value="Delete"></input>
            </form>
        </Fragment>

    );
}

export default CrudPage;