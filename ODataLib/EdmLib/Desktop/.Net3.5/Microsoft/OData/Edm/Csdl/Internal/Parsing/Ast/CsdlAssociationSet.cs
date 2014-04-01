//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Edm.Csdl.Internal.Parsing.Ast
{
    /// <summary>
    /// Represents a CSDL association set.
    /// </summary>
    internal class CsdlAssociationSet : CsdlNamedElement
    {
        private readonly string association;
        private readonly CsdlAssociationSetEnd end1;
        private readonly CsdlAssociationSetEnd end2;

        public CsdlAssociationSet(string name, string association, CsdlAssociationSetEnd end1, CsdlAssociationSetEnd end2, CsdlDocumentation documentation, CsdlLocation location)
            : base(name, documentation, location)
        {
            this.association = association;
            this.end1 = end1;
            this.end2 = end2;
        }

        public string Association
        {
            get { return this.association; }
        }

        public CsdlAssociationSetEnd End1
        {
            get { return this.end1; }
        }

        public CsdlAssociationSetEnd End2
        {
            get { return this.end2; }
        }
    }
}