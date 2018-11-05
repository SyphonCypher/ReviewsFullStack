// Heres a similar project:  https://github.com/kmckee/todos-spa/tree/master/Todos
// Here's the JS:  https://github.com/kmckee/todos-spa/blob/master/Todos/wwwroot/comments.js

// After the DOM loads, you need to populate a list of all tags on the ReviewDetails page
//  fetch => TagApi controller's Get => JSON array of Tags => Put those inside the UL in your dom.

// Wire up the ability to create a new tag to the button onclick (and get the text out of text input).
// onclick => get the new tag title out of text input => fetch POST => Tag API controller => create it in the DB => refresh list of tags in the UI

document.addEventListener("DOMContentLoaded", (event) => {
    refreshComments();
    const saveComment = document.querySelector("#save-comment");
    saveComment.addEventListener("click", createComment);
});

function createComment() {
    const commentInput = document.querySelector("#new-comment");
    const newCommentText = commentInput.value;
    const newComment = {
        text: newCommentText,
        reviewId: reviewId
    };
    fetch('/api/comments', {
        method: 'POST',
        body: JSON.stringify(newComment),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(() => {
        commentInput.value = "";
        refreshComments();
    });
}

function refreshComments() {
    const ol = document.querySelector("#comments");
    ol.innerHTML = "";

    fetch(`/api/comments/${reviewId}`)
        .then(res => res.json())
        .then(data => {
            data.forEach(c => addCommentToDom(c));
        });
}

function addCommentToDom(comment) {
    console.log(comment);
    const li = document.createElement('li');
    const date = new Date(comment.createdAt);
    li.innerHTML = `${comment.text} <div class="comment-date">${date.toDateString()}</div>`;
    const ol = document.querySelector("#comments");
    ol.appendChild(li);
}