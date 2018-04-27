(function () {
  

    $(function() {

        var _friendService = abp.services.app.friend;
        var _$modal = $('#FriendCreateModal');
        var _$form = _$modal.find('form');


        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-friend').click(function () {
            var friendId = $(this).attr("data-friend-id");
            var name = $(this).attr('data-friend-name');

            deleteFriend(friendId, name);
        });

        $('.edit-atacched-games').click(function (e) {

            var friendId = $(this).attr("data-friend-id");
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Friends/AtacchedGamesModal?friendId=' + friendId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {

                    $('#AtacchedGamesModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });


        $('.edit-friend').click(function (e) {
        
            var friendId = $(this).attr("data-friend-id");
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Friends/EditFriendModal?friendId=' + friendId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    
                    $('#FriendEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var friend = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _friendService.create(friend).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshFriendList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteUser(userId, userName) {
            abp.message.confirm(
                "Deseja Deletar '" + userName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _friendService.delete({
                            id: userId
                        }).done(function () {
                            refreshFriendList();
                        });
                    }
                }
            );
        }
    });
})();