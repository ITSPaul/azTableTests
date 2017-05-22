(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("azTableResource",
                ["$resource",
                 "appSettings",
                    azTableResource])

    function azTableResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/az/getTable/:name", null,
        {
                azTableList: {
                url: appSettings.serverPath + "api/az/ListTables",
                method: 'GET', isArray: true
                },
                azEntityListStudents : {
                    url: appSettings.serverPath + "api/az/ListNamesFromTable/TableName/:name",
                    method: 'GET', isArray: true
                },
                azListStudentEntries: {
                    url: appSettings.serverPath + "api/az/ListEntriesFromTableForEntity/TableName/:name/Entity/:id",
                    method: 'GET', isArray: true
                },

            

         query: { method: 'GET', params: { name: '' }, isArray: true },
                    })
    };
}());