$(function () {

    var l = abp.localization.getResource('MoBlogging');
    var _createModal = new abp.ModalManager(abp.appPath + 'Admin/Blogs/Create');
    var _editModal = new abp.ModalManager(abp.appPath + 'Admin/Blogs/Edit');

    var _dataTable = $('#BlogsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: false,
        info: false,
        scrollX: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[3, "desc"]],
        ajax: abp.libs.datatables.createAjax(com.oPPO.mo.blogging.blogs.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('MoBlogging.Blog.Update'),
                                action: function (data) {
                                    _editModal.open({
                                        blogId: data.record.id
                                    });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('MoBlogging.Blog.Delete'),
                                confirmMessage: function (data) { return l('BlogDeletionWarningMessage') },
                                action: function (data) {
                                    com.oPPO.mo.blogging.blogs
                                        .delete(data.record.id)
                                        .then(function () {
                                            _dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                target: 1,
                data: "name"
            },
            {
                target: 2,
                data: "shortName"
            },
            {
                target: 3,
                data: "creationTime",
                render: function (date) {
                    return date;
                }
            },
            {
                target: 4,
                data: "description"
            }
        ]
    }));


    $("#CreateNewBlogButtonId").click(function () {
        _createModal.open();
    });

    _createModal.onClose(function () {
        _dataTable.ajax.reload();
    });

    _editModal.onResult(function () {
        _dataTable.ajax.reload();
    });

});