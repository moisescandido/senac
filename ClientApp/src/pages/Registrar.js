import "./styles/login-cadastro.css"

export function Registrar() {
    const urlImagem = "https://images.pexels.com/photos/3913025/pexels-photo-3913025.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
    return (
        <div class="box">
            <div>
                <img src={urlImagem} />
            </div>
            <div>
                <div class="login">
                    <div>
                        <h1>REGISTRAR</h1>
                        <div class="inputs">
                            <input placeholder="NOME" />
                            <input placeholder="E-MAIL" />
                            <input placeholder="SENHA" />
                            <input placeholder="REPITA SENHA" />
                        </div>
                    </div>
                    <button>REGISTRAR</button>
                </div>
            </div>
        </div>
    )
}