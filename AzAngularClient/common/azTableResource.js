(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("azTableResource",
                ["$resource",
                 "appSettings",
                    azTableResource])

    function azTableResource($resource, appSettings) {
        return {
            azTableList: $resource(appSettings.serverPath + "api/az/tables")
            //Attendance: $resource(appSettings.serverPath + "api/attendance/student/:sid")
        };
    }
}());