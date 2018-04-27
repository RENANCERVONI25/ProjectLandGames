(function ($) {

    var _friendService = abp.services.app.atacched;
    var _$modal = $('#AtacchedGamesModal');
    var _$form = $('form[name=AtacchedGameEditForm]');
    
    function save() {

        if (!_$form.valid()) {
            return;
        }

        var friend = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);

        friend.Games = [];
        var _$gameCheckboxes = $("input[name='game']:checked");
        if (_$gameCheckboxes) {
            for (var gameIndex = 0; gameIndex < _$gameCheckboxes.length; gameIndex++) {
                var _$gameCheckbox = $(_$gameCheckboxes[gameIndex]);
                friend.Games.push(_$gameCheckbox.val());
            }
        }

        _friendService.atacched(friend).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited Friend!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
            _$modal.modal('hide');
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);