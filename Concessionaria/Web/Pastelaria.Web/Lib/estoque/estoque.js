var estoques = (function () {

    var config = {
        urls: {
            getGridEstoques: '',
            chamarTelaAdicionarEstoque: '',
            chamarTelaEditarEstoque: '',
            ExcluirEstoque: '',
        }
    };

    var getGridEstoques = function () {
        $.get(config.urls.getGridEstoques).done(function (data) {
            $('#div-grid-estoques').html(data);
        }).fail(function () {
            alert('Falha ao carregar estoques.');
        });
    };


    var chamarTelaAdicionarEstoque = function () {
        $.get(config.urls.chamarTelaAdicionarEstoque)
            .done(function (data) {
                $('#div-add-estoque').html(data);
                $('#div-grid-estoques').hide();
                $('#div-editar-estoque').hide();
            })
            .fail(function () {
                alert('Falha ao carregar o formulário de Adicionar estoque!');
            });
    };

    var InserirEstoque = function () {
        // Coleta os valores dos campos do formulário
        var modelo = $('#modelo').val();
        var anoFabricacao = $('#anoFabricacao').val();
        var turbo = $('#turbo').prop('checked');
        var cor = $('#cor').val();
        var placa = $('#placa').val();
        var valor = $('#valor').val();
        var descricao = $('#descricao').val();

        // Cria um objeto com os dados a serem enviados
        var dados = {
            Modelo: { IdModelo: modelo },
            Ano: anoFabricacao,
            MotorTurbo: turbo,
            Cor: cor,
            Placa: placa,
            Valor: valor,
            Detalhes: descricao
        };

        $.post(config.urls.chamarTelaAdicionarEstoque, dados)
            .done(function (data) {
                if (data.success) {
                    alert(data.message);
                    $('#div-add-estoque').html('');
                    $('#div-grid-estoques').show();
                    $('#div-editar-estoque').html(''); // Limpa o conteúdo de edição para evitar conflitos
                    getGridEstoques();  // Atualiza o grid após a adição do estoque
                } else {
                    alert(data.message);
                }
            })
            .fail(function () {
                alert('Erro ao adicionar o modelo.');
            });
    };

    var buscarAnoDoModelo = function () {
        $('#modelo').change(function () {
            var selectedOption = $(this).find('option:selected');
            var anoMinimo = selectedOption.data('anominimo');
            var anoMaximo = selectedOption.data('anomaximo');

            // Atualiza o campo de ano de fabricação
            $('#anoFabricacao')
                .attr('min', anoMinimo)
                .attr('max', anoMaximo)
                .val(anoMinimo); // Preenche com o ano mínimo
        });
       
    };

    // Função para excluir uma Estoque
    var ExcluirEstoque = function (id) {
        if (confirm("Você realmente deseja excluir esta estoque?")) {
            $.post(config.urls.ExcluirEstoque, { id: id }).done(function (data) {
                if (data.success) {
                    alert(data.message); // Exibe a mensagem de sucesso
                    getGridEstoques();     // Atualiza o grid de marcas
                } else {
                    alert(data.message); // Exibe a mensagem de erro
                }
            }).fail(function (xhr) {
                alert('Erro ao excluir a Estoque: ' + xhr.responseText);
            });
        }
    };


    // Função para chamar a tela de edição 
    var chamarTelaEditarEstoque = function (id) {
        $.get(config.urls.chamarTelaEditarEstoque, { id: id }).done(function (data) {
            $('#div-editar-estoque').html(data);
            $('#div-editar-estoque').show();
            $('#div-grid-estoques').hide(); // Oculta a grid 
            $('#div-add-estoque').hide();    // Oculta o formulário de adição
        }).fail(function () {
            alert('Falha ao carregar o formulário de edição ');
        });
    };

    // Função para editar 
    var EditarEstoque = function () {
        var idEstoque = $('#idEstoque').val();
        var cor = $('#cor').val();
        var placa = $('#placa').val();
        var valor = $('#valor').val();
        var descricao = $('#descricao').val();
        var motorTurbo = $('#turbo').prop('checked');

        var dados = {
            IdEstoque: idEstoque,
            Cor: cor,
            Placa: placa,
            Valor: valor,
            Detalhes: descricao,
            MotorTurbo: motorTurbo,
        };

        $.post(config.urls.EditarEstoque, dados)
            .done(function (data) {
                if (data.success) {
                    alert(data.message);
                    getGridEstoques();
                    $('#div-editar-estoque').html('');
                    $('#div-grid-estoques').show();
                    $('#div-add-estoque').show(); // Mostrar o formulário de adição após a edição
                } else {
                    alert(data.message);
                }
            })
            .fail(function () {
                alert('Erro ao editar o estoque.');
            });
    };




    var init = function ($config) {
        config = $config;
        getGridEstoques();
    };

    return {
        init: init,
        getGridEstoques: getGridEstoques,
        chamarTelaAdicionarEstoque: chamarTelaAdicionarEstoque,
        InserirEstoque: InserirEstoque,
        ExcluirEstoque:ExcluirEstoque,
        chamarTelaEditarEstoque: chamarTelaEditarEstoque,
        EditarEstoque: EditarEstoque,
        buscarAnoDoModelo: buscarAnoDoModelo,
      
    };
})();
