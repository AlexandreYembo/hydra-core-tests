using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Hydra.Core.Tests.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// when you have a attribute that has the setter private or protected, 
        /// so you can use this extension to set the value in property
        /// </summary>
        /// <param name="source"></param>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        public static void SetProperty<TSource, TProperty>(
           this TSource source,
            Expression<Func<TSource, TProperty>> prop,
            TProperty value)
        {
            var propertyInfo = (PropertyInfo)((MemberExpression)prop.Body).Member;
            propertyInfo.SetValue(source, value);
        }
    }
}