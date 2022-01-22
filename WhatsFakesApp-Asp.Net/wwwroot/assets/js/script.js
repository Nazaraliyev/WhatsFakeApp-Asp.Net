$(document).ready(() => {
    Adjust();
    //inputFocus();

    $(window).on("resize", () => {
        Adjust();
    });



    var inputs = document.getElementsByClassName("my-form-input");
    var labels = document.getElementsByClassName("my-form-label");
    for (let i = 0; i <= inputs.length; i++) {
        $(inputs[i]).focus(() => {
            for (let j = 0; j <= labels.length; j++) {
                if (inputs[i].dataset.index == labels[j].dataset.index) {
                    $(labels[j]).css({
                        "bottom": "35px",
                        "font-size": "12px"
                    })
                }
            }
        })
    }

    for (let i = 0; i <= inputs.length; i++) {
        $(inputs[i]).blur(() => {
            for (let j = 0; j <= labels.length; j++) {
                if (inputs[i].dataset.index == labels[j].dataset.index) {
                    if (inputs[i].value == "") {
                        $(labels[j]).css({
                            "bottom": "5px",
                            "font-size": "14px"
                        })
                    }
                }
            }
        })
    }



});

const inputFocus = () => {
    var inputs = document.getElementsByClassName("my-form-input");
    var labels = document.getElementsByClassName("my-form-label");
    for (let i = 0; i <= inputs.length; i++) {
        for (let j = 0; j <= labels.length; j++) {
            if (inputs[i].dataset.index == labels[j].dataset.index) {
                if (inputs[i].value != "") {
                    $(labels[j]).css({
                        "bottom": "35px",
                        "font-size": "12px"
                    })
                }
            }
        }
    }
}

const Adjust = () => {
    //Menu
    var myContainerHeight = $("#my-container").outerHeight();
    console.log(myContainerHeight);

    var chatHeadHeight = $("#menu .chat-header").outerHeight() + $("#search-section").outerHeight();
    console.log(chatHeadHeight);
    $("#chat-list").css("height", myContainerHeight - chatHeadHeight + "px");


    // Chat
    var chatMessagesOutHeight = $("#chat-profile-info-wrapper").outerHeight() + $("#message-input-wrapper").outerHeight();
    //console.log(chatMessagesOutHeight);



    $("#chat-messages-container").css("height", myContainerHeight - chatMessagesOutHeight);
};
