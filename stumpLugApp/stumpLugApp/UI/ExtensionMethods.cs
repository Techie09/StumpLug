using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Appends String Builder, uses AppendLine() and String.Format()
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat(this StringBuilder builder, string format, params object[] args)
        {
            string value = String.Format(format, args);

            builder.AppendLine(value);

            return builder;
        }

        /// <summary>
        /// Appends the String Builder, but will cutoff text after the truncateSize and place "..." and Appends Line.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="truncateSize"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineTruncate(this StringBuilder builder, int truncateSize, string text)
        {
            string value = text.Substring(0, truncateSize);
            value += "...";

            builder.AppendLine(value);

            return builder;
        }

        /// <summary>
        /// Append the String Builder, but will cutoff text after the truncateSize and place "..." it also support String.Format() and Appends Line.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="truncateSize"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineTruncate(this StringBuilder builder, int truncateSize, string format, params object[] args)
        {
            string value = String.Format(format, args);

            builder.AppendLineTruncate(truncateSize, value);

            return builder;
        }

        /// <summary>
        /// Uses reflection to return description attribute on an enum value. will default to ToString() if attribute not found.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <remarks>Found code at: http://leandrob.com/2009/07/enumgetdescription-extension-method/ </remarks>
        public static string GetDescription(this Enum element)
        {
            //get the type of enum
            Type type = element.GetType();

            //get member from enum
            MemberInfo[] memberInfo = type.GetMember(element.ToString());

            //If a member is found, get its attributes
            if(memberInfo != null && memberInfo.Length > 0)
            {
                //get description attributes from member
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                //if attribute is found, get value from attribute
                if(attributes != null && attributes.Length > 0)
                {
                    //return the Description value of the Description Attribute
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            //If no description found, return value from ToString();
            return element.ToString();
        }

        /// <summary>
        /// returns enum value of string found in name of enum value or Description Attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns>Generic Enum Value</returns>
        /// <remarks> found code at: http://stackoverflow.com/questions/4367723/get-enum-from-description-attribute </remarks>
        public static T GetEnumValue<T>(this string description)
        {
            //get Type of object
            Type type = typeof(T);

            //if it is not an enum, throw exception
            if(!type.IsEnum) throw new InvalidOperationException();

            //loop through all the enum values
            foreach(var field in type.GetFields())
            {
                //get descrption attributes from enum value
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                //check if description attribute is found
                if(attribute != null)
                {
                    //check if they are equal
                    if(attribute.Description.ToLower().Equals(description.ToLower()))
                        return (T)field.GetValue(null); //return enum value
                }
                else
                {
                    //If attribute not found, check if string equals 
                    if(field.Name.ToLower().Equals(description.ToLower()))
                        return (T)field.GetValue(null); //return enum value;
                }
            }
            //no valid enum value found. throw exception
            throw new ArgumentException("Not found.", "description attribute was not found");
        }
    }
}
