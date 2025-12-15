import { useAuth } from "../auth/AuthContext";


const Dashboard = () => {
    const { logout } = useAuth();


    return (
        <div>
            <h2>Dashboard (Protected)</h2>
            <button onClick={logout}>Logout</button>
        </div>
    );
};


export default Dashboard;