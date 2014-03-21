using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dinobenz.Blognone.Tests
{
    /// <summary>
    /// The blognone client test class.
    /// </summary>
    [TestClass]
    public class BlognoneClientTest
    {
        /// <summary>
        /// The blognone client.
        /// </summary>
        private BlognoneClient client;

        /// <summary>
        /// Initialize test method.
        /// </summary>
        [TestInitialize]
        public void MyInitialize()
        {
            this.client = new BlognoneClient();
        }

        /// <summary>
        /// Cleanup test method.
        /// </summary>
        [TestCleanup]
        public void MyCleanup()
        {
            this.client = null;
        }

        /// <summary>
        /// Feed Uri is not null.
        /// </summary>
        [TestMethod]
        public void FeedUri_Is_Not_Null()
        {
            Assert.IsNotNull(this.client.FeedUri);
        }

        /// <summary>
        /// Comment Uri is not null.
        /// </summary>
        [TestMethod]
        public void CommentUri_Is_Not_Null()
        {
            Assert.IsNotNull(this.client.CommentUri);
        }

        /// <summary>
        /// Get content feed.
        /// </summary>
        [TestMethod]
        public void Get_Content_Feed()
        {
            Channel channel = this.client.GetContent();

            Assert.IsNotNull(channel);
            
            Assert.IsNotNull(channel.Title);
            Assert.IsNotNull(channel.Link);
            Assert.IsNotNull(channel.Description);
            Assert.IsNotNull(channel.Language);

            Assert.IsNotNull(channel.Items);
            foreach (var item in channel.Items)
            {
                Assert.IsNotNull(item.ID);
                Assert.IsNotNull(item.Title);
                Assert.IsNotNull(item.Link);
                Assert.IsNotNull(item.Description);
                Assert.IsNotNull(item.Comments);
                Assert.IsNotNull(item.PublishDate);
                Assert.IsNotNull(item.Creator);
                Assert.IsNotNull(item.Categories);
                foreach (var category in item.Categories)
                {
                    Assert.IsNotNull(category.Domain);
                    Assert.IsNotNull(category.Name);
                }
            }
        }

        /// <summary>
        /// Get commend feed.
        /// </summary>
        [TestMethod]
        public void Get_Commend_Feed()
        {
            Channel channel = this.client.GetComment();

            Assert.IsNotNull(channel);

            Assert.IsNotNull(channel.Title);
            Assert.IsNotNull(channel.Link);
            Assert.IsNotNull(channel.Description);
            Assert.IsNotNull(channel.Language);

            Assert.IsNotNull(channel.Items);
            foreach (var item in channel.Items)
            {
                Assert.IsNotNull(item.ID);
                Assert.IsNotNull(item.Title);
                Assert.IsNotNull(item.Link);
                Assert.IsNotNull(item.Description);
                Assert.IsNotNull(item.PublishDate);
                Assert.IsNotNull(item.Creator);
            }
        }
    }
}
