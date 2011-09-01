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

namespace Microsoft.Data.OData.Atom
{
    #region Namespaces
    using System.Diagnostics;
    using System.Linq;
    using System.Xml;
    using Microsoft.Data.OData.Metadata;
    #endregion Namespaces

    /// <summary>
    /// OData ATOM deserializer for EPM.
    /// </summary>
    internal abstract class ODataAtomEpmDeserializer : ODataAtomDeserializer
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="atomInputContext">The ATOM input context to read from.</param>
        internal ODataAtomEpmDeserializer(ODataAtomInputContext atomInputContext)
            : base(atomInputContext)
        {
            DebugUtils.CheckNoExternalCallers();
        }

        /// <summary>
        /// Reads an extension element in non-ATOM namespace in the content of the entry element.
        /// </summary>
        /// <param name="entryState">The reader entry state for the entry being read.</param>
        /// <remarks>
        /// Pre-Condition:  XmlNodeType.Element - the element in non-ATOM namespace to read.
        /// Post-Condition: Any                 - the node after the extension element which was read.
        /// </remarks>
        internal void ReadExtensionElementInEntryContent(IODataAtomReaderEntryState entryState)
        {
            DebugUtils.CheckNoExternalCallers();
            Debug.Assert(entryState != null, "entryState != null");
            this.AssertXmlCondition(XmlNodeType.Element);
            Debug.Assert(this.XmlReader.NamespaceURI != AtomConstants.AtomNamespace, "Only elements in non-ATOM namespace can be read by this method.");

            ODataEntityPropertyMappingCache cachedEpm = entryState.CachedEpm;
            Debug.Assert(cachedEpm != null, "This method should only be called if there's EPM for the entry defined.");
            EpmTargetPathSegment epmTargetPathSegment = cachedEpm.EpmTargetTree.NonSyndicationRoot;

            this.ReadCustomEpmElement(entryState, epmTargetPathSegment);
        }

        /// <summary>
        /// Checks if the reader is positioned on the m:null attribute and if so reads its value.
        /// </summary>
        /// <param name="hasMetadataNullAttributeWithTrueValue">
        /// If the m:null attribute is found and its value is true and we should be reading it as per EPM rules,
        /// this is set to true; otherwise it's set to false.
        /// </param>
        protected void TryReadMetadataNullAttribute(out bool hasMetadataNullAttributeWithTrueValue)
        {
            this.AssertXmlCondition(XmlNodeType.Attribute);

            hasMetadataNullAttributeWithTrueValue = false;
            if (this.XmlReader.NamespaceEquals(this.XmlReader.ODataMetadataNamespace) &&
                string.CompareOrdinal(this.XmlReader.LocalName, AtomConstants.ODataNullAttributeName) == 0)
            {
                // Only read the m:null if we're reading V3 or higher payloads
                if (this.Version >= ODataVersion.V3)
                {
                    hasMetadataNullAttributeWithTrueValue = ODataAtomReaderUtils.ReadMetadataNullAttributeValue(this.XmlReader.Value);
                }
            }
        }

