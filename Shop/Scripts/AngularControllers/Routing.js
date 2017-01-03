//angular.module('MyApp', ['ui.bootstrap', 'ngRoute', 'ngAnimate']) //extending from previously created angularjs module in part1
// here ['ngRoute'] is not required, I have just added to make you understand in a single place

(function () {
    //Create a Module 
    var app = angular.module('MyApp', ['ui.bootstrap', 'ngRoute', 'ngAnimate']);

app.config(function ($routeProvider, $locationProvider) {
    //here we will write code for implement routing 
    $routeProvider
    .when('/', { // This is for reditect to another route
        redirectTo: function () {
            return '/allbooks';
        }
    })
    .when('/allbooks', {
        templateUrl: 'Index',
        controller: 'AllBooksController'
    })
    .when('/audiobooks', {
        templateUrl: 'Index',
        controller: 'AudiobooksController'
    })
    .when('/ebooks', {
        templateUrl: 'Index',
        controller: 'EbooksController'
    })
    .when('/basket', {
        templateUrl: 'BasketItems',
        controller: 'BasketItemsController'
    })
    .when('/novelties', {
        templateUrl: 'Index',
        controller: 'NoveltiesController'
    })
    .when('/prevues', {
        templateUrl: 'Index',
        controller: 'PrevuesController'
    })
    .when('/greatdeals', {
        templateUrl: 'Index',
        controller: 'GreatDealsController'
    })

    .otherwise({   // This is when any route not matched
        redirectTo: 'Home/Index/allbooks'
    })

    $locationProvider.html5Mode(false).hashPrefix('!'); // This is for Hashbang Mode
})
.controller('AllBooksController', function ($scope, $modal, $log, $window, AllBooksService, searchService, myService) { //inject ContactService
    $scope.tab = "Wszystkie";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    AllBooksService.GetAllBooks().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    })
    .finally(function () {
        //Always execute this on both error and success
        $scope.visible = true;
    }),
    $scope.open = function (size) {

        var modalInstance = $modal.open({
            templateUrl: 'addToBasket.html',
            controller: 'BasketController',
            size: size,
            resolve: {
                Book: function () {
                    return $scope.Book;
                },
                book: function () {
                    return size;
                }
            }
        });
        modalInstance.result.then(function (Basket) {
            $scope.selected = Basket;
            
            myService.add($scope.selected.Quantity);
            $scope.TotalItems = myService.added();
            myService.set($scope.TotalItems);
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(0, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function(error){
            alert('Failed')
        })
    }
})

.controller('AudiobooksController', function ($scope, $modal, $log, $window, myService, AudiobooksService, searchService) { //inject ContactService
    $scope.tab = "Audiobooki";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    AudiobooksService.GetAudiobooks().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    }).finally(function () {
        // Always execute this on both error and success
        $scope.visible = true;
    }),

 $scope.open = function (size) {

     var modalInstance = $modal.open({
         templateUrl: 'addToBasket.html',
         controller: 'BasketController',
         size: size,
         resolve: {
             Book: function () {
                 return $scope.Book;
             },
             book: function () {
                 return size;
             }
         }
     });
     modalInstance.result.then(function (Basket) {
         $scope.selected = Basket;

         myService.add($scope.selected.Quantity);
         $scope.TotalItems = myService.added();
     }, function () {
         $log.info('Modal dismissed at: ' + new Date());
     });
 };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(1, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function (error) {
            alert('Failed')
        })
    }
})

.controller('EbooksController', function ($scope, $modal, $log, $window, myService, EbooksService, searchService) { //inject ContactService
    $scope.tab = "E-booki";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    EbooksService.GetEbooks().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    }).finally(function () {
        // Always execute this on both error and success
        $scope.visible = true;
    }),

    $scope.open = function (size) {

        var modalInstance = $modal.open({
            templateUrl: 'addToBasket.html',
            controller: 'BasketController',
            size: size,
            resolve: {
                Book: function () {
                    return $scope.Book;
                },
                book: function () {
                    return size;
                }
            }
        });
        modalInstance.result.then(function (Basket) {
            $scope.selected = Basket;

            myService.add($scope.selected.Quantity);
            $scope.TotalItems = myService.added();
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(2, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function (error) {
            alert('Failed')
        })
    }
})

.controller('NoveltiesController', function ($scope, $modal, $log, $window, myService, NoveltiesService, searchService) { //inject ContactService
    $scope.tab = "Nowości";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    NoveltiesService.GetNovelties().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    }).finally(function () {
        // Always execute this on both error and success
        $scope.visible = true;
    }),

    $scope.open = function (size) {

        var modalInstance = $modal.open({
            templateUrl: 'addToBasket.html',
            controller: 'BasketController',
            size: size,
            resolve: {
                Book: function () {
                    return $scope.Book;
                },
                book: function () {
                    return size;
                }
            }
        });
        modalInstance.result.then(function (Basket) {
            $scope.selected = Basket;

            myService.add($scope.selected.Quantity);
            $scope.TotalItems = myService.added();
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(3, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function (error) {
            alert('Failed')
        })
    }
})

