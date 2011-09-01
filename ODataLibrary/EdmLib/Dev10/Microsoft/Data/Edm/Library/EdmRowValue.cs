//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System.Collections.Generic;

namespace Microsoft.Data.Edm.Library
{
    /// <summary>
    /// Represents an EDM row value.
    /// </summary>
    public class EdmRowValue : EdmStructuredValue, IEdmRowValue
    {
        /// <summary>
        /// Initializes a new instance of the EdmRowValue class.
        /// </summary>
        /// <param name="type">Row type that describes this value.</param>
        /// <param name="propertyValues">Collection of child values.</param>
        public EdmRowValue(IEdmRowTypeReference type, IEnumerable<IEdmPropertyValue> propertyValues)
            : base(type, propertyValues)
        {
        }
    }
}
