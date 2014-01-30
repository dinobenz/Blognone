
namespace Dinobenz.Blognone
{
    /// <summary>
    /// The channel class.
    /// </summary>
    public class Channel
    {
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
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public Item[] Items { get; set; }
    }
}
