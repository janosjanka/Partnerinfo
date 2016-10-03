﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Partnerinfo
{
    /// <summary>
    /// A static factory class to create new instances of the generic <see cref="OperationListResult{T}" /> class
    /// using type inference or deduction on methods. These factory methods also enable us to cache
    /// immutable instances decreasing GC pressure.
    /// </summary>
    public static class OperationListResult
    {
        /// <summary>
        /// Creates a new instance of the <see cref="OperationListResult{T}" /> class or returns a cached version of the immutable object.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <returns>
        /// The <see cref="OperationListResult{T}" />.
        /// </returns>
        public static OperationListResult<T> Create<T>() => OperationListResult<T>.Empty;

        /// <summary>
        /// Creates a new instance of the <see cref="OperationListResult{T}" /> class or returns a cached version of the immutable object.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="data">The strongly typed list of results to return.</param>
        /// <returns>
        /// The <see cref="OperationListResult{T}" />.
        /// </returns>
        public static OperationListResult<T> Create<T>(ImmutableArray<T> data)
        {
            if (data.IsDefaultOrEmpty)
            {
                return OperationListResult<T>.Empty;
            }

            return new OperationListResult<T>(data, data.Length);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OperationListResult{T}" /> class or returns a cached version of the immutable object.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="data">The strongly typed list of results to return.</param>
        /// <param name="total">The total.</param>
        /// <returns>
        /// The <see cref="OperationListResult{T}" />.
        /// </returns>
        public static OperationListResult<T> Create<T>(ImmutableArray<T> data, int total)
        {
            if (data.IsDefaultOrEmpty && total == 0)
            {
                return OperationListResult<T>.Empty;
            }

            return new OperationListResult<T>(data, total);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OperationListResult{T}" /> class or returns a cached version of the immutable object.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="data">The strongly typed list of results to return.</param>
        /// <returns>
        /// The <see cref="OperationListResult{T}" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">data</exception>
        public static OperationListResult<T> Create<T>(IEnumerable<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return Create(data.ToImmutableArray());
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OperationListResult{T}" /> class or returns a cached version of the immutable object.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="data">The strongly typed list of results to return.</param>
        /// <param name="total">The total.</param>
        /// <returns>
        /// The <see cref="OperationListResult{T}" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">data</exception>
        public static OperationListResult<T> Create<T>(IEnumerable<T> data, int total)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return Create(data.ToImmutableArray(), total);
        }
    }
}
