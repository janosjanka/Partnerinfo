﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Partnerinfo
{
    /// <summary>
    /// Represents an immutable, thread-safe, and cachable Geo coordinate as DDD value object.
    /// </summary>
    public sealed class GeoCoordinate
    {
        /// <summary>
        /// Gets or sets the longitude geographic coordinate that specifies the east-west position of a point on the Earth's surface.
        /// </summary>
        /// <value>
        /// The longitude is a geographic coordinate that specifies the east-west position of a point on the Earth's surface.
        /// </value>
        public double? Longitude { get; private set; }

        /// <summary>
        /// Gets or sets the latitude geographic coordinate that specifies the north-south position of a point on the Earth's surface.
        /// </summary>
        /// <value>
        /// The latitude is a geographic coordinate that specifies the north-south position of a point on the Earth's surface.
        /// </value>
        public double? Latitude { get; private set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="GeoCoordinate" /> class from being created.
        /// </summary>
        /// <remarks>
        /// The parameterless constructor enables two-way serialization scenarios.
        /// </remarks>
        internal GeoCoordinate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoCoordinate" /> class.
        /// </summary>
        /// <param name="longitude">The longitude is a geographic coordinate that specifies the east-west position of a point on the Earth's surface.</param>
        /// <param name="latitude">The latitude is a geographic coordinate that specifies the north-south position of a point on the Earth's surface.</param>
        public GeoCoordinate(double? longitude, double? latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