.controller('PrevuesController', function ($scope, $modal, $log, $window, myService, PrevuesService, searchService) { //inject ContactService
    $scope.tab = "Zapowiedzi";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    PrevuesService.GetPrevues().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    }).finally(function () {
        // Always execute this on both error and success
        $scope.visible = true;
    }),

    $scope.open = function (size) {

        var modalInstance = $modal.open({
            templateUrl: 'addToBasket.html',
            controller: 'BasketController',
            size: size,
            resolve: {
                Book: function () {
                    return $scope.Book;
                },
                book: function () {
                    return size;
                }
            }
        });
        modalInstance.result.then(function (Basket) {
            $scope.selected = Basket;

            myService.add($scope.selected.Quantity);
            $scope.TotalItems = myService.added();
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(4, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function (error) {
            alert('Failed')
        })
    }
})

.controller('GreatDealsController', function ($scope, $modal, $log, $window, myService, GreatDealsService, searchService) { //inject ContactService
    $scope.tab = "Super okazje";
    $scope.Book = null;
    $scope.visible = false;
    $scope.modalShown = false;
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
    GreatDealsService.GetGreatDeals().then(function (d) {
        $scope.Book = d.data; // Success
    }, function (error) {
        alert('Failed'); // Failed
    }).finally(function () {
        // Always execute this on both error and success
        $scope.visible = true;
    }),

    $scope.open = function (size) {

        var modalInstance = $modal.open({
            templateUrl: 'addToBasket.html',
            controller: 'BasketController',
            size: size,
            resolve: {
                Book: function () {
                    return $scope.Book;
                },
                book: function () {
                    return size;
                }
            }
        });
        modalInstance.result.then(function (Basket) {
            $scope.selected = Basket;

            myService.add($scope.selected.Quantity);
            $scope.TotalItems = myService.added();
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
    $scope.search = function (searchbooks) {
        searchService.GetSearchedBooks(5, $scope.searchbooks).then(function (d) {
            if (d.data.length === 0) {
                $window.alert('W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania');
            }
            else {
                $scope.Book = d.data;
            }
        }, function (error) {
            alert('Failed')
        })
    }
})

.controller('BasketController', function ($scope, $modalInstance, Book, book, myService) {
    $scope.modalShown = true;
    $scope.BasketItems = [];
    var data = [
    {
        "PenDrive": "PenDrive"
    },
    {
        "CD": "CD"
    },
    {
        "DVD": "DVD"
    }
    ];
    $scope.options = data.reduce(function (memo, obj) {
        return angular.extend(memo, obj);
    }, {});
    console.log(book);
    $scope.book = book;
  
    $scope.Book = book
    $scope.selected = {
        book: $scope.Book[0],
    };

    $scope.ok = function () {
        $scope.Basket = {
            "BookTitle": $scope.book.Title,
            "Storage": $scope.basketBook.storage,
            "Quantity": parseInt($scope.basketBook.quantity),
            "TotalQuantity": 0,
            "Books": $scope.book
        },
        myService.push($scope.Basket);
        $modalInstance.close($scope.Basket)
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
})

.controller('BasketItemsController', function ($scope, myService) {
    $scope.BasketItems = myService.get();
    $scope.TotalItems = myService.added();
    myService.set($scope.TotalItems);
})

    ///////////////////////////////////////////////////

.factory('searchService', function ($http) {
    var fac = {};
    fac.GetSearchedBooks = function (routing, search) {
        return $http.get('/Book/GetSearchedBooks?' + 'routing=' + routing + '&' + 'search=' + search);
    }
    return fac;
})

.factory('AllBooksService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetAllBooks = function () {
        return $http.get('/Book/GetAllBooks');
    }
    return fac;
})

.factory('AudiobooksService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetAudiobooks = function () {
        return $http.get('/Book/GetAudiobooks');
    }
    return fac;
})

.factory('EbooksService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetEbooks = function () {
        return $http.get('/Book/GetEbooks');
    }
    return fac;
})

.factory('NoveltiesService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetNovelties = function () {
        return $http.get('/Book/GetNovelties');
    }
    return fac;
})

.factory('PrevuesService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetPrevues = function () {
        return $http.get('/Book/GetPrevues');
    }
    return fac;
})

.factory('GreatDealsService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};
    fac.GetGreatDeals = function () {
        return $http.get('/Book/GetGreatDeals');
    }
    return fac;
})

    ///////////////////////////////////////////////////

.service('myService', function () {
    var savedData = [];
    var totalitems = 0;
    var push = function (data) {
        savedData.push(data);
    };
    var get = function () {
        return savedData;
    };
    var add = function (data) {
        totalitems += data;
    };
    var added = function () {
        return totalitems;
    };
    var set = function (data) {
        totalitems = data;
    };

    return {
        push: push,
        get: get,
        add: add,
        added: added,
        set: set
    };

})
})();