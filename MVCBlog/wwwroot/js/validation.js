

// Validation for the create new post form
(function validationCreateNewPost() {

    // DOM ELEMENTS
    const headlineValidationSpan = document.querySelector("#maxcharsHeadline");
    const contentValidationSpan = document.querySelector("#maxcharsTextarea");
    const headlineInput = document.querySelector("#newPostHeadline");
    const contentInput = document.querySelector("#newPostContent");
    const headlineMaxValue = headlineInput.maxLength;
    const contentMaxValue = contentInput.maxLength;
    const headlineMinValue = headlineInput.minLength;
    const contentMinValue = contentInput.minLength;

    // Handles the displaying of max chars for the content
    function contentChangeHandler(e) {
        const totalChars = e.target.value.length;
        contentValidationSpan.innerHTML = totalChars;

        if (totalChars >= contentMaxValue || totalChars < contentMinValue) {
            contentValidationSpan.parentElement.classList.add("text-red");
        } else {
            contentValidationSpan.parentElement.classList.remove("text-red");
        }

        if (totalChars >= contentMinValue && totalChars < contentMaxValue) {
            contentValidationSpan.parentElement.classList.add("text-green");
        } else {
            contentValidationSpan.parentElement.classList.remove("text-green");
        }
    }

    // Handles the displaying of max chars for the headline
    function headlineChangeHandler(e) {
        const totalChars = e.target.value.length;
        headlineValidationSpan.innerHTML = totalChars;

        if (totalChars >= headlineMaxValue || totalChars < headlineMinValue) {
            headlineValidationSpan.parentElement.classList.add("text-red");
        } else {
            headlineValidationSpan.parentElement.classList.remove("text-red");
        }

        if (totalChars >= headlineMinValue && totalChars < headlineMaxValue) {
            headlineValidationSpan.parentElement.classList.add("text-green");
        } else {
            headlineValidationSpan.parentElement.classList.remove("text-green");
        }
    }
    // Adding eventlisteners to the input fields
    headlineInput.addEventListener("keyup", headlineChangeHandler);
    headlineInput.addEventListener("keydown", headlineChangeHandler);
    contentInput.addEventListener("keyup", contentChangeHandler);
    contentInput.addEventListener("keydown", contentChangeHandler);


})();



