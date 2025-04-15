var vendas = (function () {
    var config = {
        urls: {
            getGridVendas: '',
            chamarTelaAdicionarVenda: '',
            chamarTelaHistoricoVenda: '',
        }
    };

    var getGridVendas = function () {
        $.get(config.urls.getGridVendas).done(function (data) {
            $('#div-grid-vendas').html(data);
        }).fail(function () {
            alert('Falha ao carregar Vendas.');
        });
    };

    var chamarTelaAdicionarVenda = function () {
        $.get(config.urls.chamarTelaAdicionarVenda)
            .done(function (data) {
                $('#div-add-venda').html(data);
                $('#div-grid-vendas').hide();

            })
            .fail(function () {
                alert('Falha ao carregar a Tela de Adicionar venda!');
            });

        // Ouvir o evento de submissão do formulário para adicionar a venda
        $('#div-add-venda').on('submit', 'form', function (e) {
            e.preventDefault();
            var formData = $(this).serialize();

            $.post($(this).attr('action'), formData)
                .done(function () {
                   
                })
                .fail(function () {
                    alert('Erro ao adicionar a venda.');
                });
        });
    };

    var chamarTelaHistoricoVenda = function (id) {
        if (!id || isNaN(id)) {
            alert('ID inválido');
            return;
        }

        $.get(config.urls.chamarTelaHistoricoVenda, { idVenda: id })
            .done(function (data) {
                $('#div-historico-vendas').html(data);
                $('#div-add-venda').hide();
                $('#div-grid-vendas').hide();
            })
            .fail(function () {
                alert('Falha ao carregar a Tela de Histórico de Vendas!');
            });
    };

    // Função para voltar 
    var CancelarAdicionar = function () {
        $('#div-historico-vendas').html(''); 
        $('#div-grid-vendas').show();
        $('#div-add-venda').show();
    };


    // Função inicial para carregar os dados necessários ao iniciar a página
    var init = function ($config) {
        config = $config;
        getGridVendas();

    };

    return {
        init: init,
        getGridVendas: getGridVendas,
        chamarTelaAdicionarVenda: chamarTelaAdicionarVenda,
        chamarTelaHistoricoVenda: chamarTelaHistoricoVenda,
        CancelarAdicionar: CancelarAdicionar,
    };
})();
