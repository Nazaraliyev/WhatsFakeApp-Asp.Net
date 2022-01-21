$(document).ready(() => {
  Adjust();
  $(window).on("resize", () => {
    Adjust();
  });



    var inputs = document.getElementsByClassName("my-form-input");
  var labels = document.getElementsByClassName("my-form-label");
  for(let i =0; i<=inputs.length; i++){
    $(inputs[i]).focus(()=>{
      for(let j = 0; j <= labels.length; j++){
        if(inputs[i].dataset.index == labels[j].dataset.index){
          $(labels[j]).css({
            "bottom" : "35px",
            "font-size" : "12px"
          })
        }
      }
    })
  }

  for(let i =0; i<=inputs.length; i++){
    $(inputs[i]).blur(()=>{
      for(let j = 0; j <= labels.length; j++){
        if(inputs[i].dataset.index == labels[j].dataset.index){
          if(inputs[i].value == ""){
            $(labels[j]).css({
              "bottom" : "5px",
              "font-size" : "14px"
            })
          }
        }
      }
    })
  }


  console.log("sxlsxlm")

  
});

const Adjust = () => {
  //Menu
  var myContainerHeight = $("#my-container").outerHeight();
  var chatHeadHeight =$("#menu .chat-header").outerHeight()+$("#search-section").outerHeight();

  console.log(chatHeadHeight); 
  // Chat
  var chatMessagesOutHeight = $("#chat-profile-info-wrapper").outerHeight()+$("#message-input-wrapper").outerHeight();
  
  $("#chat-list").css("height", myContainerHeight-chatHeadHeight+"px");
  $("#chat-messages-container").css("height", myContainerHeight - chatMessagesOutHeight);
};
