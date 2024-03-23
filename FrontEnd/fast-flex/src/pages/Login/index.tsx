import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import LogoP from '../../assets/LogoP.png';
import Moto from '../../assets/moto.png';
import $ from 'jquery';
import './style.css';

function Login() {
    const navigate = useNavigate();
    const HandleClick = async () => {
        var Email = $("#email").val();
        var Senha = $("#senha").val();

        await axios({
            method: 'post',
            url: 'https://localhost:44367/api/Auth/Login',
            data: {
                email: Email,
                senha: Senha
            }
        }).then(function (response) {
            const token = response.data; 
            if (Object.keys(token).length !== 0) {
                localStorage.setItem('fastFlex-token', token);
                navigate("/dashboard");

            } else {
                localStorage.clear();
                alert("Senha ou email incorretos!")
            }
        });
    }
    return (
        <>
            <div className="d-flex">
                <div className="esquerda">
                    <img id='moto' src={Moto} alt="" />
                    <div className="centroE">
                        <h3> <a href='/cadastroUser' id='cadastro'>Cadastre-se</a>para solicitar as entregas no nosso sistema</h3>
                    </div>
                </div>
                <div className="direita d-flex">
                    <div className="centro d-flex flex-column">
                        <div className="logoCentro">
                            <img id='logo' src={LogoP}></img>
                        </div>
                        <b>Login</b>
                        <p>Faça Login para acessar a Fast Flex </p>
                        <input type="text" id="email" placeholder='Login' />
                        <input type="text" id="senha" placeholder='Senha' />
                        <div className="logado d-flex">
                            <input type="checkbox" name="Manter" id="botao" />
                            <p>Manter logado</p>
                        </div>
                        <div className="bCentro col-md-12 d-flex ">
                            <button onClick={HandleClick}>Entrar</button>
                        </div>
                        <a>Esqueci a senha</a>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Login;