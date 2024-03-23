import React, { useEffect, useState } from 'react';
import LogoP from '../../assets/LogoP.png';
import LogoB from '../../assets/LogoB.svg';
import Moto from '../../assets/moto.png';
import Pedido from '../../assets/pedido.svg';
import Sino from '../../assets/sino.svg';
import Editar from '../../assets/editar.svg';
import Excluir from '../../assets/trash.svg';
import Lupa from '../../assets/search.svg';
import Camp from '../../assets/campanhia.svg';
import Dash from '../../assets/dash.png';
import Motoca from '../../assets/motoca.png';
import Cliente from '../../assets/clientes.png';
import Entrega from '../../assets/pedido.png';
import $, { data } from 'jquery';
import 'animate.css';
import './style.css';
import api from '../../services/Api';
import ReactDOM from 'react-dom';
import { useNavigate, useNavigation } from 'react-router-dom';
import axios from 'axios';
import { getValue } from '@testing-library/user-event/dist/utils';
import jwt_decode, { JwtPayload } from "jwt-decode";
import { decode } from 'punycode';


function Dashboard() {

    //ENTREGAS BUSCA =========================================
    var entregas: any[] = []
    useEffect(() => {
        BuscarEntregas()
    }, [])

    function BuscarEntregas() {
        let div = document.getElementById("area-motoboy")
        api.get("Entregador/ListaEntregador")
            .then(res => {

                res.data.map(((entregador: any) => {
                    motoboys.push(entregador)
                }))
                console.log(motoboys)
                ReactDOM.render(ModeloMotoboy(res.data), document.getElementById("area-motoboy"))

            }).catch((err) => {
                console.error("ops! ocorreu um erro : " + err);
            });
    }

    const ModeloEntregas = (e: any) => {
        return (
            <div>
                {e.map((motoboy: any) => (
                    <div key={motoboy.entregadorId} className="motoqueiros animate__animated">
                        <div id='nomeInteiro'>
                            <div className="foto"></div>
                            <b>{motoboy.nome} {motoboy.sobrenome}</b>
                        </div>
                        <b>{motoboy.numeroDocumento}</b>
                        <b>09123-130</b>
                        <b>14 km</b>
                        <div className="acaoo">
                            <div className="editar">
                                <img src={Editar} alt="" />
                                <a href="">Editar</a>
                            </div>
                            <div className="excluir">
                                <img src={Excluir} alt="" />
                                <a href="">Excluir</a>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        );
    }

    //ENTREGAS BUSCA FIM =====================================

    // MOTOBOY BUSCA =========================================
    var motoboys: any[] = []
    useEffect(() => {
        BuscarMotoboy()
    }, [])

    function BuscarMotoboy() {
        let div = document.getElementById("area-motoboy")
        api.get("Entregador/ListaEntregador")
            .then(res => {

                res.data.map(((entregador: any) => {
                    motoboys.push(entregador)
                }))
                console.log(motoboys)
                ReactDOM.render(ModeloMotoboy(res.data), document.getElementById("area-motoboy"))

            }).catch((err) => {
                console.error("ops! ocorreu um erro : " + err);
            });
    }

    const ModeloMotoboy = (e: any) => {
        return (
            <div>
                {e.map((motoboy: any) => (
                    <div key={motoboy.entregadorId} className="motoqueiros animate__animated">
                        <div id='nomeInteiro'>
                            <div className="foto"></div>
                            <b>{motoboy.nome} {motoboy.sobrenome}</b>
                        </div>
                        <b>{motoboy.numeroDocumento}</b>
                        <b>09123-130</b>
                        <b>14 km</b>
                        <div className="acaoo">
                            <div className="editar">
                                <img src={Editar} alt="" />
                                <a href="">Editar</a>
                            </div>
                            <div className="excluir">
                                <img src={Excluir} alt="" />
                                <a href="">Excluir</a>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        );
    }

    // MOTOBOY BUSCA - FIM =========================================
    //CLIENTE BUSCA ===========================================
    var clientes: any[] = []
    useEffect(() => {
        BuscarClientes()
        $(".cadastro-motoca").hide();
    }, [])

    function BuscarClientes() {

        let div = document.getElementById("area-cliente")
        api.get("Cliente/ListaClientes")
            .then(res => {

                res.data.map(((cliente: any) => {
                    clientes.push(cliente)
                }))
                console.log(clientes)
                ReactDOM.render(ModeloCliente(res.data), document.getElementById("area-cliente"))

            }).catch((err) => {
                console.error("ops! ocorreu um erro : " + err);
            });
    }

    const ModeloCliente = (e: any) => {
        return (
            <div>
                {e.map((cliente: any) => (
                    <div key={cliente.userId} className="motoqueiros animate__animated">
                        <div id='nomeInteiro2'>
                            <div className="foto"></div>
                            <b>{cliente.nomeFantasia}</b>
                        </div>
                        <b>{cliente.logradouro}</b>
                        <b>{cliente.telefone}</b>
                        <div className="acaoo">
                            <div className="editar">
                                <img src={Editar} alt="" />
                                <a href="">Editar</a>
                            </div>
                            <div className="excluir">
                                <img src={Excluir} alt="" />
                                <a href="">Excluir</a>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        );
    }
    //CLIENTE BUSCA - FIM ===========================================

    //PEDIDO - INICIO ===========================================
    const [getClientes, setClientes] = useState([]);
    const AdicionaPedido = async () => {

        api.get("Cliente/ListaClientes")
            .then(res => {
                setClientes(res.data);


                res.data.map(((cliente: any) => {
                    clientes.push(cliente)
                }))
                console.log(clientes)
                ReactDOM.render(ModeloCliente(res.data), document.getElementById("area-cliente"))

            }).catch((err) => {
                console.error("ops! ocorreu um erro : " + err);
            });

        debugger
        const token: string = localStorage.getItem('fastFlex-token') ?? '';

        var decoded = jwt_decode<JwtPayload>(token);

        let DestinatarioId;

        if (decoded.role == "Admin") {

        }

        // const navigate = useNavigate();
        api.post("Destinatario/AdicionaDestinatario", {
            nome: $("input-nome").val(),
            sobrenome: $("input-sobrenome").val(),
            numeroDocumento: $("input-cpf").val(),
            cep: $("input-cep").val(),
            endereco: $("input-rua").val(),
            numero: $("input-num").val(),
            bairro: $("input-bairro").val(),
            cidade: $("input-cidade").val(),
            uf: $("input-estado").val()
        }).then(function (response) {
            DestinatarioId = response.data
        });

        // const navigate = useNavigate();
        api.post("Cliente/AdicionaCliente", {
            nome: $("input-nome").val(),
            sobrenome: $("input-sobrenome").val(),
            numeroDocumento: $("input-cpf").val(),
            cep: $("input-cep").val(),
            endereco: $("input-rua").val(),
            numero: $("input-num").val(),
            bairro: $("input-bairro").val(),
            cidade: $("input-cidade").val(),
            uf: $("input-estado").val()
        }).then(function (response) {
            DestinatarioId = response.data
        });

        const navigate = useNavigate();
        api.post("Entrega/AdicionaEntrega", {
            cepDestino: $("input-cep").val(),
            cepOrigem: "03680010",
            rua: $("input-rua").val(),
            numero: $("input-num").val(),
            bairro: $("input-bairro").val(),
            precoEntrega: 10,
            qtdPacotes: $("input-pedido-qtd").val(),
            horaSaida: new Date(Date.now()),
            horaEntrega: new Date(Date.now()),
            status: 0,
            entregadorId: 0,
            clienteId: 0,
            destinatarioId: DestinatarioId
        });

        var adicionarPacote = $('#s1').is(':checked');
        if (adicionarPacote == true) {
            // const navigate = useNavigate();
            api.post("Pacote/AdicionaPacote", {
                altura: $("input-altura").val(),
                largura: $("input-largura").val(),
                comprimento: $("input-comprimento").val(),
                peso: $("input-peso").val(),
            });
        }
    }

    //PEDIDO - FIM ===========================================

    var index;
    function TrocaDeTela(index: any) {
        switch (index) {
            case 1:
                $(".entregas-container").hide();
                $(".dash").show();
                $(".motoboys-container").hide();
                $(".clientes-container").hide();
                $(".pedidos-container").hide();
                $(".lado-D").addClass("animate__backInRight");
                $(".cimaDash").addClass("animate__backInUp");
                $(".dash-moto").addClass("animate__backInUp");
                $("#btn-motoboy").removeClass("animate__backInUp");

                $(".motoqueiros").removeClass("animate__backInUp");
                $("#btn-motoboy").hide();
                break;

            case 2:
                $(".pedidos-container").show();
                $(".entregas-container").hide();
                $(".dash").hide();
                $(".motoboys-container").hide();
                $(".clientes-container").hide();
                $("#btn-motoboy").removeClass("animate__backInUp");
                $("#btn-motoboy").hide();

                break;
            case 3:
                $(".motoboys-container").show();
                $(".dash").hide();
                $(".clientes-container").hide();
                $(".motoqueiros").addClass("animate__backInUp");
                $("#btn-motoboy").addClass("animate__backInUp");
                $(".entregas-container").hide();
                $(".pedidos-container").hide();
                $("#btn-motoboy").show();
                break;
            case 4:

                $(".motoboys-container").hide();
                $(".clientes-container").show();
                $(".dash").hide();
                $(".entregas-container").hide();
                $(".pedidos-container").hide();
                $("#btn-motoboy").removeClass("animate__backInUp");
                $("#btn-motoboy").hide();

                break;
            case 5:
                $(".entregas-container").show();
                $(".motoboys-container").hide();
                $(".clientes-container").hide();
                $(".dash").hide();
                $(".pedidos-container").hide();
                $("#btn-motoboy").removeClass("animate__backInUp");
                $("#btn-motoboy").hide();

                break;
            case 6:


                break;
        }
    }

    function EscondeInput() {
        var sera = $('#s1').is(':checked');
        if (sera == false) {
            $(".teste").hide();
            $(".input-cima").removeClass("animate__fadeIn");


        } else {
            $(".teste").show();
            $(".input-cima").addClass("animate__fadeIn");
        }
    }


    $(document).ready(function () {
        $(".lado-D").addClass("animate__backInRight");
        $(".cimaDash").addClass("animate__backInUp");
        $(".dash-moto").addClass("animate__backInUp");
        EscondeInput();
        $("#btn-motoboy").hide();

        $("#btn-motoboy").on("click", function () {
            $(".visuM").hide();
            $("#btn-motoboy").hide();
            $(".cadastro-motoca").show();
        });
        $("#btn-cadastroMotoca").on("click", function () {
            $(".visuM").show();
            $("#btn-motoboy").show();
            $(".cadastro-motoca").hide();
            $(".cadastro-motoca").addClass("animate__backInUp");

        });
    });




    return (

        <>
            <div className="fundo">
                <div className="area-logo col-md-12 animate__animated animate__flash">
                    <img id='logoB' src={LogoB} alt="" />
                </div>
                <div className="alinhamento">
                    <div className="esq col-md-3 animate__animated animate__backInLeft">
                        <b>Olá, <b id='nome'>Nome</b> Sobrenome</b>
                        <div className="menu-opn">
                            <ul className='lista'>
                                <li><img src={Dash} /><b onClick={() => TrocaDeTela(1)}>Dashboard</b></li>
                                <li><img src={Pedido} /><b onClick={() => TrocaDeTela(2)}>Pedido</b></li>
                                <li><img src={Motoca} /><b onClick={() => TrocaDeTela(3)}>Motoboys</b></li>
                                <li><img src={Cliente} /><b onClick={() => TrocaDeTela(4)} id="meusClientes">Meus clientes</b></li>
                                <li><img src={Entrega} /><b onClick={() => TrocaDeTela(5)}>Entregas</b></li>
                                <li><img src={Camp} /><b onClick={() => TrocaDeTela(6)}>Solicitações</b></li>
                            </ul>
                        </div>
                        <button id='btn-motoboy' className='animate__animated'>Novo Motoboy</button>
                    </div>
                    {/*====================== SESSÃO DASHBOARD ========================= */}
                    <div className="dash">
                        <div className="centroD col-md-5">
                            <div className="cabecalho">
                                <h2>Entregas</h2>
                                <select id="periodo" name="periodo">
                                    <option value="volvo" id='padrao'>Periodo</option>
                                    <option value="volvo">Hoje</option>
                                    <option value="saab">Essa semana</option>
                                    <option value="fiat">Esse mês</option>
                                    <option value="audi">Esse semestre</option>
                                    <option value="audi">Todos</option>
                                </select>
                            </div>

                            <div className="centerDash cimaDash animate__animated">
                                <div className="part1">
                                    <div className="faturamento">
                                        <div className="meio">
                                            <p>Faturamento</p>
                                            <h2>R$ 13.453,33</h2>
                                        </div>
                                    </div>
                                    <div className="totalEntg">
                                        <div className="meio">
                                            <p id='tira-margem'>Total de entregas</p>
                                            <div className="metas  d-flex">
                                                <b id='maior'>138</b><b id='menor'>/250</b>
                                            </div>
                                            <div className="progress">
                                                <div className="progress-value"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div className="resumos">
                                    <ul className='lista-status'>
                                        <li>Todas <b>230</b></li>
                                        <li>Em aberto <b>180</b></li>
                                        <li>Em andamento <b>132</b></li>
                                        <li id='ultimo'>Finalizadas <b>564</b></li>
                                    </ul>
                                </div>
                            </div>
                            <div className="dash-moto animate__animated">
                                <div className='d-flex moto'>
                                    <h2>Motoboys</h2>
                                    <b>Ver mais</b>
                                </div>
                                <div className="d-flex lado">
                                    <div className="motoboy">
                                        <div className="foto"></div>
                                        <b>Nome Sobrenome</b>
                                    </div>
                                    <div className="motoboy">
                                        <div className="foto"></div>
                                        <b>Nome Sobrenome</b>
                                    </div>
                                </div>
                                <div className="d-flex lado">
                                    <div className="motoboy">
                                        <div className="foto"></div>
                                        <b>Nome Sobrenome</b>
                                    </div>
                                    <div className="motoboy">
                                        <div className="foto"></div>
                                        <b>Nome Sobrenome</b>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div className="lado-D d-flex  col-md-3 animate__animated">
                            <input id='buscar' type="text" placeholder='Buscar' />
                            <div className="acao d-flex">
                                <div className="novo-pedido">
                                    <div className="quadrado">
                                        <img src={Pedido} alt="" />
                                    </div>
                                    <div className="d-flex b-Ped">
                                        <b>Pedido</b>
                                        <button onClick={() => TrocaDeTela(2)}>Novo pedido</button>
                                    </div>
                                </div>
                                <div className="novo-solicitacao">
                                    <div className="quadrado">
                                        <img src={Sino} alt="" />
                                    </div>
                                    <div className="d-flex b-Sol">
                                        <b>Solicitações</b>
                                        <button>Ver Solitações</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    {/*====================== FIM SESSÃO DASHBOARD ========================= */}
                    {/*======================  SESSÃO MOTOQUEIRO ========================= */}
                    <div className="motoboys-container">
                        <div className="meioM">
                            <div className="visuM">
                                <div className="tituloM">
                                    <div className="d-flex tittle">
                                        <h2>Motoboys</h2>
                                        <b>Veja todos os detalhes, adicione um novo ou edite um já existente</b>
                                    </div>
                                    <input type="text" placeholder='Buscar' ></input>
                                </div>
                                <div className="nomes">
                                    <b>Motoboy</b>
                                    <b>CPF</b>
                                    <b>CEP</b>
                                    <b>Alcance</b>
                                    <b>Ações</b>
                                </div>
                                <div id='area-motoboy'>

                                </div>

                            </div>
                            {/* ------------------------------CADASTRO MOTOCA----------------------------- */}
                            <div className="cadastro-motoca animate__animated">
                                <div className="tituloMC">
                                    <div className="d-flex tittle">
                                        <h2>Cadastro Motoboys</h2>
                                        <b>Adicione um novo motoboy</b>
                                    </div>
                                </div>
                                <div className="infos1">
                                    <input type="text" placeholder='Nome*' />
                                    <input type="text" placeholder='Sobrenome*' />
                                </div>
                                <div className="infos2">
                                    <input type="text" placeholder='RG*' />
                                    <input type="text" placeholder='MEI*' />
                                </div>
                                <div className="infos3">
                                    <input type="text" placeholder='Endereço*' />
                                </div>
                                <div className="infos4">
                                    <input type="text" placeholder='Bairro*' />
                                    <input type="text" placeholder='Cidade*' />
                                    <input type="text" placeholder='UF*' />
                                </div>
                                <div className="btn-CadastroMotoca d-flex">
                                    <button id='btn-cadastroMotoca'>Cadastrar</button>
                                </div>
                            </div>
                            {/* ------------------------------CADASTRO MOTOCA - FIM----------------------------- */}
                        </div>
                    </div>
                    {/*====================== FIM SESSÃO MOTOQUEIRO ========================= */}
                    {/*======================  SESSÃO CLIENTES ========================= */}
                    <div className="clientes-container">
                        <div className="meioC">
                            <div className="tituloM">
                                <div className="d-flex tittle">
                                    <h2>Meus clientes</h2>
                                    <b>Veja todos os detalhes, adicione um novo ou edite um já existente</b>
                                </div>
                                <input type="text" placeholder='Buscar' />
                            </div>
                            <div className="d-flex exp">
                                <div className="nomess">
                                    <b>Cliente</b>
                                    <b id='end'>Endereço</b>
                                </div>
                                <div className="nomess">
                                    <b>Telefone</b>
                                    <b>Ações</b>
                                </div>
                            </div>
                            <div id="area-cliente">

                            </div>
                        </div>
                    </div>
                    {/*====================== FIM  SESSÃO CLIENTES ========================= */}
                    {/*======================  SESSÃO ENTREGAS ========================= */}
                    <div className="entregas-container">
                        <div className="meioC">

                            <div className="tituloM">
                                <div className="d-flex tittle">
                                    <h2>Entregas</h2>
                                    <b>Veja todos os detalhes das entregas</b>
                                </div>
                                <input type="text" placeholder='Buscar' />
                            </div>
                            <div className="d-flex expo">
                                <div className="nomesss">
                                    <b>Cliente</b>
                                    <b id='end'>Destino</b>
                                    <b>Motoboy</b>
                                    <b>Cep</b>
                                    <b>Alcance</b>
                                </div>
                            </div>
                            <div className="motoqueiros animate__animated">
                                <div id='nomeInteiro2'>
                                    <div className="foto"></div>
                                    <b>Nome Cliente</b>
                                </div>
                                <b>09182-110</b>
                                <b>Nome Motoboy</b>

                                <div className="statuss"> Entregue</div>


                                <div className="acaoo">
                                    <div className="editar">
                                        <img src={Editar} alt="" />
                                        <a href="">Editar</a>
                                    </div>
                                    <div className="excluir">
                                        <img src={Excluir} alt="" />
                                        <a href="">Excluir</a>
                                    </div>
                                </div>
                            </div>

                            <div className="motoqueiros animate__animated">
                                <div id='nomeInteiro2'>
                                    <div className="foto"></div>
                                    <b>Nome Cliente</b>
                                </div>
                                <b>09182-110</b>
                                <b>Nome Motoboy</b>
                                <div className="statuss"> Entregue</div>



                                <div className="acaoo">
                                    <div className="editar">
                                        <img src={Editar} alt="" />
                                        <a href="">Editar</a>
                                    </div>
                                    <div className="excluir">
                                        <img src={Excluir} alt="" />
                                        <a href="">Excluir</a>
                                    </div>
                                </div>
                            </div>
                            <div className="motoqueiros animate__animated">
                                <div id='nomeInteiro2'>
                                    <div className="foto"></div>
                                    <b>Nome Cliente</b>
                                </div>
                                <b>09182-110</b>
                                <b>Nome Motoboy</b>

                                <div className="statuss"> Entregue</div>



                                <div className="acaoo">
                                    <div className="editar">
                                        <img src={Editar} alt="" />
                                        <a href="">Editar</a>
                                    </div>
                                    <div className="excluir">
                                        <img src={Excluir} alt="" />
                                        <a href="">Excluir</a>
                                    </div>
                                </div>
                            </div>

                            <div className="motoqueiros animate__animated">
                                <div id='nomeInteiro2'>
                                    <div className="foto"></div>
                                    <b>Nome Cliente</b>
                                </div>
                                <b>09182-110</b>
                                <b>Nome Motoboy</b>

                                <div className="statuss"> Entregue</div>
                                <div className="acaoo">
                                    <div className="editar">
                                        <img src={Editar} alt="" />
                                        <a href="">Editar</a>
                                    </div>
                                    <div className="excluir">
                                        <img src={Excluir} alt="" />
                                        <a href="">Excluir</a>
                                    </div>
                                </div>
                            </div>
                            <div className="motoqueiros animate__animated">
                                <div id='nomeInteiro2'>
                                    <div className="foto"></div>
                                    <b>Nome Cliente</b>
                                </div>
                                <b>09182-110</b>

                                <div className="statuss"> Entregue</div>

                                <div className="acaoo">
                                    <div className="editar">
                                        <img src={Editar} alt="" />
                                        <a href="">Editar</a>
                                    </div>
                                    <div className="excluir">
                                        <img src={Excluir} alt="" />
                                        <a href="">Excluir</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    {/*====================== FIM SESSÃO ENTREGAS ========================= */}

                    {/*======================  SESSÃO PEDIDOS ========================= */}
                    <div className="pedidos-container">
                        <div className="meioP">
                            <div className="tituloP">
                                <div className="d-flex tittle">
                                    <h2>Novo Pedido</h2>
                                    <b>Meça o pacote e insira os dados para adicionar o pedido</b>
                                </div>
                            </div>
                            <div className="d-flex input-cima animate__animated ">
                                <div>
                                    <input id='input-pedido-qtd' type="text" placeholder='Qnt. de pacotes*' />
                                    <input id='input-altura' className='teste' type="text" placeholder='Altura*' />
                                    <input id='input-largura' className='teste' type="text" placeholder='Largura*' />
                                    <input id='input-comprimento' className='teste' type="text" placeholder='Comprimento*' />
                                </div>
                                <div>
                                    <input id='input-peso' className='teste' type="text" placeholder='Peso*' />
                                    <input id='input-valorCarga' className='teste' type="text" placeholder='Valor da carga*' />
                                </div>
                            </div>
                            <div className="select">
                                <input id="s1" onClick={EscondeInput} type="checkbox" className="switch" />
                                <label id='label'>Adicionar dados do pacote</label>
                            </div>
                            <div className="destinatario animate__animated animate__fadeIn">
                                <b id='desd'>Destinatário</b>
                                <div className="linha1">
                                    <input id='input-nome' type="text" placeholder='Razão social' />
                                    <button>Novo Cliente</button>
                                </div>
                                <div className="linha2">
                                    {getClientes.map((cliente:any) => {
                                        return (
                                            <>
                                                <input id='input-cpf' type="text" value={cliente.id} placeholder='CPF ou CNPJ*' />
                                                <input id='input-cep' type="text" placeholder='CEP*' />
                                                <input id='input-rua' type="text" placeholder='Rua*' />
                                                <input id='input-num' type="text" placeholder='Número*' />
                                            </>
                                        )
                                    })}
                                </div>
                                <div className="linha3">
                                    <input id='input-bairro' type="text" placeholder='Bairro*' />
                                    <input type="text" placeholder='Coplemento' />
                                    <input id="input-est" type="text" placeholder='Estado' />
                                </div>
                                <div className="linha4">
                                    <input id='input-cidade' type="text" placeholder='Cidade' />
                                    <input id="input-obs" type="text" placeholder='Observação' />
                                </div>
                            </div>
                            <div className="d-flex btn-ctn">
                                <button onClick={AdicionaPedido}>Continuar</button>
                            </div>
                        </div>
                    </div>
                    {/*====================== FIM SESSÃO ENTREGAS ========================= */}


                </div>
            </div>
        </>
    );
}

export default Dashboard;