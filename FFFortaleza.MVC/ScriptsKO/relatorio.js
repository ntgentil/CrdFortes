function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

function RelatorioViewModel() {

    var self = this;

    self.OperacaoId = ko.observable("");
    self.Observacao = ko.observable("");
    self.Valor = ko.observable("");
    self.Categoria = ko.observable("");
    self.TipoOperacao = ko.observable("");

    var operacao = {
        OperacaoId: self.OperacaoId,
        Observacao: self.Observacao,
        Valor: self.Valor,
        Categoria: self.Categoria,
        TipoOperacao: self.TipoOperacao,
    };

    self.Operacao = ko.observable();
    self.Operacoes = ko.observableArray();

    $.ajax({
        url: 'Relatorios/Filtro/',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Operacoes(data);
        }
    });

    self.filtrar = function () {
        
            $.ajax({
                url: 'Relatorios/Filtro/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: "{categoria:'" + $('#categoria').val() + "', dataInicial:'" + $('#dataInicio').val() + "', dataFinal:'" + $('#dataFinal').val() + "' }",
                success: function (data) {
                    self.Operacoes.removeAll();
                    self.Operacoes(data);
                }
            }).fail(function (xhr, textStatus, err) {
                alert(err);
            });

    };

    

    self.reset = function () {
        self.Observacao("");
        self.Valor("");
        self.Categoria("");
        $('#List').show();
    };

    self.cancel = function () {
        self.Receita(null);
        $('#Create').hide();
        $('#Update').hide();
        $('#List').show();
    };
}

var viewModel = new RelatorioViewModel();
ko.applyBindings(viewModel);


$(document).ready(function () {
    $('#Adicionar').click(function () {
        $('#List').hide();
        $('#Create').show();
    });

});
