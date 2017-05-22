(function () {
    "use strict";
    angular
        .module("azTableManagement")
        .controller("AzTableCtrl",
                     ["azTableResource",
                         AzTableCtrl]);

    function AzTableCtrl(azTableResource) {
        var vm = this;
        
        
        
        azTableResource.azTableList(function (data) {
            vm.azTables = data;
            vm.currentTable = '';
        });

        vm.azTableListchanged = function (selectedItem) {
            azTableResource.azEntityListStudents({ name: selectedItem },
                    function (data) {
                        vm.StudentList = data;
                        vm.currentTable = selectedItem;
                    });
        }

        vm.azStudentListchanged = function (studentSelected) {
            azTableResource.azListStudentEntries({ name: vm.currentTable, id: studentSelected },
                    function (data) {
                        vm.Entries = data;
                    });
        }


        //vm.show = function (studentID) {
        //    azTableResource.Attendance.query({ sid: studentID },
        //        function (data) {
        //            vm.studentAttendances = data;
        //        });

            
        //};
    }

}());
