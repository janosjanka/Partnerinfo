﻿// Copyright (c) János Janka. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;

namespace Partnerinfo.Actions
{
    /// <summary>
    /// Represents an action with its metadata that can be used by Managed Extensibility Framework (MEF).
    /// </summary>
    /// <remarks>
    /// This library does not specify a dependency on Microsoft.Composition. You can use fluent API
    /// instead of [Export] attributes to configure your MEF plugins without having to add a reference
    /// to the MEF library in your activity libraries.
    /// </remarks>
    internal sealed class ActionActivityDescriptor
    {
        /// <summary>
        /// Gets the action activity.
        /// </summary>
        /// <value>
        /// The action activity.
        /// </value>
        internal IActionActivity Activity { get; }

        /// <summary>
        /// Gets the action activity metadata that belongs to the action.
        /// </summary>
        /// <value>
        /// The action activity metadata.
        /// </value>
        internal ActionActivityMetadata Metadata { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionActivityDescriptor" /> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="metadata">The metadata.</param>
        internal ActionActivityDescriptor(IActionActivity activity, ActionActivityMetadata metadata)
        {
            Debug.Assert(activity != null);
            Debug.Assert(metadata != null);

            Activity = activity;
            Metadata = metadata;
        }
    }
}
