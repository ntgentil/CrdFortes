function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

function ReceitaViewModel() {

    var self = this;

    self.OperacaoId = ko.observable("");
    self.Observacao = ko.observable("");
    self.Valor = ko.observable("");
    self.Categoria = ko.observable("");
    self.TipoOperacao = ko.observable("");

    var receita = {
        OperacaoId: self.OperacaoId,
        Observacao: self.Observacao,
        Valor: self.Valor,
        Categoria: self.Categoria,
        TipoOperacao: self.TipoOperacao,
    };

    self.Receita = ko.observable();
    self.Receitas = ko.observableArray();

    $.ajax({
        url: 'Receitas/Filtro/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Receitas(data);
        }
    });

    self.create = function () {
        if (receita.Observacao != "" && receita.Categoria() != "" && receita.Valor() != "") {
            $.ajax({
                url: 'Receitas/Create/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(receita),
                success: function (data) {
                    self.Receitas.push(data);
                    self.Observacao("");
                    self.Valor("");
                    self.Categoria("");

                    $('#Create').hide();
                    $('#List').show();
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });

        } else {
            alert('Insira os valores corretamentes !!');
        }

    };

    self.delete = function (Receita) {
        if (confirm('Tem certeza que deseja deletar essa receita ??')) {
            var id = Receita.OperacaoId;

            $.ajax({
                url: 'Receitas/Delete/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: "{id:'" + ko.toJSON(id) + "'}",
                success: function (data) {
                    self.Receitas.remove(Receita);
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });
        }
    };

    self.edit = function (Receita) {
        
        $('#List').hide();
        $('#Update').show();

        self.Receita(Receita);

    };

    self.update = function () {
        var Receita = self.Receita();
        $.ajax({
            url: 'Receitas/Edit/',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Receita),
            success: function (data) {
                self.Receitas.removeAll();
                self.Receitas(data);
                self.Receita(null);
                $('#Update').hide();
                $('#List').show();
            }
        }).fail(function (xhr, textStatus, err) {
            alert(err);
        });
    };

    self.reset = function () {
        self.Observacao("");
        self.Valor("");
        self.Categoria("");
        $('#Create').hide();
        $('#Update').hide();
        $('#List').show();
    };

    self.cancel = function () {
        self.Receita(null);
        $('#Create').hide();
        $('#Update').hide();
        $('#List').show();
    };
}

var viewModel = new ReceitaViewModel();
ko.applyBindings(viewModel);


$(document).ready(function () {
    $('#Adicionar').click(function () {
        $('#List').hide();
        $('#Create').show();
    });

});
