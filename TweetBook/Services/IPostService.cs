using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> CreatePostAsync(Post post);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);

        Task<bool> UserOwnPostAsync(Guid postId, string userId);
    }
}
