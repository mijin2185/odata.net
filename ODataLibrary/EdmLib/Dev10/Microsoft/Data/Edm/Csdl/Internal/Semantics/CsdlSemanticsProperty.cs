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

using System;
using System.Collections.Generic;
using Microsoft.Data.Edm.Annotations;
using Microsoft.Data.Edm.Csdl.Internal.Parsing.Ast;
using Microsoft.Data.Edm.Internal;

namespace Microsoft.Data.Edm.Csdl.Internal.CsdlSemantics
{
    /// <summary>
    /// Provides semantics for a CsdlProperty.
    /// </summary>
    internal class CsdlSemanticsProperty : CsdlSemanticsElement, IEdmStructuralProperty
    {
        protected CsdlProperty property;
        private readonly CsdlSemanticsStructuredTypeDefinition declaringType;

        private readonly Cache<CsdlSemanticsProperty, IEdmTypeReference> typeCache = new Cache<CsdlSemanticsProperty, IEdmTypeReference>();
        private readonly static Func<CsdlSemanticsProperty, IEdmTypeReference> s_computeType = (me) => me.ComputeType();

        public CsdlSemanticsProperty(CsdlSemanticsStructuredTypeDefinition declaringType, CsdlProperty property)
        {
            this.property = property;
            this.declaringType = declaringType;
        }

        public string Name
        {
            get { return this.property.Name; }
        }

        public IEdmStructuredType DeclaringType
        {
            get { return this.declaringType; }
        }

        public IEdmTypeReference Type
        {
            get { return this.typeCache.GetValue(this, s_computeType, null); }
        }

        public override CsdlSemanticsModel Model
        {
            get { return this.declaringType.Model; }
        }

        private IEdmTypeReference ComputeType()
        {
            return CsdlSemanticsModel.WrapTypeReference(this.declaringType.Context, this.property.Type);
        }

        protected override IEnumerable<IEdmAnnotation> ComputeImmutableAnnotations()
        {
            return this.declaringType.Context.Model.WrapPropertyAnnotations(this, this.declaringType.Context);
        }

        public string DefaultValue
        {
            get { return this.property.DefaultValue; }
        }

        public EdmConcurrencyMode ConcurrencyMode
        {
            get { return this.property.IsFixedConcurrency ? EdmConcurrencyMode.Fixed : EdmConcurrencyMode.None; }
        }

        public EdmPropertyKind PropertyKind
        {
            get { return EdmPropertyKind.Structural; }
        }

        public override CsdlElement Element
        {
            get { return this.property; }
        }
    }
}
