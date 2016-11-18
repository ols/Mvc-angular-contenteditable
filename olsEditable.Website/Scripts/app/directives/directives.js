app.directive("ngContenteditable", ["$http", function ($http) {
    return {
        restrict: "A",
        require: "ngModel",
        link: function (scope, element, attrs, ngModel) {

            element.bind("blur", function () {
                if (attrs.textValue == element.text())
                    return;

                var conf = confirm("Are you sure that you want to update: " + attrs.textKey + " from text: " + attrs.textValue + " to text: " + element.text() + " ?");
                if (conf) {
                    $http({
                        url: "/Home/Update",
                        method: "POST",
                        dataType: "JSON",
                        data: { textId: attrs.textKey, text: element.text() }
                    }).success(function (data) {
                        if (!data.Success) {
                            revertText();   
                            alert("Text with key: " + attrs.textKey + " could not be updated, reverting to old text, unsuccessfull");
                        }
                        else {
                            attrs.textValue = element.text();
                            alert(data.Message);
                        }
                    }).error(function (data) {
                        revertText();
                        alert("Text with key: " + attrs.textKey + " could not be updated, reverting to old text, error");
                    });
                } else {
                    revertText();
                }
            });

            function revertText() {
                element.text(attrs.textValue);
            };
        }
    };
}]);