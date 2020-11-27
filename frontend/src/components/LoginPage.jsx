import Axios from "axios";
import { useState, useEffect} from "react";
import {useForm} from "react-hook-form";
const axios = require("axios");


const LoginPage = () =>
{

    // const [username, setUsername] = useState("");
    // const [password, setPassword] = useState("");

    const { register, handleSubmit} = useForm();

    const onSubmit = async (data) =>
    {
        await axios.post(
            "https://localhost:5001/users/authenticate",
            data, {headers: { "Access-Control-Allow-Origin" : true }})
        .then(() => window.location.href = "http://localhost:3000/");
    }

    return(
        <div className="container">
			<header>
				<h1>Login</h1>
			</header>
			<div className="loginForm">
				<form onSubmit={handleSubmit(onSubmit)}>
					<input id="username" className="username" type="text" name="username" ref={register}></input><br></br>
					<input id="password" className="password" type="password" name="password" ref={register}></input><br></br>
					
					<input id="submit" className="submit" type="submit" name="submit" value="Login"></input>
				</form>
			</div>
			
		</div>

    );

}

export default LoginPage;