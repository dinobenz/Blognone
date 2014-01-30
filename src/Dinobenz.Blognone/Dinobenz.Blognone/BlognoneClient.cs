using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Xml;

namespace Dinobenz.Blognone
{
    /// <summary>
    /// The blognone client class.
    /// </summary>
    public class BlognoneClient
    {
        #region Properties

        /// <summary>
        /// Gets or sets the feed uri.
        /// </summary>
        public string FeedUri { get; private set; }

        /// <summary>
        /// Gets or sets the comment uri.
        /// </summary>
        public string CommentUri { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialized the object.
        /// </summary>
        public BlognoneClient()
        {
            this.FeedUri = ConfigurationManager.AppSettings["feed_uri"];
            this.CommentUri = ConfigurationManager.AppSettings["comment_uri"];
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the feed.
        /// </summary>
        /// <returns>The channel</returns>
        public Channel Get()
        {
            byte[] buffer = null;
            string xml = string.Empty;
            Channel channel = null;
            List<Item> items = null;
            List<Category> categories = null;

            // download feed
            using (WebClient webClient = new WebClient())
            {
                buffer = webClient.DownloadData(this.FeedUri);
                xml = Encoding.UTF8.GetString(buffer);
                webClient.Dispose();
            }

            // mapping data
            if (!string.IsNullOrEmpty(xml))
            {
                // load xml
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);

                // channel
                channel = new Channel();
                channel.Title = xmlDocument.SelectSingleNode("/rss/channel/title").InnerText;
                channel.Link = xmlDocument.SelectSingleNode("/rss/channel/link").InnerText;
                channel.Description = xmlDocument.SelectSingleNode("/rss/channel/description").InnerText;
                channel.Language = xmlDocument.SelectSingleNode("/rss/channel/language").InnerText;

                // items
                XmlNodeList nodes = xmlDocument.SelectNodes("/rss/channel/item");
                if (nodes.Count > 0)
                {
                    items = new List<Item>();

                    for (int i = 0; i < nodes.Count; i++)
                    {
                        // item
                        Item item = new Item();
                        item.Title = nodes[i].SelectSingleNode("title").InnerText;
                        item.Link = nodes[i].SelectSingleNode("link").InnerText;
                        item.Description = nodes[i].SelectSingleNode("description").InnerText;
                        item.Comments = nodes[i].SelectSingleNode("comments").InnerText;
                        item.PublishDate = Convert.ToDateTime(nodes[i].SelectSingleNode("pubDate").InnerText);

                        // find link id
                        Uri uri = new Uri(item.Link);
                        item.ID = Convert.ToInt32(uri.Segments[uri.Segments.Length - 1]);

                        // add namespace
                        XmlNamespaceManager namespaces = new XmlNamespaceManager(xmlDocument.NameTable);
                        namespaces.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

                        item.Creator = nodes[i].SelectSingleNode("dc:creator", namespaces).InnerText;

                        // categories
                        XmlNodeList nodes2 = nodes[i].SelectNodes("category");
                        if (nodes2.Count > 0)
                        {
                            categories = new List<Category>();

                            for (int j = 0; j < nodes2.Count; j++)
                            {
                                // category
                                Category category = new Category();
                                category.Domain = nodes2[j].Attributes["domain"].InnerText;
                                category.Name = nodes2[j].InnerText;
                                categories.Add(category);
                            }
                        }

                        item.Categories = categories.Count > 0 ? categories.ToArray() : null;
                        items.Add(item);
                    }
                }

                channel.Items = items.Count > 0 ? items.ToArray() : null;
            }

            return channel;
        }

        #endregion
    }
}
