import axios from "axios";
import $ from 'jquery';
import { useNavigate } from "react-router-dom";

const HandleClick = async () =>
{
    const navigate = useNavigate();
    var Email = $("#email").val();
    var Senha = $("#senha").val();
    
    await axios({
        method: 'post',
        url: 'https://localhost:44367/api/Auth/Login',
        data: {
            email: Email,
            senha: Senha
        }
    }).then( function(response){    
        const token = response.data;
        if(Object.keys(token).length !== 0)
        {
            localStorage.setItem('fastFlex-token', token);
            navigate("/dashboard");
    
        }else
        {
            localStorage.clear();
            alert("Senha ou email incorretos!")
        }
    });
}

export default HandleClick;