        /// <summary>
        /// Reads an element for custom EPM.
        /// </summary>
        /// <param name="entryState">The reader entry state for the entry being read.</param>
        /// <param name="epmTargetPathSegment">The EPM target segment for the parent element to which the element belongs.</param>
        /// <remarks>
        /// Pre-Condition:  XmlNodeType.Element - the element to read.
        /// Post-Condition: Any                 - the node after the element which was read.
        /// 
        /// The method works on any element, it checks if the element should be used for EPM or not.
        /// </remarks>
        private void ReadCustomEpmElement(IODataAtomReaderEntryState entryState, EpmTargetPathSegment epmTargetPathSegment)
        {
            Debug.Assert(entryState != null, "entryState != null");
            this.AssertXmlCondition(XmlNodeType.Element);
            Debug.Assert(epmTargetPathSegment != null, "epmTargetPathSegment != null");

            string localName = this.XmlReader.LocalName;
            string namespaceUri = this.XmlReader.NamespaceURI;
            EpmTargetPathSegment elementSegment = epmTargetPathSegment.SubSegments.FirstOrDefault(
                segment => !segment.IsAttribute &&
                string.CompareOrdinal(segment.SegmentName, localName) == 0 &&
                string.CompareOrdinal(segment.SegmentNamespaceUri, namespaceUri) == 0);

            if (elementSegment == null || (elementSegment.HasContent && entryState.EpmCustomReaderValueCache.Contains(elementSegment.EpmInfo)))
            {
                // Skip elements which are not part of EPM.
                // This would be the place to implement custom XML extensions one day.
                // Also skip elements for which we already have value.
                // Both WCF DS client and server will only read the first value from custom EPM for any given EPM info.
                // It also follows the behavior for syndication EPM, where we read only the first author if there are multiple (for example).
                // We don't want to try to parse such elements since the parsing itself may fail and we should not be failing on values
                // which we don't care about.
                this.XmlReader.Skip();
            }
            else
            {
                bool hasMetadataNullAttributeWithTrueValue = false;
                while (this.XmlReader.MoveToNextAttribute())
                {
                    this.TryReadMetadataNullAttribute(out hasMetadataNullAttributeWithTrueValue);

                    // Note that we still need to consider the attribute for EPM, even if it was m:null.
                    this.ReadCustomEpmAttribute(entryState, elementSegment);
                }

                this.XmlReader.MoveToElement();

                if (elementSegment.HasContent)
                {
                    string stringValue;
                    if (hasMetadataNullAttributeWithTrueValue)
                    {
                        // The m:null attribute has a precedence over the content of the element, thus if we find m:null='true' we ignore the content of the element.
                        this.XmlReader.Skip();
                        stringValue = null;
                    }
                    else
                    {
                        // Read the value of the element.
                        stringValue = this.ReadElementStringValue();
                    }

                    entryState.EpmCustomReaderValueCache.Add(elementSegment.EpmInfo, stringValue);
                }
                else
                {
                    if (!this.XmlReader.IsEmptyElement)
                    {
                        // Move to the first child node of the element.
                        this.XmlReader.Read();

                        while (this.XmlReader.NodeType != XmlNodeType.EndElement)
                        {
                            switch (this.XmlReader.NodeType)
                            {
                                case XmlNodeType.EndElement:
                                    break;

                                case XmlNodeType.Element:
                                    this.ReadCustomEpmElement(entryState, elementSegment);
                                    break;

                                default:
                                    this.XmlReader.Skip();
                                    break;
                            }
                        }
                    }

                    // Read the end element or the empty start element.
                    this.XmlReader.Read();
                }
            }
        }

        /// <summary>
        /// Reads an attribute for custom EPM.
        /// </summary>
        /// <param name="entryState">The reader entry state for the entry being read.</param>
        /// <param name="epmTargetPathSegmentForElement">The EPM target segment for the element to which the attribute belongs.</param>
        /// <remarks>
        /// Pre-Condition:  XmlNodeType.Attribute - the attribute to read.
        /// Post-Condition: XmlNodeType.Attribute - the same attribute, the method doesn't move the reader.
        /// 
        /// The method works on any attribute, it checks if the attribute should be used for EPM or not.
        /// </remarks>
        private void ReadCustomEpmAttribute(IODataAtomReaderEntryState entryState, EpmTargetPathSegment epmTargetPathSegmentForElement)
        {
            Debug.Assert(entryState != null, "entryState != null");
            this.AssertXmlCondition(XmlNodeType.Attribute);
            Debug.Assert(epmTargetPathSegmentForElement != null, "epmTargetPathSegmentForElement != null");

            string localName = this.XmlReader.LocalName;
            string namespaceUri = this.XmlReader.NamespaceURI;
            EpmTargetPathSegment attributeSegment = epmTargetPathSegmentForElement.SubSegments.FirstOrDefault(
                segment => segment.IsAttribute && 
                string.CompareOrdinal(segment.AttributeName, localName) == 0 &&
                string.CompareOrdinal(segment.SegmentNamespaceUri, namespaceUri) == 0);
            if (attributeSegment != null)
            {
                // Don't add values which we already have
                // Both WCF DS client and server will only read the first value from custom EPM for any given EPM info.
                // It also follows the behavior for syndication EPM, where we read only the first author if there are multiple (for example).
                if (!entryState.EpmCustomReaderValueCache.Contains(attributeSegment.EpmInfo))
                {
                    // Note that there's no way for an attribute to specify null value.
                    entryState.EpmCustomReaderValueCache.Add(attributeSegment.EpmInfo, this.XmlReader.Value);
                }
            }
        }

        /// <summary>
        /// Reads the value of the current XML element, as per custom EPM rules and returns it as a string.
        /// </summary>
        /// <returns>The string value read.</returns>
        /// <remarks>
        /// Pre-Condition:  XmlNodeType.Element - the element which value to read.
        /// Post-Condition: Any                 - the node after the element.
        /// </remarks>
        private string ReadElementStringValue()
        {
            this.AssertXmlCondition(XmlNodeType.Element);

            return this.XmlReader.ReadElementValue();
        }
    }
}
