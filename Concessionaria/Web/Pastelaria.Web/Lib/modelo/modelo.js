
var modelos = (function () {
 
    var config = {
        urls: {
            getGridModelos: '',
            chamarTelaAdicionarModelo: '',
            ExcluirModelo: '',
            chamarTelaEditarModelo: '',
        }
    };

    // Função para recarregar a página
    var refreshPage = function () {
        location.reload();
    };
    // Função para buscar e exibir o grid de Modelos
    var getGridModelos = function () {
        $.get(config.urls.getGridModelos).done(function (data) {
            $('#div-grid-modelos').html(data);
        }).fail(function () {
            alert('Falha ao carregar as marcas.');
        });
    };

    // Função para carregar o formulário de adição de Modelo
    var chamarTelaAdicionarModelo = function () {
        console.log(config.urls.chamarTelaAdicionarModelo);

        $.get(config.urls.chamarTelaAdicionarModelo)
            .done(function (data) {
                $('#div-add-modelo').html(data); // Carrega o conteúdo da view no espaço designado
                $('#div-grid-modelos').hide(); // Oculta a grid de modelo se desejado
                $('#div-editar-modelo').hide(); // Oculta o formulário de edição se desejado
            })
            .fail(function () {
                alert('Falha ao carregar o formulário de Adicionar modelo!');
            });
    };

    // Função para inserir um modelo
    var InserirModelo = function () {
        // Coleta os valores dos campos do formulário
        var modelo = $('#modelo').val();
        var marcaId = $('#marca').val();
        var potenciaId = $('#potencia').val();
        var tipoId = $('#tipo').val();
        var anoMinimo = $('#anoMinimo').val();
        var anoMaximo = $('#anoMaximo').val();

        // Validação para garantir que o ano mínimo não seja maior que o ano máximo
        if (anoMinimo > anoMaximo) {
            alert('O ano mínimo não pode ser maior que o ano máximo.');
            return;
        }

        // Cria um objeto com os dados a serem enviados
        var dados = {
            Modelo: modelo,
            Marca: { IdMarca: marcaId },
            Potencia: { IdMotorizacao: potenciaId },
            Tipo: { IdTipoCarroceria: tipoId },
            AnoMinimo: anoMinimo,
            AnoMaximo: anoMaximo
        };

        // Faz a requisição POST com os dados do modelo
        $.post(config.urls.chamarTelaAdicionarModelo, dados)
            .done(function (data) {
                if (data.success) {
                    alert(data.message);
                    $('#div-add-modelo').html('');
                    refreshPage();
                    $('#div-grid-modelos').show();
                } else {
                    alert(data.message);
                }
            })
            .fail(function () {
                alert('Erro ao adicionar o modelo.');
            });
    };

    // Função para excluir uma Modelo
    var ExcluirModelo = function (id) {
        if (confirm("Você realmente deseja excluir este modelo?")) {
            $.post(config.urls.ExcluirModelo, { id: id }).done(function (data) {
                if (data.success) {
                    alert(data.message); // Exibe a mensagem de sucesso
                    refreshPage(); // Recarrega a página após a exclusão
                } else {
                    alert(data.message); // Exibe a mensagem de erro
                }
            }).fail(function (xhr) {
                alert('Erro ao excluir a modelo: ' + xhr.responseText);
            });
        }
    };

    // Função para chamar a tela de edição 
    var chamarTelaEditarModelo = function (id) {
        $.get(config.urls.chamarTelaEditarModelo, { id: id }).done(function (data) {
            $('#div-editar-modelo').html(data);
            $('#div-grid-modelos').hide(); // Oculta a grid 
            $('#div-add-modelo').hide();    // Oculta o formulário de adição
        }).fail(function () {
            alert('Falha ao carregar o formulário de edição ');
        });
    };
   
    // Função para editar 
    var EditarModelo = function () {
        var idModelo = $('#idModelo').val();
        var modelo = $('#modelo').val();
        var marcaId = $('#marca').val();
        var potenciaId = $('#potencia').val();
        var tipoId = $('#tipo').val();
        var anoMinimo = $('#anoMinimo').val();
        var anoMaximo = $('#anoMaximo').val();

        // Validação para garantir que o ano mínimo não seja maior que o ano máximo
        if (anoMinimo > anoMaximo) {
            alert('O ano mínimo não pode ser maior que o ano máximo.');
            return;
        }

        var dados = {
            IdModelo: idModelo,
            Modelo: modelo,
            Marca: { IdMarca: marcaId },
            Potencia: { IdMotorizacao: potenciaId },
            Tipo: { IdTipoCarroceria: tipoId },
            AnoMinimo: anoMinimo,
            AnoMaximo: anoMaximo
        };

        $.post(config.urls.EditarModelo, dados)
            .done(function (data) {
                if (data.success) {
                    alert(data.message);
                    getGridModelos();
                    $('#div-editar-modelo').html('');
                    $('#div-grid-modelos').show();
                } else {
                    alert(data.message);
                }
            })
            .fail(function () {
                alert('Erro ao editar o modelo.');
            });
    };


    // Função para cancelar a edição e voltar 
    var CancelarEdicao = function () {
        $('#div-editar-modelo').html(''); // Limpa o conteúdo da tela de edição
        $('#div-grid-modelos').show(); 
        $('#div-add-modelo').show(); // Se quiser mostrar o formulário de adição
    };

    // Função para cancelar a Adicionar e voltar 
    var CancelarAdicionar = function () {
        $('#div-editar-modelo').html(''); // Limpa o conteúdo da tela de edição
        $('#div-grid-modelos').show(); // Se quiser mostrar o grid
        $('#div-add-modelo').html(''); 
    };



    // Função inicial para carregar os dados necessários ao iniciar a página
    var init = function ($config) {
        config = $config;
        getGridModelos(); // Isso garante que a grid de modelos seja carregada ao iniciar
    };

    return {
        init: init,
        getGridModelos: getGridModelos,
        chamarTelaAdicionarModelo: chamarTelaAdicionarModelo,
        InserirModelo: InserirModelo,
        ExcluirModelo: ExcluirModelo,
        chamarTelaEditarModelo: chamarTelaEditarModelo,
        EditarModelo: EditarModelo,
        refreshPage: refreshPage,
        CancelarEdicao: CancelarEdicao,
        CancelarAdicionar: CancelarAdicionar,
        
    };
})();
