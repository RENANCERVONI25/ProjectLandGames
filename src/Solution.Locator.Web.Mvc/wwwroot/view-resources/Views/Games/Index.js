(function () {
  

    $(function() {

        var _gameService = abp.services.app.game;
        var _$modal = $('#GameCreateModal');
        var _$form = _$modal.find('form');


        //$('#RefreshButton').click(function () {
        //    refreshUserList();
        //});

        $('.delete-game').click(function () {
            var gameId = $(this).attr("data-game-id");
            var name = $(this).attr('data-game-name');

            deleteGame(gameId, name);
        });

        $('.edit-game').click(function (e) {
        
            var gameId = $(this).attr("data-game-id");
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Games/EditGameModal?gameId=' + gameId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    
                    $('#GameEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var game = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _gameService.create(game).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshGameList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteGame(gameId, name) {
            abp.message.confirm(
                "Deseja Deletar '" + name + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _gameService.delete({
                            id: gameId
                        }).done(function () {
                            refreshGameList();
                        });
                    }
                }
            );
        }
    });
})();