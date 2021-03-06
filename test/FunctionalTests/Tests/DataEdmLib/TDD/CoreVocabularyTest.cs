﻿//---------------------------------------------------------------------
// <copyright file="CoreVocabularyTest.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.Test.Edm.TDD.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Csdl;
    using Microsoft.OData.Edm.Library;
    using Microsoft.OData.Edm.Validation;
    using Microsoft.OData.Edm.Vocabularies.V1;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test core vocabulary
    /// </summary>
    [TestClass]
    public class CoreVocabularyTest
    {
        private readonly IEdmModel coreVocModel = CoreVocabularyModel.Instance;

        [TestMethod]
        public void TestBaseCoreVocabularyModel()
        {
            const string expectedText = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Schema Namespace=""Org.OData.Core.V1"" Alias=""Core"" xmlns=""http://docs.oasis-open.org/odata/ns/edm"">
  <TypeDefinition Name=""Tag"" UnderlyingType=""Edm.Boolean"">
    <Annotation Term=""Core.Description"" String=""This is the type to use for all tagging terms"" />
  </TypeDefinition>
  <ComplexType Name=""OptimisticConcurrencyControlType"">
    <Property Name=""ETagDependsOn"" Type=""Collection(Edm.PropertyPath)"">
      <Annotation Term=""Core.Description"" String=""The ETag is computed from these properties"" />
    </Property>
    <Annotation Term=""Core.Description"" String=""If present, the annotated entity set uses optimistic concurrency control"" />
  </ComplexType>
  <Term Name=""Description"" Type=""Edm.String"">
    <Annotation Term=""Core.Description"" String=""A brief description of a model element"" />
    <Annotation Term=""Core.IsLanguageDependent"" Bool=""true"" />
  </Term>
  <Term Name=""LongDescription"" Type=""Edm.String"">
    <Annotation Term=""Core.Description"" String=""A lengthy description of a model element"" />
    <Annotation Term=""Core.IsLanguageDependent"" Bool=""true"" />
  </Term>
  <Term Name=""IsLanguageDependent"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""Property Term"">
    <Annotation Term=""Core.Description"" String=""Properties and terms annotated with this term are language-dependent"" />
    <Annotation Term=""Core.RequiresType"" String=""Edm.String"" />
  </Term>
  <Term Name=""RequiresType"" Type=""Edm.String"" AppliesTo=""Term"">
    <Annotation Term=""Core.Description"" String=""Properties and terms annotated with this annotation MUST have a type that is identical to or derived from the given type name"" />
  </Term>
  <Term Name=""ResourcePath"" Type=""Edm.String"" AppliesTo=""EntitySet Singleton ActionImport FunctionImport"">
    <Annotation Term=""Core.Description"" String=""Resource path for entity container child, can be relative to xml:base and the request URL"" />
    <Annotation Term=""Core.IsUrl"" Bool=""true"" />
  </Term>
  <Term Name=""DereferenceableIDs"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""EntityContainer"">
    <Annotation Term=""Core.Description"" String=""Entity-ids are URLs that locate the identified entity"" />
  </Term>
  <Term Name=""ConventionalIDs"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""EntityContainer"">
    <Annotation Term=""Core.Description"" String=""Entity-ids follow OData URL conventions"" />
  </Term>
  <Term Name=""Immutable"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""Property"">
    <Annotation Term=""Core.Description"" String=""A value for this non-key property can be provided on insert and remains unchanged on update"" />
  </Term>
  <Term Name=""Computed"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""Property"">
    <Annotation Term=""Core.Description"" String=""A value for this property is generated on both insert and update"" />
  </Term>
  <Term Name=""IsURL"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""Property Term"">
    <Annotation Term=""Core.Description"" String=""Properties and terms annotated with this term MUST contain a valid URL"" />
    <Annotation Term=""Core.RequiresType"" String=""Edm.String"" />
  </Term>
  <Term Name=""AcceptableMediaTypes"" Type=""Collection(Edm.String)"" AppliesTo=""EntityType Property"">
    <Annotation Term=""Core.Description"" String=""Lists the MIME types acceptable for the annotated entity type marked with HasStream=&quot;true&quot; or the annotated stream property"" />
    <Annotation Term=""Core.IsMediaType"" Bool=""true"" />
  </Term>
  <Term Name=""MediaType"" Type=""Edm.String"" AppliesTo=""Property"">
    <Annotation Term=""Core.IsMediaType"" Bool=""true"" />
    <Annotation Term=""Core.RequiresType"" String=""Edm.Binary"" />
  </Term>
  <Term Name=""IsMediaType"" Type=""Core.Tag"" DefaultValue=""true"" AppliesTo=""Property Term"">
    <Annotation Term=""Core.Description"" String=""Properties and terms annotated with this term MUST contain a valid MIME type"" />
    <Annotation Term=""Core.RequiresType"" String=""Edm.String"" />
  </Term>
  <Term Name=""OptimisticConcurrencyControl"" Type=""Core.OptimisticConcurrencyControlType"" />
  <Term Name=""OptimisticConcurrency"" Type=""Collection(Edm.PropertyPath)"" AppliesTo=""EntitySet"">
    <Annotation Term=""Core.Description"" String=""Data modification requires the use of Etags. A non-empty collection contains the set of properties that are used to compute the ETag"" />
  </Term>
</Schema>";

            var s = coreVocModel.FindDeclaredValueTerm("Org.OData.Core.V1.OptimisticConcurrencyControl");
            Assert.IsNotNull(s);
            Assert.AreEqual("Org.OData.Core.V1", s.Namespace);
            Assert.AreEqual("OptimisticConcurrencyControl", s.Name);
            Assert.AreEqual(EdmTermKind.Value, s.TermKind);

            var type = s.Type;
            Assert.AreEqual("Org.OData.Core.V1.OptimisticConcurrencyControlType", type.FullName());
            Assert.AreEqual(EdmTypeKind.Complex, type.Definition.TypeKind);

            s = coreVocModel.FindDeclaredValueTerm("Org.OData.Core.V1.OptimisticConcurrency");
            Assert.IsNotNull(s);
            Assert.AreEqual("Org.OData.Core.V1", s.Namespace);
            Assert.AreEqual("OptimisticConcurrency", s.Name);
            Assert.AreEqual(EdmTermKind.Value, s.TermKind);

            type = s.Type;
            Assert.AreEqual("Collection(Edm.PropertyPath)", type.FullName());
            Assert.AreEqual(EdmTypeKind.Collection, type.Definition.TypeKind);

            var descriptionTerm = coreVocModel.FindValueTerm("Org.OData.Core.V1.Description");
            Assert.IsNotNull(descriptionTerm);
            var descriptionType = descriptionTerm.Type.Definition as IEdmPrimitiveType;
            Assert.IsNotNull(descriptionType);
            Assert.AreEqual(EdmPrimitiveTypeKind.String, descriptionType.PrimitiveKind);

            var longDescriptionTerm = coreVocModel.FindValueTerm("Org.OData.Core.V1.LongDescription");
            Assert.IsNotNull(longDescriptionTerm);
            var longDescriptionType = longDescriptionTerm.Type.Definition as IEdmPrimitiveType;
            Assert.IsNotNull(longDescriptionType);
            Assert.AreEqual(EdmPrimitiveTypeKind.String, longDescriptionType.PrimitiveKind);

            var isLanguageDependentTerm = coreVocModel.FindValueTerm("Org.OData.Core.V1.IsLanguageDependent");
            Assert.IsNotNull(isLanguageDependentTerm);
            var isLanguageDependentType = isLanguageDependentTerm.Type.Definition as IEdmTypeDefinition;
            Assert.IsNotNull(isLanguageDependentType);
            Assert.AreEqual(EdmPrimitiveTypeKind.Boolean, isLanguageDependentType.UnderlyingType.PrimitiveKind);

            StringWriter sw = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = System.Text.Encoding.UTF8;

            IEnumerable<EdmError> errors;
            XmlWriter xw = XmlWriter.Create(sw, settings);
            coreVocModel.TryWriteCsdl(xw, out errors);
            xw.Flush();
            xw.Close();
            string output = sw.ToString();
            Assert.IsTrue(!errors.Any(), "No Errors");
            Assert.AreEqual(expectedText, output, "expectedText = output");
        }
    }
}
