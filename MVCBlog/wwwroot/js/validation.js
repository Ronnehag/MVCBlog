

// Validation for the create new post form
(function validationCreateNewPost() {

    // DOM ELEMENTS
    const headlineValidationSpan = document.querySelector("#maxcharsHeadline");
    const contentValidationSpan = document.querySelector("#maxcharsTextarea");
    const headlineInput = document.querySelector("#newPostHeadline");
    const contentInput = document.querySelector("#newPostContent");
    const headlineMaxValue = document.querySelector("#newPostHeadline").maxLength;
    const contentMaxValue = document.querySelector("#newPostContent").maxLength;

    // Maxvalues for the inputfields in the form


    // Handles the displaying of max chars for the content
    function contentChangeHandler(e) {
        const totalChars = e.target.value.length;
        contentValidationSpan.innerHTML = totalChars;
        if (totalChars >= contentMaxValue) {
            contentValidationSpan.parentElement.classList.add("text-red");
        } else {
            contentValidationSpan.parentElement.classList.remove("text-red");
        }
    }

    // Handles the displaying of max chars for the headline
    function headlineChangeHandler(e) {
        const totalChars = e.target.value.length;
        headlineValidationSpan.innerHTML = totalChars;
        if (totalChars >= headlineMaxValue) {
            headlineValidationSpan.parentElement.classList.add("text-red");
        } else {
            headlineValidationSpan.parentElement.classList.remove("text-red");
        }
    }


    // Adding eventlisteners to the input fields
    headlineInput.addEventListener("keyup", headlineChangeHandler);
    headlineInput.addEventListener("keydown", headlineChangeHandler);
    contentInput.addEventListener("keyup", contentChangeHandler);
    contentInput.addEventListener("keydown", contentChangeHandler);


})();



