using Data;
using Data.Implementations;
using Service.Contracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.TestData;
using Xunit;

namespace Test.UnitTest.Services
{
    public class PostServiceTest : TestBase
    {
        [Fact]
        public void GetAll_ShouldReturnAllPost()
        {
            using (var context = GetSampleData(nameof(GetAll_ShouldReturnAllPost)))
            {
                //Arrange
                var postService = MockPostService(context);

                //Act
                var allCompanies = postService.GetAllPosts();

                //Assert
                Assert.NotNull(allCompanies);
                Assert.Equal(2, allCompanies.Count());
            }
        }

        [Fact]
        public void CreateNewPost_ShouldCreateNewPostData()
        {
            using (var context = GetSampleData(nameof(CreateNewPost_ShouldCreateNewPostData)))
            {
                //Arrange 
                var postService = MockPostService(context);
                var dataFactory = new DataFactory();
                var Post = dataFactory.GetPost(4, "post1", "postcontent1", "postdescription1", "posttags", "posturi","1235");

                //Act
                postService.CreatePost(Post);

                //Assert
                Assert.Equal(4, Post.ID);
            }
        }

        [Fact]
        public void UpdatePost_ShouldUpdatePost()
        {
            using(var context = GetSampleData(nameof(CreateNewPost_ShouldCreateNewPostData)))
            {
                //Arrange
                var postService = MockPostService(context);
                var dataFactory = new DataFactory();
                var post = dataFactory.GetPost(4, "post33", "postcontent1", "postdescription1", "posttags", "posturi", "123");

                //Act
                postService.UpdatePost(post);

                //Assert
                Assert.Equal("post33", post.Title);

            }
        }

        #region helpers
        private IPostService MockPostService(ApplicationDbContext context)
        {
            var _unitOfWork = new UnitOfWork(context);

            var postService = new PostService(_unitOfWork);

            return postService;
        }
        #endregion
    }
}
