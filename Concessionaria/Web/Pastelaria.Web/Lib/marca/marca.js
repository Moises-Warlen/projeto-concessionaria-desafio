
var marcas = (function () {
    // Configurações e URLs para comunicação com o servidor
    var config = {
        urls: {
            getGridMarcas: '',
            chamarTelaAdicionarMarca: '',
            ExcluirMarca: '',
            chamarTelaEditarMarca: '',
        }
    };


    // Função para buscar e exibir o grid de Marcas
    var getGridMarcas = function () {
        $.get(config.urls.getGridMarcas).done(function (data) {
            $('#div-grid-marcas').html(data);
        }).fail(function () {
            alert('Falha ao carregar as marcas.');
        });
    };

    // Função para carregar o formulário de adição da marca
    var chamarTelaAdicionarMarca = function () {
        $.get(config.urls.chamarTelaAdicionarMarca).done(function (data) {
            $('#div-add-marca').html(data); // Carrega o conteúdo da view no espaço designado
            $('#div-grid-marcas').hide(); // Oculta a grid de marcas se desejado
            $('#div-editar-marca').hide();// Oculta a grid de marcas se desejado
        }).fail(function () {
            alert('Falha ao carregar o formulário de adição da marca.');
        });
    };

    // Função para inserir uma marca
    var InserirMarca = function () {
        var marca = $('#marca').val(); // Obtém o valor do campo 'marca'
        // Faz a requisição POST com os dados da marca
        $.post(config.urls.chamarTelaAdicionarMarca, { Marca: marca })
            .done(function (data) {
                if (data.success) {
                    alert(data.message); // Exibe a mensagem de sucesso
                    getGridMarcas();     // Atualiza o grid de marcas após inserir uma nova marca
                    $('#div-add-marca').html(''); // Limpa o formulário de adição
                    $('#div-grid-marcas').show(); // Mostra o grid de marcas novamente
                } else {
                    alert(data.message); // Exibe a mensagem de erro
                }
            })
            .fail(function () {
                alert('Erro ao adicionar a marca.');
            });
    };

    // Função para excluir uma Marca
    var ExcluirMarca = function (id) {
        if (confirm("Você realmente deseja excluir esta marca?")) {
            $.post(config.urls.ExcluirMarca, { id: id }).done(function (data) {
                if (data.success) {
                    alert(data.message); // Exibe a mensagem de sucesso
                    getGridMarcas();     // Atualiza o grid de marcas
                } else {
                    alert(data.message); // Exibe a mensagem de erro
                }
            }).fail(function (xhr) {
                alert('Erro ao excluir a marca: ' + xhr.responseText);
            });
        }
    };

    // Função para chamar a tela de edição da marca
    var chamarTelaEditarMarca = function (id) {
        $.get(config.urls.chamarTelaEditarMarca, { id: id }).done(function (data) {
            $('#div-editar-marca').html(data);
            $('#div-editar-marca').show(); // Mostra o formulário de edição
            $('#div-grid-marcas').hide();   // Oculta a grid de marcas
            $('#div-add-marca').hide();     // Oculta o formulário de adição
        }).fail(function () {
            alert('Falha ao carregar o formulário de edição da marca.');
        });
    };


    // Função para editar a marca
    var EditarMarca = function () {
        var idMarca = $('#idMarca').val(); // Obtém o ID da marca
        var marca = $('#marca').val();     // Obtém o valor do campo 'marca'

        $.post(config.urls.EditarMarca, { IdMarca: idMarca, Marca: marca })
            .done(function (data) {
                if (data.success) {
                    alert(data.message);
                    getGridMarcas(); // Atualiza a grid de marcas
                    $('#div-editar-marca').html(''); // Limpa o formulário de edição
                    $('#div-editar-marca').hide();   // Oculta o formulário de edição
                    $('#div-grid-marcas').show();    // Mostra a grid de marcas novamente
                } else {
                    alert(data.message);
                }
            })
            .fail(function () {
                alert('Erro ao editar a marca.');
            });
    };


    // Função para cancelar a edição e voltar para a grade de marcas
    var CancelarEdicao = function () {
        $('#div-editar-marca').html(''); // Limpa o conteúdo da tela de edição
        $('#div-grid-marcas').show(); // Mostra a grade de marcas novamente
        $('#div-add-marca').show(); // Se quiser mostrar o formulário de adição
    };

    // Função para cancelar a Adicionar e voltar para a grade de marcas
    var CancelarAdicionar = function () {
        $('#div-editar-marca').html(''); // Limpa o conteúdo da tela de edição
        $('#div-grid-marcas').show(); // Mostra a grade de marcas novamente
        $('#div-add-marca').html(''); // Se quiser mostrar o formulário de adição
    };


    // Função inicial para carregar os dados necessários ao iniciar a página
    var init = function ($config) {
        config = $config;
        getGridMarcas();
    };

    return {
        init: init,
        getGridMarcas: getGridMarcas,
        chamarTelaAdicionarMarca: chamarTelaAdicionarMarca,
        InserirMarca: InserirMarca,
        ExcluirMarca: ExcluirMarca,
        chamarTelaEditarMarca: chamarTelaEditarMarca,
        EditarMarca: EditarMarca,
        CancelarEdicao: CancelarEdicao, 
        CancelarAdicionar: CancelarAdicionar
    };
})();
