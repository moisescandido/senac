import "./styles/Login.css"

export function Login() {
    const urlImagem = "https://images.pexels.com/photos/3913025/pexels-photo-3913025.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
    return (
        <div class="box">
            <div>
                <img src={urlImagem} />
            </div>
            <div>
                <div class="login">
                    <div>
                        <h1>LOG IN</h1>
                        <div class="inputs">
                            <input placeholder="E-MAIL" />
                            <input placeholder="SENHA" />
                        </div>
                        <div class="cadastro">
                            <div>
                                Não tem uma conta?
                            </div>
                            <div>
                                <strong><a>Cadastre-se agora!</a></strong>
                            </div>
                        </div>
                    </div>
                    <button>LOGIN</button>
                </div>
            </div>
        </div>
    )
}