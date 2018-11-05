document.addEventListener("DOMContentLoaded", (event) => {
    refreshComments();
    const saveComment = document.querySelector("#save-tag");
    saveComment.addEventListener("click", createTag);
});

function createTag() {
    const tagInput = document.querySelector("#new-tag");
    const newTagText = tagInput.value;
    const newTag = {
        text: newTagText,
        reviewId: reviewId
    };
    fetch('/api/tags', {
        method: 'POST',
        body: JSON.stringify(newTag),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(() => {
        tagInput.value = "";
        refreshTags();
    });
}

function refreshTags() {
    const ol = document.querySelector("#tag-list");
    ol.innerHTML = "";

    fetch(`/api/tags/${reviewId}`)
        .then(res => res.json())
        .then(data => {
            data.forEach(c => addTagToDom(c));
        });
}

function addTagToDom(tag) {
    console.log(tag);
    const li = document.createElement('li');
    const date = new Date(tag.createdAt);
    li.innerHTML = `${tag.text} <div class="tag-date">${date.toDateString()}</div>`;
    const ol = document.querySelector("#tag-list");
    ol.appendChild(li);
}