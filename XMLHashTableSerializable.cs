using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

namespace tororo_gui
{
    /// <summary>
    /// this class is a overload of Hastable that could be automatically sérialized, 
    /// when using System.Xml.Serialization.XmlSerializer.
    /// Thank you to Matt Brether, please visit his site :http://www.mattberther.com/2004/06/14/serializing-an-idictionary-object
    /// </summary>
    public class HashtableSerailizable : Hashtable, IXmlSerializable
    {
        #region IXmlSerializable Membres

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            // Start to use the reader.
            reader.Read();
            // Read the first element ie root of this object
            reader.ReadStartElement("dictionary");

            // Read all elements
            while (reader.NodeType != XmlNodeType.EndElement) {
                // parsing the item
                reader.ReadStartElement("item");

                // PArsing the key and value 
                string key = reader.ReadElementString("key");
                string value = reader.ReadElementString("value");

                // en reading the item.
                reader.ReadEndElement();
                reader.MoveToContent();

                // add the item
                this.Add(key, value);
            }

            // Extremely important to read the node to its end.
            // next call of the reader methods will crash if not called.
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            // Write the root elemnt 
            writer.WriteStartElement("dictionary");

            // Fore each object in this
            foreach (object key in this.Keys) {
                object value = this[key];
                // Write item, key and value
                writer.WriteStartElement("item");
                writer.WriteElementString("key", key.ToString());
                writer.WriteElementString("value", value.ToString());

                // write </item>
                writer.WriteEndElement();
            }
            // write </dictionnary>
            writer.WriteEndElement();
        }
        #endregion
    }
}
