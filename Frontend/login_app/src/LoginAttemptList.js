import React, {useState} from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
	const [filter, setFilter] = useState("");
	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>

			<input type="input" placeholder="Filter..." value={filter} onChange={(event) => setFilter(event.target.value)} />
			<ul className="Attempt-List">
				{props.attempts
					.filter(attempt => {
						if (filter){
							return attempt.login.includes(filter) || attempt.password.includes(filter)
						}
						
						return attempt;
					})
					.map((attempt, index) => {
						return <LoginAttempt key={index}><span>{attempt.login}</span> {attempt.password}</LoginAttempt>
					})}

			</ul>
		</div>
	);
}
	

export default LoginAttemptList;