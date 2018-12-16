using System;

namespace Matcha
{
    /// <summary>
    /// Defines flags for various options that can be passed to <see cref="WildcardPattern"/>
    /// </summary>
    [Flags]
    public enum WildcardOptions
    {
        /// <summary>
        /// Defaults all the way
        /// </summary>
        None = 0,

        /// <summary>
        /// Flags that the casing must be ignored
        /// </summary>
        IgnoreCase = 1,

        /// <summary>
        /// Flags that matching is culture-invariant
        /// </summary>
        CultureInvariant = 2,
    }
}