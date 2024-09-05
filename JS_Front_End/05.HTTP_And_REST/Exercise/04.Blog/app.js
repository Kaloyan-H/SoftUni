function attachEvents() {
    const btnLoadPosts = document.querySelector("#btnLoadPosts");
    const btnViewPost = document.querySelector("#btnViewPost");
    const select = document.querySelector("#posts");
    const blogTitle = document.querySelector("#post-title");
    const postBody = document.querySelector("#post-body");
    const postUl = document.querySelector("#post-comments");

    const POSTS_URL = "http://localhost:3030/jsonstore/blog/posts";
    const COMMENTS_URL = "http://localhost:3030/jsonstore/blog/comments";

    let postsInfo = {};

    btnLoadPosts.addEventListener("click", async () => {
        const loadPostsResponse = await fetch(POSTS_URL);
        const loadPostsData = await loadPostsResponse.json();
        postsInfo = loadPostsData;

        for (const key in loadPostsData) {
            const option = document.createElement("option");
            option.value = loadPostsData[key]["id"];
            option.textContent = loadPostsData[key]["title"];

            select.appendChild(option);
        }
    });

    btnViewPost.addEventListener("click", async () => {
        const viewPostResponse = await fetch(COMMENTS_URL);
        const viewPostData = await viewPostResponse.json();

        const post = findPost(select.value);
        blogTitle.textContent = post.title;
        postBody.textContent = post.body;

        for (const child of Array.from(postUl.children)) {
            child.remove();
        }

        for (const key in viewPostData) {
            if (viewPostData[key]["postId"] === select.value) {
                const li = document.createElement("li");
                li.textContent = viewPostData[key]["text"];
                postUl.appendChild(li);
            }
        }
    });

    function findPost(postId) {
        for (const key in postsInfo) {
            if (postId === postsInfo[key]["id"]) {
                return postsInfo[key];
            }
        }
    }
}

attachEvents();

// let posts;

// function attachEvents() {
//     const loadPostsButton = document.querySelector("#btnLoadPosts");
//     loadPostsButton.addEventListener("click", onclickButtonLoadPosts);

//     const viewPostButton = document.querySelector("#btnViewPost");
//     viewPostButton.addEventListener("click", onclickButtonViewPost);
// }

// async function onclickButtonLoadPosts(e) {
//     const result = await (
//         await fetch("http://localhost:3030/jsonstore/blog/posts")
//     ).json();

//     posts = result;

//     const postsDropdown = document.querySelector("#posts");

//     Object.values(result).forEach((post) => {
//         const option = document.createElement("option");
//         option.value = post.id;
//         option.text = post.title.toUpperCase();

//         postsDropdown.appendChild(option);
//     });
// }

// async function onclickButtonViewPost(e) {
//     const selectedPost = posts[document.querySelector("#posts").value];

//     const postTitleH1 = document.querySelector("#post-title");
//     postTitleH1.textContent = selectedPost.title;

//     const postBodyParagraph = document.querySelector("#post-body");
//     postBodyParagraph.textContent = selectedPost.body;

//     const result = await (
//         await fetch("http://localhost:3030/jsonstore/blog/comments")
//     ).json();

//     const list = document.querySelector("#post-comments");
//     list.innerHTML = "";

//     Object.values(result)
//         .filter((comment) => comment.postId === selectedPost.id)
//         .forEach((comment) => {
//             const listItem = document.createElement("li");
//             listItem.id = comment.id;
//             listItem.textContent = comment.text;

//             list.appendChild(listItem);
//         });
// }
