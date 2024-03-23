import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './pages/Login/index';
import CadastroCliente from './pages/CadastroCliente/index';
import CadastroUser from './pages/CadastroUser/index';

import Dashboard from './pages/Dashboard/index';

function Routers() {
    return (
        <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/cadastroCliente" element={<CadastroCliente />} />
                    <Route path="/cadastroUser" element={<CadastroUser />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                </Routes>
        </BrowserRouter>
    );
}
export default Routers;