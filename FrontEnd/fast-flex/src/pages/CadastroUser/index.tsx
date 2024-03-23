import React from 'react';
import $ from 'jquery';
import { useNavigate } from 'react-router-dom';
import { emitKeypressEvents } from 'readline';
import LogoP from '../../assets/LogoP.png';
import Moto from '../../assets/moto.png';
import api from '../../services/Api';
import './style.css';

function CadastroUser() {
    const navigate = useNavigate();
    const HandleClick = async ( ) => 
    {
        let email:string = $("#email").val() as string;
        var senha:string = $("#senha").val() as string;
        var confSenha = $("#confSenha").val();

        if(senha !== confSenha)
        {
            return alert("As senhas não se coincidem")
        }
        
        debugger

        localStorage.setItem('email', email);
        localStorage.setItem('senha', senha);
        
        var data = {
            email,
            senha,
            ativado: true,
            tipoUsuarioId : 3
        }
        api.post('Usuario/AdicionaUsuario', data)
        .then(res => {
            if(res.status == 200)
            {
                navigate("/cadastroCliente");
               
            }else{
                alert("Não foi possivel realizar o cadastro");
            }
        })
    }
    return (

        <>
            <div className="d-flex">
                <div className="esquerda">
                    <img id='moto' src={Moto} alt="" />
                    <div className="centroEE">
                        <h3> Já possui conta na Fast Flex?</h3><a href='/' id='cadastro'>Fazer login</a>
                    </div>
                </div>
                <div className="direita d-flex">
                    <div className="centro d-flex flex-column">
                        <div className="logoCentro">
                            <img id='logo' src={LogoP}></img>
                        </div>
                        <b>Cadastro de Usuario</b>
                        <p>Faça o cadastro para acessar a Fast Flex </p>
                        <input type="text" id='email' placeholder='Email*' />
                        <input type="text" id='senha' placeholder='Senha*' />
                        <input type="text" id='confSenha' placeholder='Confirmar Senha*' />
                        <div>
                            <label  className="l-radio">
                                <input type="radio" id="f-option" name="selector" />
                                    <span>Pessoa Fisíca</span>
                            </label>
                            <label className="l-radio">
                                <input type="radio" id="s-option" name="selector" />
                                    <span>Pessoa Jurídica</span>
                            </label>                           
                        </div>
                        <div className="logado d-flex">
                            <input type="checkbox" name="Manter" id="botao" />
                            <p>Manter logado</p>
                        </div>
                        <div className="bCentro col-md-12 d-flex ">
                            <button onClick={HandleClick}>Continuar</button>
                        </div>
                        <a>Esqueci a senha</a>
                    </div>
                </div>
            </div>
        </>
    );
}

export default CadastroUser;