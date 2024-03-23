import React, { useEffect, useState } from 'react';
import LogoP from '../../assets/LogoP.png';
import $, { data, param } from 'jquery';
import Moto from '../../assets/moto.png';
import './style.css';
import 'animate.css';
import { useNavigate } from 'react-router-dom';
import api from '../../services/Api';
import internal from 'stream';

function Cadastro() {
    const navigate = useNavigate();
    var email = localStorage.getItem('email');
    var senha = localStorage.getItem('senha');
    var userId = 0;

    useEffect(() => {
        api.get("Usuario/ListaUsuarioPorCredenciais", {params:{email: email, senha: senha}})
            .then(res =>
                userId = res.data ) 
    }, []);

    
    const HandleClick = async ( ) => 
    {
        var nomeFantasia = $("#NomeFantasia").val();
        var razaoSocial = $("#RazaoSocial").val();
        var cep = $("#Cep").val();
        var contato = $("#NomeResponsavel").val();
        let telefoneString:string = $("#Celular").val() as string;
        var email = "fastflex@email.com";
        var cep = $("#Cep").val();
        var logradouro = $("#Endereco").val();
        var numeroString:string = $("#Numero").val() as string; 
        var bairro = $("#Bairro").val();
        var description = $("#descricao").val();
        var uf = $("#Estado").val();
        var Cpnj = $("#CNPJ").val();
        var cidade = "São Paulo";
    
        var telefone = parseInt(telefoneString, 10);
        var numero = parseInt(numeroString, 10);

        var data = {
            nomeFantasia,
            razaoSocial,
            contato,
            telefone,
            email,
            logradouro,
            bairro,
            cep,
            cidade,
            uf,
            Cpnj,
            description,
            numero,
            ativado : true,
            userId : userId
        }

        api.post('Cliente/AdicionaCliente', data)
        .then(res =>{
            if(res.status == 200)
            {     
                navigate("/")
            }else{
                alert("Não foi possivel realizar o cadastro");
            }
        })
    }

    var index;
    function TrocaDeTela(index: any) {
        switch (index) {
            case 1:
                $(".direita").show();
                $(".endereco-container").hide();
                break;
            case 2:
                $(".direita").hide();
                $(".endereco-container").show();
        
                $("#finalizar").show();
                break;
            case 3:
                $(".direita").hide();
                $(".endereco-container").hide();
                $(".descricao-container").show();

                

                break;
        }
    }

    $(document).ready(function () {
        $(".endereco-container").hide();
        $(".descricao-container").hide();
        $("#finalizar").hide();

    });
    return (
        <>
            <div className="cadastroCliente-container d-flex">
                <div className="esquerdaaa">
                    <img id='moto' src={Moto} alt="" />
                    <div className="centroEE">
                        <h3> Já possui conta na Fast Flex?</h3><a href='/' id='cadastro'>Fazer login</a>
                    </div>
                </div>
                <div className="direita">
                    <div className="centro2 d-flex flex-column animate__animated animate__bounceInDown">
                        <div className="logoCentro">
                            <img id='logoo' src={LogoP}></img>
                        </div>
                        <b>Cadastro</b>
                        <p>Cadastre-se para solicitar as entregas no nosso sistema</p>
                        <input type="text" id='CNPJ' placeholder='CNPJ*' />
                        <input type="text" id='RazaoSocial' placeholder='Razão Social*' />
                        <input type="text" id='NomeFantasia' placeholder='Nome Fantasia*' />
                        <input type="number" id='Celular' placeholder='Celular*' />
                        <input type="text" id='NomeResponsavel' placeholder='Nome do responsável*' />
                        <div className="logado d-flex">
                            <input type="checkbox" name="Manter" id="botao" />
                            <p>Concordo que li e aceito os termos e condições de uso</p>
                        </div>
                        <div className="bCentro col-md-12 d-flex ">
                            <button onClick={() => TrocaDeTela(2)}>Continuar</button>
                        </div>
                    </div>
                </div>
                <div className='endereco-container col-md-6 animate__animated'>
                    <div className="logoCentro">
                        <img id='logoo' src={LogoP}></img>
                    </div>
                    <b>Cadastro</b>
                    <p>Cadastre-se para solicitar as entregas no nosso sistema</p>
                    <input type="text" id='Cep' placeholder='CEP*' />
                    <div className='numeroEndereco col-md-9'>
                        <input type="text" id='Endereco' placeholder='Endereco*' />
                        <input type="text" id='Numero' placeholder='Numero*' />
                    </div>
                    <input type="text" id='Bairro' placeholder='Bairro*' />
                    <input type="text" id='Complemento' placeholder='Complemento*' />
                    <input type="text" id='Cidade' placeholder='Cidade*' />
                    <input type="text" id='Estado' placeholder='Estado*' />
                    <div id='finalizar' className="bCentro col-md-12 ">
                        <button onClick={() => TrocaDeTela(3)}>Continuar</button>
                    </div>
                </div>
                <div className='descricao-container col-md-6 '>
                <div className="logoCentro">
                        <img id='logoo' src={LogoP}></img>
                    </div>
                    <b>Falta pouco!</b>
                    <p>Agora, antes de finalizarmos... descreva o(s) tipo(s) de produto(s) que você vende na sua loja</p>
                    <div className='descricao'>
                        <input type="text" id='descricao' placeholder='Tipo do produto *'></input>
                        <button onClick={HandleClick}>Finalizar</button>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Cadastro;