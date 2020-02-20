<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webfrom.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js"></script>
    <script src="jscss/jquery.tmpl.js"></script>
    <link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tb" class="table">
                <tr>
                    <th>编号</th>
                    <th>姓名</th>
                    <th>性别</th>
                    <th>操作</th>
                </tr>
                <script id="sc" type="text/x-jquery-tmpl">
                    <tr>
                        <td>${id}</td>
                        <td>${Name}</td>
                        <td>${Sex}</td>
                        <td>
                            <a href="#" id="delete" sid="${id}">删除</a>
                            <a href="#" id="update" sid="${id}" sname="${Name}" ssex="${Sex}">编辑</a>
                        </td>
                    </tr>
                </script>
            </table>

        </div>
    </form>
    <button class="btn btn-primary" data-toggle="modal" data-target="#myModal">添加</button>
    <!-- 模态框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加
                    </h4>
                </div>
                <form id="form">
                    <div class="modal-body">

                        <input name="name" type="text" class="form-control" id="name" placeholder="姓名" />
                        <input name="sex" type="text" class="form-control" id="sex" placeholder="性别" />
                    </div>
                </form>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal" id="close">
                        关闭
                    </button>
                    <button type="button" id="insert" class="btn btn-primary">
                        提交更改
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>
    <!-- /.modal -->
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">修改
                    </h4>
                </div>
                <form id="form">
                    <div class="modal-body">
                        <label id="sid2"></label>
                        <input name="name2" type="text" class="form-control" id="name2" placeholder="姓名" />
                        <input name="sex2" type="text" class="form-control" id="sex2" placeholder="性别" />
                    </div>
                </form>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal" id="close">
                        关闭
                    </button>
                    <button type="button" id="update" class="btn btn-primary">
                        提交更改
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <script>
        $(function () {
            $("#tb").on("click", "#update", function () {
                var id = $(this).attr("sid");
                var name = $(this).attr("sname");
                var sex = $(this).attr("ssex");
                $("#name2").val(name);
                $("#sex2").val(sex);
                $("#sid2").text(id);
                $('#myModa2').modal("show");
            })
            //修改
            $("#update").click(function () {
                var name = $("#name2").val();
                var sex = $("#sex2").val();
                var id= $("#sid2").text();
                $.ajax({
                    url: "../../Handler/StudentUpdate.ashx",
                    data: { name: name, sex: sex, id: id },
                    dataType: "json",
                    success: function (json) {
                        if (json > 0) {
                            select();
                             $('#myModa2').modal("hide");
                        }
                    }
                })
            })
            $("#insert").click(function () {
                var name = $("#name").val();
                var sex = $("#sex").val();
                $("#myModalLabel").text("添加");
                $.ajax({
                    url: "../../Handler/StudentInsert.ashx",
                    data: { name: name, sex: sex },
                    dataType: "json",
                    success: function (json) {
                        if (json > 0) {
                            select();
                        }
                    }
                })
            })
            $("#tb").on("click", "#delete", function () {
                var id = $(this).attr("sid");
                if (confirm("是否删除")) {
                    $.ajax({
                        url: "../../Handler/StudentDelete.ashx",
                        data: { id: id },
                        dataType: "json",
                        success: function (json) {
                            if (json > 0) {
                                select();
                            }
                        }
                    })
                }

            })
            //查询
            select();
            function select() {
                $.ajax({
                    url: "../../Handler/Selete.ashx",
                    dataType: "json",
                    success: function (json) {
                        $("#tb tr:gt(0)").remove();
                        $("#sc").tmpl(json.data).appendTo("#tb");
                    }
                })
            }

        })
    </script>

</body>
</html>
