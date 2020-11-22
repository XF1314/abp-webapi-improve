using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// <see cref="IQuery{TEntity}"/>扩展s
    /// </summary>
    public static class QueryExtension
    {
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        public static Expression<Func<TEntity, bool>> GetQueryExpression<TEntity>(this IQuery<TEntity> query)
            where TEntity : class
        {
            if (query == null) return null;

            var queryType = query.GetType();
            var param = Expression.Parameter(typeof(TEntity), "o");
            var body = CreateAlwaysTrueExpression();
            foreach (PropertyInfo property in queryType.GetProperties())
            {
                var value = property.GetValue(query);
                if (value == null)
                    continue;

                if (value is string)
                {
                    var @string = ((string)value).Trim();
                    value = string.IsNullOrEmpty(@string) ? null : @string;
                }

                Expression sub = null;
                foreach (var attribute in property.GetAttributes<QueryAttribute>())
                {
                    var propertyPath = attribute.PropertyPath;
                    if (propertyPath == null || propertyPath.Length == 0)
                        propertyPath = new[] { property.Name };

                    var experssion = CreateQueryExpression(param, value, propertyPath, attribute.ComparisonOperator);
                    if (experssion != null)
                        sub = sub == null ? experssion : Expression.Or(sub, experssion);
                }

                if (sub != null)
                    body = body == null ? sub : Expression.And(body, sub);
            }

            if (body != null)
                return Expression.Lambda<Func<TEntity, bool>>(body, param);

            return null;
        }

        private static Expression CreateAlwaysTrueExpression()
        {
            var left = Expression.Constant(1, typeof(int));
            var right = Expression.Constant(1, typeof(int));

            return Expression.Equal(left, right);
        }

        private static Expression CreateQueryExpression(Expression param, object value, string[] propertyPath, QueryComparisonOperator comparisonOperator)
        {
            var member = CreatePropertyExpression(param, propertyPath);
            switch (comparisonOperator)
            {
                case QueryComparisonOperator.Equal:
                    return CreateEqualExpression(member, value);
                case QueryComparisonOperator.NotEqual:
                    return CreateNotEqualExpression(member, value);
                case QueryComparisonOperator.Like:
                    return CreateLikeExpression(member, value);
                case QueryComparisonOperator.NotLike:
                    return CreateNotLikeExpression(member, value);
                case QueryComparisonOperator.StartWidth:
                    return CreateStartsWithExpression(member, value);
                case QueryComparisonOperator.LessThan:
                    return CreateLessThanExpression(member, value);
                case QueryComparisonOperator.LessThanOrEqual:
                    return CreateLessThanOrEqualExpression(member, value);
                case QueryComparisonOperator.GreaterThan:
                    return CreateGreaterThanExpression(member, value);
                case QueryComparisonOperator.GreaterThanOrEqual:
                    return CreateGreaterThanOrEqualExpression(member, value);
                case QueryComparisonOperator.Between:
                    return CreateBetweenExpression(member, value);
                case QueryComparisonOperator.GreaterEqualAndLess:
                    return CreateGreaterEqualAndLessExpression(member, value);
                case QueryComparisonOperator.Include:
                    return CreateIncludeExpression(member, value);
                case QueryComparisonOperator.NotInclude:
                    return CreateNotIncludeExpression(member, value);
                case QueryComparisonOperator.IsNull:
                    return CreateIsNullExpression(member, value);
                case QueryComparisonOperator.HasFlag:
                    return CreateHasFlagExpression(member, value);
                default:
                    return null;
            }
        }

        private static MemberExpression CreatePropertyExpression(Expression param, string[] propertyPath)
        {
            var expression = propertyPath.Aggregate(param, Expression.Property) as MemberExpression;
            return expression;
        }


        private static Expression CreateEqualExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.Equal(member, val);
        }

        private static Expression CreateNotEqualExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.NotEqual(member, val);
        }

        private static Expression CreateLikeExpression(MemberExpression member, object value)
        {
            if (value == null) return null;
            if (member.Type != typeof(string))
                throw new ArgumentOutOfRangeException(nameof(member), $"Member '{member}' can not use 'Like' compare");

            var str = value.ToString();
            var val = Expression.Constant(str);

            return Expression.Call(member, nameof(string.Contains), null, val);
        }

        private static Expression CreateNotLikeExpression(MemberExpression member, object value)
        {
            var like = CreateLikeExpression(member, value);
            if (like == null) return null;

            return Expression.Not(like);
        }

        private static Expression CreateStartsWithExpression(MemberExpression member, object value)
        {
            if (value == null) return null;
            if (member.Type != typeof(string))
                throw new ArgumentOutOfRangeException(nameof(member), $"Member '{member}' can not use 'Like' compare");

            var str = value.ToString();
            var val = Expression.Constant(str);

            return Expression.Call(member, nameof(string.StartsWith), null, val);
        }

        private static Expression CreateLessThanExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.LessThan(member, val);
        }

        private static Expression CreateLessThanOrEqualExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.LessThanOrEqual(member, val);
        }

        private static Expression CreateGreaterThanExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.GreaterThan(member, val);
        }

        private static Expression CreateGreaterThanOrEqualExpression(MemberExpression member, object value)
        {
            if (value == null) return null;

            var val = Expression.Constant(ChangeType(value, member.Type), member.Type);

            return Expression.GreaterThanOrEqual(member, val);
        }

        private static Expression CreateBetweenExpression(MemberExpression member, object value)
        {
            var items = ParseValueToItems(member.Type, value);
            if (items is null) return null;
            if (items.Count < 2) return null;

            var left = items[0];
            var right = items[items.Count - 1];
            if (left == null || right == null) return null;

            var leftValue = Expression.Constant(left, member.Type);
            var rightValue = Expression.Constant(right, member.Type);

            return Expression.And(Expression.GreaterThanOrEqual(member, leftValue),
                Expression.LessThanOrEqual(member, rightValue));
        }

        private static Expression CreateGreaterEqualAndLessExpression(MemberExpression member, object value)
        {
            var items = ParseValueToItems(member.Type, value);
            if (items is null) return null;
            if (items.Count < 2) return null;

            var left = items[0];
            var right = items[items.Count - 1];
            if (left == null || right == null) return null;

            var leftValue = Expression.Constant(left, member.Type);
            var rightValue = Expression.Constant(right, member.Type);

            return Expression.And(Expression.GreaterThanOrEqual(member, leftValue),
                Expression.LessThan(member, rightValue));
        }

        private static Expression CreateIncludeExpression(MemberExpression member, object value)
        {
            var items = ParseValueToItems(member.Type, value);
            if (items == null || items.Count == 0) return null;
            if (items.Count == 1)
                return CreateEqualExpression(member, items[0]);
            var values = Expression.Constant(items);

            return Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), new[] { member.Type }, values, member);
        }

        private static Expression CreateNotIncludeExpression(MemberExpression member, object value)
        {
            var includeExpression = CreateIncludeExpression(member, value);
            if (includeExpression == null) return null;

            return Expression.Not(includeExpression);
        }

        private static Expression CreateIsNullExpression(MemberExpression member, object value)
        {
            if (member.Type.IsValueType && !member.Type.IsNullableType())
                throw new InvalidOperationException($"Member:{member} can not use '{QueryComparisonOperator.IsNull}' compare");

            var nullVal = Expression.Constant(null, member.Type);

            if (value == null || Equals(value, false))
                return Expression.Equal(member, nullVal);

            return Expression.NotEqual(member, nullVal);
        }

        private static Expression CreateHasFlagExpression(MemberExpression member, object value)
        {
            if (!member.Type.GetNonNullableType().IsEnum)
                throw new InvalidOperationException($"Member:{member} is not a Enum type");
            var items = ParseValueToItems(member.Type.GetNonNullableType(), value);
            if (items == null || items.Count == 0) return null;

            var p = member;
            if (member.Type.IsNullableType())
                p = Expression.Property(member, "Value");

            Expression exp = null;
            foreach (var item in items)
            {
                var @enum = Expression.Constant(item, typeof(Enum));
                var method = typeof(Enum).GetMethod(nameof(Enum.HasFlag), new[] { typeof(Enum) });
                Expression temp = Expression.Call(p, method, @enum);
                exp = exp != null ? Expression.Or(exp, temp) : temp;
            }

            return exp;
        }

        private static IList ParseValueToItems(Type memberType, object value)
        {
            if (value == null) return null;

            var items = value as IEnumerable;
            if (value is string)
                items = value.As<string>().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim());

            if (items is null)
                items = new[] { value };

            if (!items.ToDynamicArray().Any()) return null;

            var typedItems = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(memberType));
            foreach (var item in items)
            {
                try
                {
                    typedItems.Add(ChangeType(item, memberType));
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }

            return typedItems;
        }

        private static object ChangeType(object value, Type type)
        {
            if (value == null) return null;

            type = type.GetNonNullableType();
            if (type == value.GetType().GetNonNullableType()) return value;

            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, (string)value);
                else
                    return Enum.ToObject(type, value);
            }
            if (value is string && type == typeof(Guid))
                return new Guid((string)value);
            if (value is string && type == typeof(Version))
                return new Version((string)value);

            return Convert.ChangeType(value, type);
        }
    }
}
