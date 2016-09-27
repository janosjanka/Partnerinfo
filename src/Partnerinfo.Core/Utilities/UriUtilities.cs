﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text;

namespace Partnerinfo.Utilities
{
    internal static class UriUtilities
    {
        /// <summary>
        /// Returns a normalized representation of the specified <paramref name="uriPart" />.
        /// </summary>
        /// <param name="uriPart">The uri to normalize.</param>
        /// <returns>
        /// A normalized representation of the specified <paramref name="uriPart" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">uriPart</exception>
        public static string Normalize(string uriPart)
        {
            if (uriPart == null)
            {
                throw new ArgumentNullException(nameof(uriPart));
            }

            // Remove all leading and trailing white-space characters and normalize 
            // the given URI part using full compatibility decomposition (FormKD).
            string normalizedUri = uriPart
                .Trim()
                .Normalize(NormalizationForm.FormKD)
                .ToLower();

            // Remove both non-standard and non-friendly URI characters. E.g.
            // "Janka  János Zoltán   " => "janka-janos-zoltan"
            // "  janka-jános   Zoltán" => "janka-janos-zoltan"
            // " 0123456789-ok.4555HA~" => "0123456789-ok.4555ha~"
            var uriPartSep = true;
            var uriBuilder = new StringBuilder(normalizedUri.Length);
            for (var i = 0; i < normalizedUri.Length; ++i)
            {
                char ch = normalizedUri[i];
                if (ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9' ||
                    ch == '-' || ch == '.' || ch == '_' || ch == '~')
                {
                    uriBuilder.Append(ch);
                    uriPartSep = false;
                }
                else if (!uriPartSep && char.IsWhiteSpace(ch))
                {
                    uriBuilder.Append('-');
                    uriPartSep = true;
                }
            }
            return uriBuilder.ToString();
        }
    }
}