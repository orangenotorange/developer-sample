import React, {useState} from "react";
import './LoginForm.css';

const LoginForm = (props) => {
	const [loginInfo, setLoginInfo] = useState({
		login: "",
		password: "",
	})
	
	const updateLogin = (event) => {
		const login = event.target.value;
		setLoginInfo({ ...loginInfo, login })
	}

	const updatePassword = (event) => {
		const password = event.target.value
		setLoginInfo({ ...loginInfo, password })
	}
	const handleSubmit = async (event) =>{
		event.preventDefault();
		props.onSubmit(loginInfo);
		await setLoginInfo({
			login: "",
			password: ""
		})
	}

	return (
		<form className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" value={loginInfo.login}  onChange={updateLogin}  />
			<label htmlFor="password">Password</label>
			<input type="password" id="password" value={loginInfo.password}  onChange={updatePassword} />
			<button type="submit" onClick={handleSubmit}>Continue</button>
		</form>
	)
}

export default LoginForm;