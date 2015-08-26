using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using SNL.Deployments.Domain;
using System.Collections.ObjectModel;

namespace SNL.Deployments
{
    /// <summary>
    /// Common Data level extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Takes a FileStream object and reads all information therein to a
        /// IEnumerable of XElement.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ToXmlElements(this FileStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text.ToXmlElements();
        }

        /// <summary>
        /// Takes a string and uses an XmlReader to generate an 
        /// IEnumerable of XElement from the string.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ToXmlElements(this string xml)
        {
            try
            {
                var reader = xml.AsReader();
                var xmlDocument = XDocument.Load(reader);
                return xmlDocument.Elements();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Takes a string, turns it into a XmlReader.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static XmlReader AsReader(this string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                xml = "<EMPTY_XML>None Found</EMPTY_XML>";
            }

            try
            {
                var stream = new MemoryStream(xml.ToByteArray());
                var reader = XmlReader.Create(stream);
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Attempts to convert an xml element into a Uri.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Uri ToPath(this XElement element)
        {
            if (!string.IsNullOrEmpty(element.Value))
                return new Uri(element.Value);
            else
                return null;
        }

        /// <summary>
        /// Encodes a string into a UTF8 byte array. This is useful
        /// for preparing a string for file storage.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// Attempts to parse a string value into a DateTime.
        /// Returns null if not convertible.
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string dateValue)
        {
            DateTime now = DateTime.Now;
            if (DateTime.TryParse(dateValue, out now))
                return now;
            else
                return null;
        }

        public static DateTime ToDateTime(this string dateValue)
        {
            DateTime now = DateTime.Now;
            if (DateTime.TryParse(dateValue, out now))
            {
                if (now == DateTime.MinValue)
                    return DateTime.Now;
                return now;
            }
            else
                return DateTime.Now;
            
        }
    }
}
