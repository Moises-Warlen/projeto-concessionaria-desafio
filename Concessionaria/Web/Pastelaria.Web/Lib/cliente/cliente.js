
var clientes = (function () {
    var config = {
        urls: {
            getGridClientes: '',
            buscarTelaAtualizarCliente: '',
            buscarClientePorCPF: '',
            deletarCliente: '',
            deletarTelefone: '',
            deletarEndereco: '',
            deletarEmail: '',
            post: '',
            linhaGridTelefone: '',
            linhaGridEndereco: '',
            linhaGridEmail: '',
        }
    };


    // Função para carregar a lista de clientes
    var getGridClientes = function () {
        $.get(config.urls.getGridClientes).done(function (data) {
            $('#div-grid-clientes').html(data);
        }).fail(function () {
            // Adicione aqui um tratamento de erro, se necessário
        });
    };

    // Função para buscar a tela de editar ou a add cliente
    var buscarTelaAtualizarCliente = function (id) {
        $.get(config.urls.buscarTelaAtualizarCliente, { id: id })
            .done(function (data) {
                $('#div-editar-cliente').html(data);
                $('#div-grid-clientes').hide();
                $('#div-add-cliente').hide(); ''
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
    };

    // Função para buscar a tela de editar ou a adicionar cliente usando CPF
    var buscarClientePorCPF = function (cpf) {
        $.get(config.urls.buscarClientePorCPF, { cpf: cpf })
            .done(function (data) {
                $('#div-editar-cliente').html(data);
                $('#div-grid-clientes').hide();
                $('#div-add-cliente').hide();
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
    };
    function buscarPorCPF() {
        var cpf = document.getElementById('searchInputCPF').value;
        console.log(cpf); // Exibe o valor do CPF no console
        buscarClientePorCPF(cpf);
    }

    // Função para buscar e exibir a tela de adição de um telefone de cliente
    var buscarTelaAdicionarTelefone = function (btn) {
        if (btn) {
            var tr = $(btn).closest('tr');
            var model = montaObjetoDadoContatoPorLinha($(tr));
            preecherFormDadosContato('formTelefone', model);
            tr.remove();
        }
        $('div#formTelefone').show();
    };

    // Função para buscar e exibir a tela de adição de um endereço de cliente
    var buscarTelaAdicionarEndereco = function (btn) {
        if (btn) {
            var tr = $(btn).closest('tr');
            var model = montaObjetoDadoContatoPorLinha($(tr));
            preecherFormDadosContato('formEndereco', model);
            tr.remove();
        }
        $('div#formEndereco').show();
    };

    // Função para buscar e exibir a tela de adição de um endereço de email
    var buscarTelaAdicionarEmail = function (btn) {
        if (btn) {
            var tr = $(btn).closest('tr');
            var model = montaObjetoDadoContatoPorLinha($(tr));
            preecherFormDadosContato('formEmail', model);
            tr.remove();
        }
        $('div#formEmail').show();
    };

    // Função para coletar os dados de uma linha da tabela
    function montarObjetoDadosPorLinha(linha) {
        var dados = {};
        linha.find('td[data-name]').each(function () {
            var td = $(this);
            dados[td.data('name')] = td.text();
        });
        return dados;
    }

    // Função para coletar dados de um formulário
    function montarObjetoDadosPorForm(form) {
        var dados = {};
        form.find('input[name], select[name]').each(function () {
            var campo = $(this);
            dados[campo.attr('name')] = campo.val();
        });
        return dados;
    }


    // Função para inserir o telefone no grid
    var inserirTelefone = function () {
        var form = $('div#formTelefone');  // Seleciona o formulário de telefone
        var modelo = montarObjetoDadosPorForm(form);  // Monta o objeto de dados a partir do formulário

        // Realiza uma requisição POST para adicionar o telefone
        $.post(config.urls.linhaGridTelefone, { telefone: modelo })
            .done(function (tr) {
                // Adiciona a linha retornada ao grid de telefones
                $('div#div-grid-telefone tbody').append(tr);
                // Esconde o formulário após a inserção
                form.hide();
                // Limpa o formulário após adicionar o telefone
                limparFormularioTelefone();
            })
            .fail(function () {
                // Caso haja um erro na requisição
                alert('Erro ao inserir telefone');
            });
    };

    // Função para limpar o formulário de telefone
    var limparFormularioTelefone = function () {
        var form = $('div#formTelefone');  // Seleciona o formulário de telefone
        // Limpa os campos de input
        form.find('input').val('');
        // Reseta o select para o primeiro item
        form.find('select').prop('selectedIndex', 0);
    };

    // Função para inserir o endereço no grid
    var inserirEndereco = function () {
        var form = $('div#formEndereco');  // Seleciona o formulário de endereço
        var modelo = montarObjetoDadosPorForm(form);  // Monta o objeto de dados a partir do formulário

        // Realiza uma requisição POST para adicionar o endereço
        $.post(config.urls.linhaGridEndereco, { endereco: modelo })
            .done(function (tr) {
                // Adiciona a linha retornada ao grid de endereços
                $('div#div-grid-endereco tbody').append(tr);
                // Esconde o formulário após a inserção
                form.hide();
                // Limpa o formulário após adicionar o endereço
                limparFormularioEndereco();  // Limpeza do formulário após inserção
            })
            .fail(function () {
                // Caso haja um erro na requisição
                alert('Erro ao inserir endereço');
            });
    };

    // Função para limpar o formulário de endereço
    var limparFormularioEndereco = function () {
        var form = $('div#formEndereco');  // Seleciona o formulário de endereço
        // Limpa os campos de input
        form.find('input').val('');
        // Reseta o select para o primeiro item
        form.find('select').prop('selectedIndex', 0);
        // Limpa o campo de textarea (se houver)
        form.find('textarea').val('');
    };


    // Função para inserir o e-mail no grid
    var inserirEmail = function () {
        var form = $('div#formEmail');  // Seleciona o formulário de e-mail
        var modelo = montarObjetoDadosPorForm(form);  // Monta o objeto de dados a partir do formulário

        // Realiza uma requisição POST para adicionar o e-mail
        $.post(config.urls.linhaGridEmail, { email: modelo })
            .done(function (tr) {
                // Adiciona a linha retornada ao grid de e-mails
                $('div#div-grid-email tbody').append(tr);
                // Esconde o formulário após a inserção
                form.hide();
                // Limpa o formulário após adicionar o e-mail
                limparFormularioEmail();  // Limpeza do formulário após inserção
            })
            .fail(function () {
                // Caso haja um erro na requisição
                alert('Erro ao inserir e-mail');
            });
    };

    // Função para limpar o formulário de e-mail
    var limparFormularioEmail = function () {
        var form = $('div#formEmail');  // Seleciona o formulário de e-mail
        // Limpa os campos de input
        form.find('input').val('');
        // Reseta o select para o primeiro item
        form.find('select').prop('selectedIndex', 0);
        // Limpa o campo de textarea (se houver)
        form.find('textarea').val('');
    };


    // Função para excluir um cliente

    var deletarCliente = function (id) {
        $.get(config.urls.deletarCliente, { id: id })
            .done(function () {
                alert('Cliente removido com sucesso!');
                getGridClientes(); // Recarrega a grade de clientes
            })
            .fail(function (xhr) {
                alert('Erro ao deletar cliente: ' + xhr.responseText);
            });
    };


    // Função para excluir um endereço
    var deletarEndereco = function (button) {
        // Verifica se o ID é inválido (nulo, zero ou vazio)
        if (!id || id <= 0) {
            
            // Seleciona a linha que contém o botão clicado
            var $linha = $(button).closest('tr');

            // Verifica se a linha tem um ID válido
            var id = $linha.data('id');

            if (!id || id <= 0) {
                // Remove a linha localmente se o ID for inválido
                $linha.remove();
                alert('O endereçofoi removido localmente, pois o ID fornecido é inválido.');
                return;

            }

        }

        // Faz a requisição ao servidor para deletar o endereço com ID válido
        $.get(config.urls.deletarEndereco, { id: id })
            .done(function () {
                // Remove a linha correspondente no grid após a confirmação
                $('tr[data-id="' + id + '"]').remove();
                alert('Endereço removido com sucesso!');
            })
            .fail(function (xhr) {
                // Mostra mensagem de erro ao usuário
                alert('Erro ao remover o endereço: ' + (xhr.responseText || 'Tente novamente mais tarde.'));
                console.error('Erro ao remover endereço:', xhr); // Log para depuração
            });
    };

    // Função para excluir um telefone
    var deletarTelefone = function (button) {
        // Verifica se o ID é inválido (nulo, zero ou vazio)
        if (!id || id <= 0) {
            // Seleciona a linha que contém o botão clicado
            var $linha = $(button).closest('tr');

            // Verifica se a linha tem um ID válido
            var id = $linha.data('id');

            if (!id || id <= 0) {
                // Remove a linha localmente se o ID for inválido
                $linha.remove();
                alert('O telefone foi removido localmente, pois o ID fornecido é inválido.');
                return;
            }
        }

        // Faz a requisição ao servidor para deletar o telefone com ID válido
        $.get(config.urls.deletarTelefone, { id: id })
            .done(function () {
                // Remove a linha correspondente no grid após a confirmação
                $('tr[data-id="' + id + '"]').remove();
                alert('Telefone deletado com sucesso!');
            })
            .fail(function (xhr) {
                // Mostra mensagem de erro ao usuário
                alert('Erro ao remover o telefone: ' + (xhr.responseText || 'Tente novamente mais tarde.'));
                console.error('Erro ao remover telefone:', xhr); // Log para depuração
            });
    };

    // Função para excluir um email
    var deletarEmail = function (button) {
        if (!id || id === 0) {
            // Se o ID for nulo ou zero, remova apenas a linha correspondente no grid de emails
            // Seleciona a linha que contém o botão clicado
            var $linha = $(button).closest('tr');

            // Verifica se a linha tem um ID válido
            var id = $linha.data('id');

            if (!id || id <= 0) {
                // Remove a linha localmente se o ID for inválido
                $linha.remove();
                alert('O email foi removido localmente, pois o ID fornecido é inválido.');
                return;
            }
        }

        // Se o ID é válido, faz a requisição ao servidor
        $.get(config.urls.deletarEmail, { id: id }).done(function (data) {
            $('tr[data-id="' + id + '"]').remove();
            alert('Email deletado com sucesso!');
        }).fail(function (xhr) {
            alert(xhr.responseText);
        });
    };

    // Função para salvar os dados do cliente
    var salvar = function () {
        var form = $('div#formCliente');
        var modelo = {
            IdCliente: $('input[name=IdCliente]').val(),
            Telefones: [],
            Endereco: [],
            Email: []
        };

        form.find('input[name], select[name]').each(function () {
            var campo = $(this);
            modelo[campo.attr('name')] = campo.val();
        });

        // Coleta os dados dos grids
        modelo.Telefones = coletarDadosGrid('div#div-grid-telefone');
        modelo.Endereco = coletarDadosGrid('div#div-grid-endereco');
        modelo.Email = coletarDadosGrid('div#div-grid-email');

        $.post(config.urls.post, modelo)
            .done(function () {
                alert('Cliente salvo com sucesso!');

                location.reload();
            })
            .fail(function () {
                var clientes = (function () {
                    var config = {
                        urls: {
                            getGridClientes: '',
                            buscarTelaAtualizarCliente: '',
                            buscarClientePorCPF: '',
                            deletarCliente: '',
                            deletarTelefone: '',
                            deletarEndereco: '',
                            deletarEmail: '',
                            post: '',
                            linhaGridTelefone: '',
                            linhaGridEndereco: '',
                            linhaGridEmail: '',
                        }
                    };

                    // Função para carregar a lista de clientes
                    var getGridClientes = function () {
                        $.get(config.urls.getGridClientes).done(function (data) {
                            $('#div-grid-clientes').html(data);
                        }).fail(function () {
                            // Adicione aqui um tratamento de erro, se necessário
                        });
                    };

                    // Função para buscar a tela de editar ou a add cliente
                    var buscarTelaAtualizarCliente = function (id) {
                        $.get(config.urls.buscarTelaAtualizarCliente, { id: id })
                            .done(function (data) {
                                $('#div-editar-cliente').html(data);
                                $('#div-grid-clientes').hide();
                                $('#div-add-cliente').hide(); ''
                            })
                            .fail(function (xhr) {
                                alert(xhr.responseText);
                            });
                    };

                    // Função para buscar a tela de editar ou a adicionar cliente usando CPF
                    var buscarClientePorCPF = function (cpf) {
                        $.get(config.urls.buscarClientePorCPF, { cpf: cpf })
                            .done(function (data) {
                                $('#div-editar-cliente').html(data);
                                $('#div-grid-clientes').hide();
                                $('#div-add-cliente').hide();
                            })
                            .fail(function (xhr) {
                                alert(xhr.responseText);
                            });
                    };
                    function buscarPorCPF() {
                        var cpf = document.getElementById('searchInputCPF').value;
                        console.log(cpf); // Exibe o valor do CPF no console
                        buscarClientePorCPF(cpf);
                    }

                    // Função para buscar e exibir a tela de adição de um telefone de cliente
                    var buscarTelaAdicionarTelefone = function (btn) {
                        if (btn) {
                            var tr = $(btn).closest('tr');
                            var model = montaObjetoDadoContatoPorLinha($(tr));
                            preecherFormDadosContato('formTelefone', model);
                            tr.remove();
                        }
                        $('div#formTelefone').show();
                    };

                    // Função para buscar e exibir a tela de adição de um endereço de cliente
                    var buscarTelaAdicionarEndereco = function (btn) {
                        if (btn) {
                            var tr = $(btn).closest('tr');
                            var model = montaObjetoDadoContatoPorLinha($(tr));
                            preecherFormDadosContato('formEndereco', model);
                            tr.remove();
                        }
                        $('div#formEndereco').show();
                    };

                    // Função para buscar e exibir a tela de adição de um endereço de email
                    var buscarTelaAdicionarEmail = function (btn) {
                        if (btn) {
                            var tr = $(btn).closest('tr');
                            var model = montaObjetoDadoContatoPorLinha($(tr));
                            preecherFormDadosContato('formEmail', model);
                            tr.remove();
                        }
                        $('div#formEmail').show();
                    };

                    // Função para coletar os dados de uma linha da tabela
                    function montarObjetoDadosPorLinha(linha) {
                        var dados = {};
                        linha.find('td[data-name]').each(function () {
                            var td = $(this);
                            dados[td.data('name')] = td.text();
                        });
                        return dados;
                    }

                    // Função para coletar dados de um formulário
                    function montarObjetoDadosPorForm(form) {
                        var dados = {};
                        form.find('input[name], select[name]').each(function () {
                            var campo = $(this);
                            dados[campo.attr('name')] = campo.val();
                        });
                        return dados;
                    }

                    // Função para adicionar um telefone ao grid
                    var inserirTelefone = function () {
                        var form = $('div#formTelefone');
                        var modelo = montarObjetoDadosPorForm(form);

                        $.post(config.urls.linhaGridTelefone, { telefone: modelo })
                            .done(function (tr) {
                                $('div#div-grid-telefone tbody').append(tr);
                                form.hide();
                                limparFormularioTelefone();  // Limpa o formulário após adicionar
                            })
                            .fail(function () {
                                alert('Erro ao inserir telefone');
                            });
                    };


                    // Função para adicionar um endereço ao grid
                    var inserirEndereco = function () {
                        var form = $('div#formEndereco');
                        var modelo = montarObjetoDadosPorForm(form);

                        $.post(config.urls.linhaGridEndereco, { endereco: modelo })
                            .done(function (tr) {
                                $('div#div-grid-endereco tbody').append(tr);
                                form.hide();
                                limparFormularioEndereco();  // Limpa o formulário após adicionar
                            })
                            .fail(function () {
                                alert('Erro ao inserir endereço');
                            });
                    };

                    // Função para adicionar um e-mail ao grid
                    var inserirEmail = function () {
                        var form = $('div#formEmail');
                        var modelo = montarObjetoDadosPorForm(form);

                        $.post(config.urls.linhaGridEmail, { email: modelo })
                            .done(function (tr) {
                                $('div#div-grid-email tbody').append(tr);
                                form.hide();
                                limparFormularioEmail();  // Limpa o formulário após adicionar
                            })
                            .fail(function () {
                                alert('Erro ao inserir e-mail');
                            });
                    };


                    // Função para excluir um cliente
                    var deletarCliente = function (id) {
                        $.get(config.urls.deletarCliente, { id: id })
                            .done(function () {
                                alert('Cliente removido com sucesso!');
                                getGridClientes(); // Recarrega a grade de clientes
                            })
                            .fail(function (xhr) {
                                alert('Erro ao deletar cliente: ' + xhr.responseText);
                            });
                    };

                    // Função para excluir um endereço
                    var deletarEndereco = function (id) {
                        // Verifica se o ID é inválido (nulo, zero ou vazio)
                        if (!id || id <= 0) {
                            // Remove a linha correspondente no grid de endereços localmente
                            $('#div-grid-endereco tr').filter(function () {
                                return !$(this).data('id'); // Seleciona itens com ID inválido
                            }).remove();

                            alert('O endereço foi removido localmente, pois o ID fornecido é inválido.');
                            return;
                        }

                        // Faz a requisição ao servidor para deletar o endereço com ID válido
                        $.get(config.urls.deletarEndereco, { id: id })
                            .done(function () {
                                // Remove a linha correspondente no grid após a confirmação
                                $('tr[data-id="' + id + '"]').remove();
                                alert('Endereço removido com sucesso!');
                            })
                            .fail(function (xhr) {
                                // Mostra mensagem de erro ao usuário
                                alert('Erro ao remover o endereço: ' + (xhr.responseText || 'Tente novamente mais tarde.'));
                                console.error('Erro ao remover endereço:', xhr); // Log para depuração
                            });
                    };

                    // Função para excluir um telefone
                    var deletarTelefone = function (id) {
                        // Verifica se o ID é inválido (nulo, zero ou vazio)
                        if (!id || id <= 0) {
                            // Remove a linha correspondente no grid de telefones localmente
                            $('#div-grid-telefone tr').filter(function () {
                                return !$(this).data('id'); // Seleciona itens com ID inválido
                            }).remove();

                            alert('O telefone foi removido localmente, pois o ID fornecido é inválido.');
                            return;
                        }

                        // Faz a requisição ao servidor para deletar o telefone com ID válido
                        $.get(config.urls.deletarTelefone, { id: id })
                            .done(function () {
                                // Remove a linha correspondente no grid após a confirmação
                                $('tr[data-id="' + id + '"]').remove();
                                alert('Telefone deletado com sucesso!');
                            })
                            .fail(function (xhr) {
                                // Mostra mensagem de erro ao usuário
                                alert('Erro ao remover o telefone: ' + (xhr.responseText || 'Tente novamente mais tarde.'));
                                console.error('Erro ao remover telefone:', xhr); // Log para depuração
                            });
                    };

                    // Função para excluir um email
                    var deletarEmail = function (id) {
                        if (!id || id === 0) {
                            // Se o ID for nulo ou zero, remova apenas a linha correspondente no grid de emails
                            $('#div-grid-email tr').filter(function () {
                                return $(this).data('id') === id;
                            }).remove();
                            alert('Email deletado localmente, pois o ID é inválido.');
                            return;
                        }

                        // Se o ID é válido, faz a requisição ao servidor
                        $.get(config.urls.deletarEmail, { id: id }).done(function (data) {
                            $('tr[data-id="' + id + '"]').remove();
                            alert('Email deletado com sucesso!');
                        }).fail(function (xhr) {
                            alert(xhr.responseText);
                        });
                    };

                    // Função para salvar os dados do cliente
                    var salvar = function () {
                        var form = $('div#formCliente');
                        var modelo = {
                            IdCliente: $('input[name=IdCliente]').val(),
                            Telefones: [],
                            Endereco: [],
                            Email: []
                        };

                        form.find('input[name], select[name]').each(function () {
                            var campo = $(this);
                            modelo[campo.attr('name')] = campo.val();
                        });

                        // Coleta os dados dos grids
                        modelo.Telefones = coletarDadosGrid('div#div-grid-telefone');
                        modelo.Endereco = coletarDadosGrid('div#div-grid-endereco');
                        modelo.Email = coletarDadosGrid('div#div-grid-email');
                        console.log(modelo)

                        $.post(config.urls.post, modelo)
                     .done(function (response) {
                         if (response.success) {
                             alert(success);
                             //alert('Cliente salvo com sucesso!');
                             location.reload();
                         } else {
                             alert(response.message);
                         }
                     })
                     .fail(function (xhr) {
                         alert('Erro ao salvar cliente.');
                     });

                    };






                    // Função para coletar os dados de uma tabela
                    function coletarDadosGrid(idGrid) {
                        var dados = [];
                        $(idGrid + ' table tbody tr').each(function () {
                            var tr = $(this);
                            dados.push(montarObjetoDadosPorLinha(tr));
                        });
                        return dados;
                    }

                    // Função inicial para carregar os dados necessários ao iniciar a página
                    var init = function ($config) {
                        config = $config;
                        getGridClientes();

                    };

                    return {
                        init: init,
                        getGridClientes: getGridClientes,
                        buscarTelaAtualizarCliente: buscarTelaAtualizarCliente,
                        buscarClientePorCPF: buscarClientePorCPF,
                        buscarTelaAdicionarTelefone: buscarTelaAdicionarTelefone,
                        buscarTelaAdicionarEndereco: buscarTelaAdicionarEndereco,
                        buscarTelaAdicionarEmail: buscarTelaAdicionarEmail,
                        inserirTelefone: inserirTelefone,
                        inserirEndereco: inserirEndereco,
                        inserirEmail: inserirEmail,
                        deletarCliente: deletarCliente,
                        deletarEndereco: deletarEndereco,
                        deletarTelefone: deletarTelefone,
                        deletarEmail: deletarEmail,
                        salvar: salvar,
                        buscarPorCPF: buscarPorCPF,
                    };
                })();

            });
    };

    // Função para coletar os dados de uma tabela
    function coletarDadosGrid(idGrid) {
        var dados = [];
        $(idGrid + ' table tbody tr').each(function () {
            var tr = $(this);
            dados.push(montarObjetoDadosPorLinha(tr));
        });
        return dados;
    }

    // Função inicial para carregar os dados necessários ao iniciar a página
    var init = function ($config) {
        config = $config;
        getGridClientes();

    };

    return {
        init: init,
        getGridClientes: getGridClientes,
        buscarTelaAtualizarCliente: buscarTelaAtualizarCliente,
        buscarClientePorCPF: buscarClientePorCPF,
        buscarTelaAdicionarTelefone: buscarTelaAdicionarTelefone,
        buscarTelaAdicionarEndereco: buscarTelaAdicionarEndereco,
        buscarTelaAdicionarEmail: buscarTelaAdicionarEmail,
        inserirTelefone: inserirTelefone,
        inserirEndereco: inserirEndereco,
        inserirEmail: inserirEmail,
        deletarCliente: deletarCliente,
        deletarEndereco: deletarEndereco,
        deletarTelefone: deletarTelefone,
        deletarEmail: deletarEmail,
        salvar: salvar,
        buscarPorCPF: buscarPorCPF,
    };
})();
