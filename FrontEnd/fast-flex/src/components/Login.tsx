import jwtDecode from 'jwt-decode';
import jwt from 'jwt-decode' // import dependency
import { useNavigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';
import api from '../services/Api';

const LOGIN_URL = "Auth/Login";

const navigate = useNavigate();
    const Login = async () =>
    {
        var email = $("#email").val();
        var senha = $("#senha").val();

        var data = 
        {
            email,
            senha
        }   
        api.post(LOGIN_URL,
            data
        ).then(res =>{
            if(res.status == 200)
            {
                var token = res.data.token;
                var decoded = jwtDecode(token);
                var role = res.data.role;
                
                // localStorage.setItem('fastFlex-token', res.data.token);
                navigate("/dashboard");
        
            }else
            {
                localStorage.clear();
                alert("Senha ou email incorretos!")
            }
        }); 
    }

export default Login;