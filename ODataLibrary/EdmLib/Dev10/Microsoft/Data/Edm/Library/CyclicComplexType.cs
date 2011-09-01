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

using Microsoft.Data.Edm.Validation;

namespace Microsoft.Data.Edm.Library
{
    /// <summary>
    /// Represents an EDM complex type that cannot be determined due to a cyclic reference.
    /// </summary>
    internal class CyclicComplexType : BadComplexType
    {
        public CyclicComplexType(string qualifiedName, EdmLocation location)
            : base(qualifiedName, new EdmError[] { new EdmError(location, EdmErrorCode.BadCyclicComplex, Edm.Strings.Bad_CyclicComplex(qualifiedName)) })
        {
        }
    }
}
