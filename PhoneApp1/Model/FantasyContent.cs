using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    class FantasyContent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://relaxng.org/ns/structure/1.0", IsNullable = false)]
        public partial class grammar
        {

            private grammarDefine defineField;

            private string nsField;

            private string datatypeLibraryField;

            /// <remarks/>
            public grammarDefine define
            {
                get
                {
                    return this.defineField;
                }
                set
                {
                    this.defineField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ns
            {
                get
                {
                    return this.nsField;
                }
                set
                {
                    this.nsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string datatypeLibrary
            {
                get
                {
                    return this.datatypeLibraryField;
                }
                set
                {
                    this.datatypeLibraryField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        public partial class grammarDefine
        {

            private grammarDefineElement elementField;

            private string nameField;

            /// <remarks/>
            public grammarDefineElement element
            {
                get
                {
                    return this.elementField;
                }
                set
                {
                    this.elementField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        public partial class grammarDefineElement
        {

            private grammarDefineElementRef refField;

            private grammarDefineElementAttribute attributeField;

            private grammarDefineElementRef1[] choiceField;

            private string nameField;

            /// <remarks/>
            public grammarDefineElementRef @ref
            {
                get
                {
                    return this.refField;
                }
                set
                {
                    this.refField = value;
                }
            }

            /// <remarks/>
            public grammarDefineElementAttribute attribute
            {
                get
                {
                    return this.attributeField;
                }
                set
                {
                    this.attributeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("ref", IsNullable = false)]
            public grammarDefineElementRef1[] choice
            {
                get
                {
                    return this.choiceField;
                }
                set
                {
                    this.choiceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        public partial class grammarDefineElementRef
        {

            private string nameField;

            private string nsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ns
            {
                get
                {
                    return this.nsField;
                }
                set
                {
                    this.nsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        public partial class grammarDefineElementAttribute
        {

            private object textField;

            private string nameField;

            /// <remarks/>
            public object text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://relaxng.org/ns/structure/1.0")]
        public partial class grammarDefineElementRef1
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }



    }
}
