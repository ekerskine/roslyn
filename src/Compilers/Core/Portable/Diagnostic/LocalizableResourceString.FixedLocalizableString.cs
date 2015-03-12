﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;

namespace Microsoft.CodeAnalysis
{
    public abstract partial class LocalizableString
    {
        private sealed class FixedLocalizableString : LocalizableString
        {
            /// <summary>
            /// FixedLocalizableString representing an empty string.
            /// </summary>
            private static readonly FixedLocalizableString Empty = new FixedLocalizableString(string.Empty);

            private readonly string _fixedString;

            public static FixedLocalizableString Create(string fixedResource)
            {
                if (string.IsNullOrEmpty(fixedResource))
                {
                    return Empty;
                }

                return new FixedLocalizableString(fixedResource);
            }

            private FixedLocalizableString(string fixedResource)
            {
                _fixedString = fixedResource;
            }

            public override string ToString(IFormatProvider formatProvider)
            {
                return _fixedString;
            }

            public override bool Equals(LocalizableString other)
            {
                var fixedStr = other as FixedLocalizableString;
                return fixedStr != null && string.Equals(_fixedString, fixedStr.ToString());
            }

            public override int GetHashCode()
            {
                return _fixedString?.GetHashCode() ?? 0;
            }
        }
    }
}
