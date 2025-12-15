import { useState } from "react";
import api from "../api/axios";


const Register = () => {
    const [form, setForm] = useState({ fullName: "", email: "", password: "" });


    const submit = async () => {
        await api.post("/auth/register", form);
        alert("Registered successfully");
    };


    return (
        <div>
            <h2>Register</h2>
            <input placeholder="Name" onChange={e => setForm({ ...form, fullName: e.target.value })} />
            <input placeholder="Email" onChange={e => setForm({ ...form, email: e.target.value })} />
            <input type="password" placeholder="Password" onChange={e => setForm({ ...form, password: e.target.value })} />
            <button onClick={submit}>Register</button>
        </div>
    );
};


export default Register;