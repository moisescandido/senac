export const lerCategorias = async () => {
    try {
        const response = await axios.get('/api/postagem/categorias');
        return response.data;
    } catch (error) {
        return null;
    }
};