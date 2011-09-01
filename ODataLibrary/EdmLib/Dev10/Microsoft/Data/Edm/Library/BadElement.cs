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
using System.Linq;
using Microsoft.Data.Edm.Annotations;
using Microsoft.Data.Edm.Validation;

namespace Microsoft.Data.Edm.Library
{
    /// <summary>
    /// Represents an invalid EDM element.
    /// </summary>
    internal class BadElement : IEdmElement, IEdmCheckable
    {
        private readonly IEnumerable<EdmError> errors;

        public BadElement(IEnumerable<EdmError> errors)
        {
            this.errors = errors;
        }

        public IEnumerable<EdmError> Errors
        {
            get { return this.errors; }
        }

        IEnumerable<IEdmAnnotation> IEdmAnnotatable.Annotations
        {
            get { return Enumerable.Empty<IEdmAnnotation>(); }
        }

        object IEdmAnnotatable.GetAnnotation(string namespaceName, string localName)
        {
            return null;
        }

        void IEdmAnnotatable.SetAnnotation(string namespaceName, string localName, object value)
        {
        }
    }
}
