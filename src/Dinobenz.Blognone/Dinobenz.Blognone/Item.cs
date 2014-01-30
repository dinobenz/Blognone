using System;

namespace Dinobenz.Blognone
{
    /// <summary>
    /// The item class.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public Category[] Categories { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        public string Creator { get; set; }
    }
}
