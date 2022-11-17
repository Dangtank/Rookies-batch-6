import { useContext } from "react";
import { useLocation, Navigate, Outlet } from "react-router-dom";
import AuthContext from "../../contexts/AuthContext";

const RequireAuth = ({ allowedRoles }) => {
    const { auth } = useContext(AuthContext);
    const location = useLocation();

    return (
        auth?.roles?.find(roleasd => allowedRoles?.includes(roleasd))
            ? <Outlet />
            : auth?.user
                ? <Navigate to="/unauthorized" state={{ from: location }} replace />
                : <Navigate to="/login" state={{ from: location }} replace />
    );
}

export default RequireAuth;