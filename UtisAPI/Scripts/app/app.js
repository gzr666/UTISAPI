/// <reference path="../directives/pagination/dirPagination.tpl.html" />
/// <reference path="../directives/pagination/dirPagination.tpl.html" />
var myApp = angular.module("app", ["angularUtils.directives.dirPagination"]);

myApp.config(function (paginationTemplateProvider) {
    paginationTemplateProvider.setPath("/Scripts/directives/pagination/dirPagination.tpl.html");
});


myApp.controller("UsersController", function ($timeout,$scope, $http) {



    $scope.users = [];
    $scope.totalUsers = 0;
    $scope.usersPerPage = 4; // this should match however many results your API puts on one page
    getResultsPage(0);

    $scope.pagination = {
        current: 0
    };

    $scope.pageChanged = function (newPage) {
        getResultsPage(newPage);
    };

    function getResultsPage(pageNumber) {
        // this is just an example, in reality this stuff should be in a service
        $http.get('http://localhost:58351/api/users?page=' + pageNumber)
            .then(function (result) {
                $scope.users = result.data.users;
                $scope.totalUsers = result.data.totalCount;
                $scope.usersPerPage = result.data.pageSize;

            });
    }


});

myApp.controller("UplataController", function ($timeout,$scope,$http) {

   
    $scope.years = [];
    $scope.vrste = [];
    $scope.user = {};
    $scope.uspjeh = false;
   

   
    $scope.preostalo2 = 100;

   
  

    var getYears = function () {
        $http.get("http://localhost:58351/api/Memberships/years")
            .success(function (result) {



              
                $scope.years = result;



            });

    };


    var getVrsta = function () {
        $http.get("http://localhost:58351/api/Memberships/vrsteuplate")
            .success(function (result) {




                angular.copy(result, $scope.vrste);



            });

    };


    $scope.submitForm = function (validation, userid,user,vrsta,year) {

      

        var myuser =
        {
            userID: userid,
            amount: user.amount,
            vrstaID: vrsta,
            yearID:year

        };
        

        console.log(myuser);


        $http.post("http://localhost:58351/api/Memberships", myuser).then(
            function (result)
            {
              
              

                $scope.uspjeh = true;
                //$scope.racun = false;
                $timeout(function () {
                    $scope.uspjeh = false;
                    $scope.getTotal(result.data.yearId, result.data.userId);
                }, 3000);
              
              

                

               
               
            },

            function (error) {

                

            });

    };

    var timing = function(yearId,userId) {
        $scope.uspjeh = false;
        
    };

    $scope.getTotal = function (year,id) {

        $scope.racun = false;
        $scope.uclanjenprije = false;
        $scope.uclanjennaknadno = false;
        $scope.showPicture = false;

        if (year == null)
        {
        }
        else
        {
        
        $http.get("http://localhost:58351/api/Memberships/" + id + "/" + year)
        .success(function (result) {

          

            $scope.ukupnoUplaceno = result.ukupnoUplaceno;
            $scope.preostaloZaUplatu = result.preostaloZaUplatu;
            $scope.godisnjaClanarina = result.godisnjaClanarina;


            
            if (result.godisnjaClanarina == 0) {
                $scope.uclanjenprije = true;
                $scope.uclanjennaknadno = true;
                result.godisnjaClanarina = -1;



            }
            else {


                if (result.ukupnoUplaceno == result.godisnjaClanarina) {
                   
                    $scope.racun = false;
                    $scope.uclanjennaknadno = true;
                    $scope.showPicture = true;


                }
                else {

                   
                    $scope.racun = true;
                    $scope.uclanjennaknadno = false;
                    $scope.showPicture = false;


                }

            }

            
            
            

            





        });

    }

    };

   


    getYears();
    getVrsta();
});