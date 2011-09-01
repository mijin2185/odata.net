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
using Microsoft.Data.Edm.Annotations;
using Microsoft.Data.Edm.Csdl.Internal.Parsing.Ast;
using Microsoft.Data.Edm.Expressions;
using Microsoft.Data.Edm.Internal;
using Microsoft.Data.Edm.Library;

namespace Microsoft.Data.Edm.Csdl.Internal.CsdlSemantics
{
    /// <summary>
    /// Provides semantics for a CsdlPropertyValue used in a type annotation.
    /// </summary>
    internal class CsdlSemanticsPropertyValueBinding : CsdlSemanticsElement, IEdmPropertyValueBinding
    {
        private readonly CsdlPropertyValue property;
        private readonly CsdlSemanticsTypeAnnotation context;

        private readonly Cache<CsdlSemanticsPropertyValueBinding, IEdmExpression> valueCache = new Cache<CsdlSemanticsPropertyValueBinding, IEdmExpression>();
        private readonly static Func<CsdlSemanticsPropertyValueBinding, IEdmExpression> s_computeValue = (me) => me.ComputeValue();

        private readonly Cache<CsdlSemanticsPropertyValueBinding, IEdmProperty> boundPropertyCache = new Cache<CsdlSemanticsPropertyValueBinding, IEdmProperty>();
        private readonly static Func<CsdlSemanticsPropertyValueBinding, IEdmProperty> s_computeBoundProperty = (me) => me.ComputeBoundProperty();

        public CsdlSemanticsPropertyValueBinding(CsdlSemanticsTypeAnnotation context, CsdlPropertyValue property)
        {
            this.context = context;
            this.property = property;
        }

        public IEdmProperty BoundProperty
        {
            get { return this.boundPropertyCache.GetValue(this, s_computeBoundProperty, null); }
        }

        public IEdmExpression Value
        {
            get { return this.valueCache.GetValue(this, s_computeValue, null); }
        }

        public override CsdlSemanticsModel Model
        {
            get { return this.context.Model; }
        }

        public override CsdlElement Element
        {
            get { return this.property; }
        }

        private IEdmProperty ComputeBoundProperty()
        {
            IEdmProperty boundProperty = this.context.TypeTerm().FindProperty(this.property.Property);
            return boundProperty ?? new UnresolvedProperty(this.context.TypeTerm(), this.property.Property, this.Location);
        }

        private IEdmExpression ComputeValue()
        {
            return CsdlSemanticsModel.WrapExpression(this.property.Expression, this.context.TargetBindingContext, this.context.Schema);
        }
    }
}
