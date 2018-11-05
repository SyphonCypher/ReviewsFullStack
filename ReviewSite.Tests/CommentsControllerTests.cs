using NSubstitute;
using ReviewsSite;
using ReviewsSite.Controllers.Api;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReviewSite.Tests
{
    public class CommentsControllerTests
    {
        [Fact]
        public void GetAll_Returns_All_Comments_For_Given_Review()
        {
            var todoId = 42;
            var expectedModel = new List<Comment>();
            var commentRepo = Substitute.For<ICommentRepository>();
            commentRepo.GetCommentsForTodoId(todoId).Returns(expectedModel);
            var underTest = new CommentsController(commentRepo);

            var model = underTest.Get(todoId);

            Assert.Same(expectedModel, model);
        }

        [Fact]
        public void Post_And_Saves()
        {
            var comment = new Comment();
            var commentRepo = Substitute.For<ICommentRepository>();
            var underTest = new CommentsController(commentRepo);

            underTest.Post(comment);

            commentRepo.Received().Create(comment);
        }
    }
}
