import { Routes, Route } from 'react-router-dom';
// import Login from '../pages/Login/Login';
import { Usuarios } from '../pages/Usuarios/Usuarios';
import { PrivateRoute } from '../components/PrivateRoute';

export const AppRoutes = () => (
    <Routes>
        {/* <Route path="/login" element={<Login />} /> */}
        <Route
            path="/usuarios"
            element={
                // <PrivateRoute>
                    <Usuarios />
                // </PrivateRoute>
            }
        />
    </Routes>
);
