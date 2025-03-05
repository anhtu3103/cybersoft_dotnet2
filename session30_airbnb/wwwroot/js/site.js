window.scrollToTop = () => {
    window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
};

function showFeedbackModal(feedbackModel) {
    console.log(feedbackModel);
    let userNameFromModel = feedbackModel.username;
    let userName = document.getElementById('user-name');
    userName.innerHTML = userNameFromModel;
    var feedbackModal = new bootstrap.Modal(document.getElementById('feedbackModal'));
    feedbackModal.show();
}

