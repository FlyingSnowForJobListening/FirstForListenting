using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace FS.Utility
{
    public static class XmlHelpercs
    {
        #region Public Method
        public static string ToXmlString<T>(this T entry)
        {
            return null;
        }

        public static XElement ToXElememt<T>(this T entry, XElement parent, XNamespace xNamespace = null)
        {
            XElement xEle = null;
            try
            {
                xEle = new XElement(typeof(T).Name.ToXName(xNamespace));
                parent.Add(xEle);
                ConvertToXElement(ref xEle, entry, xNamespace);
            }
            catch (Exception ex)
            {
                throw new Exception("AndyXmlHelperc ToXElement Exception:" + ex.ToString());
            }
            return parent;
        }

        public static XElement ToXElememt<T>(this T entry, XNamespace xNamespace = null, string prefix = null)
        {
            XElement xEle = null;
            try
            {
                xEle = new XElement(typeof(T).Name.ToXName(xNamespace));
                ConvertToXElement(ref xEle, entry, xNamespace);
                xEle.SetAttributeValue(XNamespace.Xmlns + prefix, xNamespace);
            }
            catch (Exception ex)
            {
                throw new Exception("AndyXmlHelperc ToXElement Exception:" + ex.ToString());
            }
            return xEle;
        }
        #endregion

        #region Private Method
        private static void ConvertToXElement(ref XElement xEleP, object obj, XNamespace ns = null)
        {
            XElement xEleS = null;
            try
            {
                foreach (PropertyInfo info in obj.GetType().GetProperties().Where(p => p.CanRead))
                {
                    if (IsPrimitiveType(info.PropertyType))
                    {
                        if (info.PropertyType == typeof(DateTime))
                        {
                            xEleS = new XElement(info.Name.ToXName(ns), ((DateTime)info.GetValue(obj)).ToString("yyyyMMddHHmmss"));
                        }
                        else
                        {
                            if (info.GetValue(obj) == null)
                                xEleS = new XElement(info.Name.ToXName(ns));
                            else
                                xEleS = new XElement(info.Name.ToXName(ns), info.GetValue(obj).ToString());
                        }
                        xEleP.Add(xEleS);
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(info.PropertyType))
                    {
                        xEleS = new XElement(info.Name.ToXName(ns));
                        xEleP.Add(xEleS);
                        foreach (object item in ((IEnumerable)info.GetValue(obj)).Cast<object>())
                        {
                            if (IsPrimitiveType(item.GetType()))
                            {
                                XElement xEles = new XElement(item.GetType().Name.ToXName(ns), item.ToString());
                                xEleS.Add(xEles);
                            }
                            else
                            {
                                XElement xEles = new XElement(item.GetType().Name.ToXName(ns));
                                xEleS.Add(xEles);
                                ConvertToXElement(ref xEles, item, ns);
                            }
                        }
                    }
                    else if (info.PropertyType.IsClass)
                    {
                        xEleS = new XElement(info.Name.ToXName(ns));
                        ConvertToXElement(ref xEleS, info.GetValue(obj), ns);
                        xEleP.Add(xEleS);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        private static bool IsPrimitiveType(Type type)
        {
            return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
        }

        private static XName ToXName(this string name, XNamespace ns = null)
        {
            if (ns == null)
            {
                return name;
            }
            else
            {
                return ns + name;
            }
        }
        #endregion
    }
}
