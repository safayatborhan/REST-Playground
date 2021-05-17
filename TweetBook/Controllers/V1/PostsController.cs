using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Request;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Domain;

namespace TweetBook.Controllers.V1
{
    public class PostsController : Controller
    {
        private List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        /// <summary>
        /// Created adds location in response header. In that case it needs to be added specifically when we use return Created.
        /// Requests and responses all should be versioned properly. That why we have different folder structures. 
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = postRequest.Id
            };

            if (string.IsNullOrEmpty(post.Id))
                post.Id = Guid.NewGuid().ToString();
            
            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id);

            var response = new PostResponse
            {
                Id = post.Id
            };

            return Created(locationUri, response);
        }
    }
}
