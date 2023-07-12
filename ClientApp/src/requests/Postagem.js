import axios from 'axios';

export const criarPostagem = async (idUsuario, idCategoria, Titulo, Conteudo) => {
    try {
        var dataAtual = new Date();
        var horas = dataAtual.getHours();
        var minutos = dataAtual.getMinutes();
        var segundos = dataAtual.getSeconds();

        var horaFormatada = horas.toString().padStart(2, '0') + ':' + minutos.toString().padStart(2, '0') + ':' + segundos.toString().padStart(2, '0');

        const data = {
            idUsuario: idUsuario,
            idCategoria: idCategoria,
            Titulo: Titulo,
            Conteudo: Conteudo,
            DataCriacao: horaFormatada
        }

        const response = await axios.post('/api/postagem', data);
        return response.data;
    } catch (error) {
        return null;
    }
};

export const deletarPostagem = async (id) => {
    try {
        const response = await axios.delete('/api/postagem', {
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

export const lerPostagem = async (id) => {
    try {
        const response = await axios.get('/api/postagem', {
            params: {
                id: id
            }
        });
        return response.data;
    } catch (error) {
        return null;
    }
};

export const lerPostagemPreview = async (num) => {
    try {
        const response = await axios.get('/api/postagem/post', {
            params: {
                id: num
            }
        });
        return response.data;
    } catch (error) {
        return null;
    }
};

export const curtirPostagem = async (idUsuario, idPostagem) => {
    try {
        const response = await axios.post('/api/postagem/curtir', {
            params: {
                IdUsuario: idUsuario,
                IdPostagem: idPostagem
            }
        });
        return response.data;
    } catch (error) {
        return null;
    }
};
