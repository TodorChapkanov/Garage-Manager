using System;
using System.Linq;
using System.Linq.Expressions;

namespace GarageManager.Extensions
{
    public static class QueryableExtensions
    {
        private const string OrderBy = "OrderBy";
        private const string OrderByDescending = "OrderByDescending";
        private const string ThenBy = "ThenBy";
        private const string ThenByDescending = "ThenByDescending";

        public static IOrderedQueryable<T> OrderByMember<T>(this IQueryable<T> source, string member)
        {
            return source.OrderByMemberUsing(member, OrderBy);
        }

        public static IOrderedQueryable<T> OrderByMemberDescending<T>(this IQueryable<T> source, string member)
        {
            return source.OrderByMemberUsing(member, OrderByDescending);
        }

        public static IOrderedQueryable<T> ThenByMember<T>(this IOrderedQueryable<T> source, string member)
        {
            return source.OrderByMemberUsing(member, ThenBy);
        }

        public static IOrderedQueryable<T> ThenByMemberDescending<T>(this IOrderedQueryable<T> source, string member)
        {
            return source.OrderByMemberUsing(member, ThenByDescending);
        }

        private static IOrderedQueryable<T> OrderByMemberUsing<T>(this IQueryable<T> source, string memberPath, string method)
        {
            var isOrderMemberValid = typeof(T)
                .GetProperties()
                .Any(pi => pi.Name == memberPath);

            if (!isOrderMemberValid)
            {
                return source as IOrderedQueryable<T>;
            }

            var parameter = Expression.Parameter(typeof(T), "item");
            var member = memberPath.Split('.')
                .Aggregate((Expression)parameter, Expression.PropertyOrField);
            var keySelector = Expression.Lambda(member, parameter);
            var methodCall = Expression.Call(
                typeof(Queryable), method,
                new[] { parameter.Type, member.Type },
                source.Expression, Expression.Quote(keySelector));
            var destination = source.Provider.CreateQuery(methodCall);

            return destination as IOrderedQueryable<T>;
        }
    }
}
