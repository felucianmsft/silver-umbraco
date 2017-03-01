using System;

namespace Umbraco.Core
{
    /// <summary>
    /// Represents a string-based entity identifier.
    /// </summary>
    public class StringUdi : Udi
    {
        /// <summary>
        /// The string part of the identifier.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the StringUdi class with an entity type and a string id.
        /// </summary>
        /// <param name="entityType">The entity type part of the udi.</param>
        /// <param name="id">The string id part of the udi.</param>
        public StringUdi(string entityType, string id)
            : base(entityType, "umb://" + entityType + "/" + id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the StringUdi class with a uri value.
        /// </summary>
        /// <param name="uriValue">The uri value of the udi.</param>
        public StringUdi(Uri uriValue)
            : base(uriValue)
        {
            Id = uriValue.AbsolutePath.TrimStart('/');
        }

        /// <summary>
        /// Converts the string representation of an entity identifier into the equivalent StringUdi instance.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>A StringUdi instance that contains the value that was parsed.</returns>
        public new static StringUdi Parse(string s)
        {
            var udi = Udi.Parse(s);
            if (!(udi is StringUdi))
                throw new FormatException("String \"" + s + "\" is not a string entity id.");
            return (StringUdi)udi;
        }

        public static bool TryParse(string s, out StringUdi udi)
        {
            udi = null;
            Udi tmp;
            if (!TryParse(s, out tmp) || !(tmp is StringUdi)) return false;
            udi = (StringUdi)tmp;
            return true;
        }

        /// <inheritdoc/>
        public override bool IsRoot
        {
            get { return Id == string.Empty; }
        }

        /// <inheritdoc/>
        public StringUdi EnsureClosed()
        {
            base.EnsureNotRoot();
            return this;
        }
    }
}