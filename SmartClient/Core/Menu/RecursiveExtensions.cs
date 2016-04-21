using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public static class RecursiveExtensions
    {
        public static IEnumerable<TSource> AsRecursive<TSource>(this IEnumerable<TSource> source)
            where TSource : IEnumerable<TSource>
        {
            return source.RecursiveSelect(o => o);
        }

        public static IEnumerable<TSource> RecursiveSelect<TSource>(this IEnumerable<TSource> source,
        Func<TSource, IEnumerable<TSource>> childSelector)
        {
            return RecursiveSelect(source, childSelector, element => element);
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, (element, index, depth) => selector(element));
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, (element, index, depth) => selector(element, index));
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, int, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, selector, 0);
        }

        private static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, int, TResult> selector, int depth)
        {
            return source.SelectMany((element, index) => Enumerable.Repeat(selector(element, index, depth), 1)
               .Concat(RecursiveSelect(childSelector(element) ?? Enumerable.Empty<TSource>(),
                  childSelector, selector, depth + 1)));
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> enumeration, params Func<T, IEnumerable<T>>[] childSelectors)
            where T : class
        {
            var itemList = new List<T>();

            foreach (var item in enumeration)
            {
                if (item != null)
                {
                    itemList.Add(item);

                    foreach (var childSelector in childSelectors)
                    {
                        if (childSelector != null)
                        {
                            var children = childSelector(item);
                            if (children != null)
                            {
                                itemList.AddRange(children.Flatten(childSelectors));
                            }
                        }
                    }
                }
            }

            return itemList;
        }

        public static T Head<T>(this T source, Func<T, T> parentAccessor)
            where T : class
        {
            var element = parentAccessor(source);
            if (element == null)
            {
                return source;
            }

            return element.Head(parentAccessor);
        }
    }
}
