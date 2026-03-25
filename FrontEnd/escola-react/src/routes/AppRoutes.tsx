import { Routes, Route } from 'react-router-dom';
// import Login from '../pages/Login/Login';
import { Usuarios } from '../pages/Usuarios/Usuarios';
// import { PrivateRoute } from '../components/PrivateRoute';
import { Create } from '../pages/Usuarios/Create';
import { CreateRede } from '../pages/Rede/CreateRede';
import { CreateUnidade } from '../pages/Unidade/Create';
import { CreatePerfil } from '../pages/Perfil/CreatePerfil';

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
        <Route path='/usuarios/cadastrar'
            element={
                <Create />
            } />
        <Route path='/usuarios/editar/:id'
            element={
                <Create />
            } />

        <Route path='/rede'
            element={
                <CreateRede />
            } />

        <Route path='/unidade'
            element={
                <CreateUnidade />
            } />
        <Route path='/perfil'
            element={
                <CreatePerfil />
            } />
    </Routes>
);
