// project  : UniversalTypeConverter
// file     : ObjectExtension.Compatibility.cs
// author   : Thorsten Bruning
// date     : 2019-04-15 

using System;
using System.Collections;
using System.Globalization;

namespace TB.ComponentModel {

    public partial class ObjectExtension {

        /// <summary>
        /// For backward compatibility only. Use <see cref="IsConvertibleTo{T}(object,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use IsConvertibleTo<T>() instead.")]
        public static bool CanConvertTo<T>(this object value, CultureInfo culture = null) {
            return value.IsConvertibleTo<T>(culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="IsConvertibleTo{T}(object,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use IsConvertibleTo<T>() instead.")]
        public static bool TryConvertTo<T>(this object value, out T result, CultureInfo culture = null) {
            return value.IsConvertibleTo(out result, culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="To{T}(object,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use To<T>() instead.")]
        public static T ConvertTo<T>(this object value, CultureInfo culture = null) {
            return value.To<T>(culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="IsConvertibleTo(object,Type,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use IsConvertibleTo() instead.")]
        public static bool CanConvert(this object value, Type destinationType, CultureInfo culture = null) {
            return value.IsConvertibleTo(destinationType, culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="IsConvertibleTo(object,Type,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use IsConvertibleTo() instead.")]
        public static bool TryConvert(this object value, Type destinationType, out object result, CultureInfo culture = null) {
            return value.IsConvertibleTo(destinationType, out result, culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="To(object,Type,CultureInfo)"/> instead.
        /// </summary>
        [Obsolete("Use To() instead.")]
        public static object Convert(this object value, Type destinationType, CultureInfo culture = null) {
            return value.To(destinationType, culture);
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="EnumerableExtension.ToEnumerable{T}"/> instead.
        /// </summary>
        [Obsolete("Use ToEnumerable<T>() instead.")]
        public static EnumerableConversion<T> ConvertToEnumerable<T>(this IEnumerable values) {
            return values.ToEnumerable<T>();
        }

        /// <summary>
        /// For backward compatibility only. Use <see cref="EnumerableExtension.ToEnumerable"/> instead.
        /// </summary>
        [Obsolete("Use ToEnumerable() instead.")]
        public static EnumerableConversion<object> ConvertToEnumerable(this IEnumerable values, Type destinationType) {
            return values.ToEnumerable(destinationType);
        }
    }

}