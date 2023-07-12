import axios from 'axios';

export const loginUsuario = async (email, senha) => {
    try {
        const response = await axios.get('/api/usuario', {
            params: {
                email: email,
                senha: senha
            }
        });
        if (response.status === 200) {
            localStorage.setItem('webLoki', JSON.stringify(response.data));
            return true;
        } else {
            return false;
        }
    } catch (error) {
        return false;
    }
};

export const informacoesUsuario = async (nome) => {
    try {
        const response = await axios.get('/api/usuario/user', {
            params: {
                nome: nome
            }
        });
        return response.data;
    } catch (error) {
        return null;
    }
};

export const criarUsuario = async (nome, email, senha) => {
    const data = {
        Foto: null,
        Nome: nome,
        Email: email,
        Senha: senha
    };

    try {
        const response = await axios.post('/api/usuario', data);
        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    } catch (error) {
        return false;
    }
};

export const alterarUsuario = async (id, foto, nome, email, senha) => {
    const data = {
        Id: id,
        Foto: foto,
        Nome: nome,
        Email: email,
        Senha: senha
    };

    try {
        const response = await axios.put('/api/usuario', data);
        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    } catch (error) {
        return false;
    }
};

export const deletarUsuario = async (id) => {
    try {
        const response = await axios.delete('/api/usuario', {
            params: {
                id: id
            }
        });
        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    } catch (error) {
        return false;
    }
};
