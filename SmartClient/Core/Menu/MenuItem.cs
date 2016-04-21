namespace Core.Menu
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MenuItem : IEnumerable<MenuItem>, IMergeable<MenuItem>
    {
        private readonly ICollection<MenuItem> children = new HashSet<MenuItem>();
        private readonly MenuItem parent;

        public MenuItem(string name, MenuItem parent)
        {
            this.Name = name;
            this.parent = parent;
        }

        public string Name { get; set; }

        public MenuItem Parent
        {
            get { return this.parent; }
        }

        public string FullName
        {
            get
            {
                var accumulator = new Stack();
                for (var item = this; ; item = item.parent)
                {
                    accumulator.Push(item.Name);
                    if (item.parent == null)
                    {
                        break;
                    }
                }
                return string.Join("|", accumulator.ToArray());
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            return children.GetEnumerator();
        }

        public MenuItem CreateChild(string name)
        {
            var child = new MenuItem(name, this);
            children.Add(child);
            return child;
        }

        MenuItem IMergeable<MenuItem>.Merge(MenuItem other)
        {
            if (FullName != other.FullName)
            {
                return this;
            }

            foreach (var child in other)
            {
                var exists = children.SingleOrDefault(o => o.FullName == child.FullName);
                if (exists == null)
                {
                    this.CreateChild(child.Name);
                }
            }

            return this;
        }

        public void MergeFrom(MenuItem other)
        {
            Merge(this, other);
        }

        public void MergeFrom(params MenuItem[] otherItems)
        {
            foreach (var item in otherItems)
            {
                Merge(this, item);
            }
        }

        public static void Merge(MenuItem left, MenuItem right)
        {
            foreach (var x in new[] { left }.AsRecursive())
            {
                foreach (var y in new[] { right }.AsRecursive())
                {
                    ((IMergeable<MenuItem>)x).Merge(y);
                }
            }

            //var query = (from x in new[] { left }.AsRecursive()
            //             from y in new[] { right }.AsRecursive()
            //             select (x as IMergeable<MenuItem>).Merge(y))
            //             .Distinct();
        }
    }
}
