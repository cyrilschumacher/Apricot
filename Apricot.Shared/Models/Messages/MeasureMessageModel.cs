namespace Apricot.Shared.Models.Messages
{
    /// <summary>
    ///     Model for send a message containing the measures and its name.
    /// </summary>
    public class MeasureMessageModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a plant identifier.
        /// </summary>
        public int PlantIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets a name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        #endregion Properties.
    }
}
