﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Partnerinfo.Utilities
{
    /// <summary>
    /// Provides methods for computing hash values.
    /// </summary>
    internal static class Hash
    {
        /// <summary>
        /// Computes a new hash values combining the specified two ones.
        /// </summary>
        /// <param name="hash1">The hash1 to compute.</param>
        /// <param name="hash2">The hash2 to compute.</param>
        /// <returns>
        /// The computed hash value.
        /// </returns>
        /// <remarks>
        /// http://referencesource.microsoft.com/#System.Web/Util/HashCodeCombiner.cs
        /// </remarks>
        public static int Combine(int hash1, int hash2) => ((hash1 << 5) + hash1) ^ hash2;

        /// <summary>
        /// Computes a new hash values combining an array of hash values of the specified items.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="values">The values to combine.</param>
        /// <returns>
        /// The computed hash value.
        /// </returns>
        internal static int CombineAll<T>(IList<T> values)
        {
            if (values == null)
            {
                return 0;
            }

            var hashCode = 0;
            for (var i = 0; i < values.Count; ++i)
            {
                T value = values[i];
                if (value != null)
                {
                    hashCode = Combine(value.GetHashCode(), hashCode);
                }
            }
            return hashCode;
        }

        /// <summary>
        /// Computes a new hash values combining a sequence of hash values of the specified items.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="values">The values to combine.</param>
        /// <returns>
        /// The computed hash value.
        /// </returns>
        internal static int CombineAll<T>(IEnumerable<T> values)
        {
            if (values == null)
            {
                return 0;
            }

            var hashCode = 0;
            foreach (var value in values)
            {
                if (value != null)
                {
                    hashCode = Combine(value.GetHashCode(), hashCode);
                }
            }
            return hashCode;
        }

        /// <summary>
        /// Computes a new hash values combining a sequence of hash values of the specified strings.
        /// </summary>
        /// <param name="values">The values to combine.</param>
        /// <param name="stringComparer">A string comparison operation that uses specific case and culture-based or ordinal comparison rules.</param>
        /// <returns>
        /// The computed hash value.
        /// </returns>
        internal static int CombineAll(IEnumerable<string> values, StringComparer stringComparer)
        {
            if (values == null)
            {
                return 0;
            }

            var hashCode = 0;
            foreach (var value in values)
            {
                if (value != null)
                {
                    hashCode = Combine(stringComparer.GetHashCode(value), hashCode);
                }
            }
            return hashCode;
        }
    }
}
