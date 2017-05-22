(function () {
    "use strict";
    angular
        .module("azTableManagement")
        .controller("AzTableCtrl",
                     ["azTableResource",
                         AzTableCtrl]);

    function AzTableCtrl(azTableResource) {
        var vm = this;

        azTableResource.azTableList.query(function (data) {
            vm.azTables = data;
        });

        //vm.show = function (studentID) {
        //    azTableResource.Attendance.query({ sid: studentID },
        //        function (data) {
        //            vm.studentAttendances = data;
        //        });

            
        //};
    }

}());
