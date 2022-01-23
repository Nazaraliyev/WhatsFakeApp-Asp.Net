$(document).ready(() => {
    Adjust();
    //inputFocus();
    $(window).on("resize", () => {
        Adjust();
    });

    


    Message();

    document.getElementById("send-message-btn").addEventListener("click", Message);



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

const Adjust = () => {
    //Menu
    var myContainerHeight = $("#my-container").outerHeight();

    var chatHeadHeight = $("#menu .chat-header").outerHeight() + $("#search-section").outerHeight();
    $("#chat-list").css("height", myContainerHeight - chatHeadHeight + "px");

    // Chat
    var chatMessagesOutHeight = $("#chat-profile-info-wrapper").outerHeight() + $("#message-input-wrapper").outerHeight();
    $("#chat-messages-container").css("height", myContainerHeight - chatMessagesOutHeight);
    $("#chat-home").css("height", myContainerHeight);
};


const Message = () => {
    var container = $("#chat-messages-container").outerHeight();
    var time = document.getElementsByClassName("chat-time");
    var msg = document.getElementsByClassName("msg");
    var msgsHeight = 0;
    for (var i = 0; i < msg.length; i++) {
        msgsHeight += ($(msg[i]).outerHeight() + 10);
        if ((msgsHeight + $(time[0]).outerHeight()) >= container) {
            document.getElementById("chat-messages-container").classList.remove("justify-content-end");
            console.log("icerde");
            return;
        }
    }

    console.log("colde")
}
