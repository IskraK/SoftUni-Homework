namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private static bool isRootDelete = false;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            if (isRootDelete)
            {
                return new List<T>();
            }

            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();
                result.Add(subtree.Value);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            if (isRootDelete)
            {
                return new List<T>();
            }

            return DFS(this);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            if (this.Value.Equals(parentKey))
            {
                this.children.Add(child);
                child.Parent = this;
                return;
            }

            var tree = DfsSearch(parentKey);

            CheckEmptyNode(tree);
            tree.AddChild(parentKey, child);
        }

        public void RemoveNode(T nodeKey)
        {
            var subtree = BfsSearch(nodeKey);
            CheckEmptyNode(subtree);


            if (subtree.Parent == null)
            {
                subtree.children.Clear();
                isRootDelete = true;
                subtree.Value = default(T);
            }
            else
            {
                subtree.Parent.RemoveChild(subtree);
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            //var firstNode = BfsSearch(firstKey);
            //var secondNode = BfsSearch(secondKey);

            //CheckEmptyNode(firstNode);
            //CheckEmptyNode(secondNode);

            //if (firstNode.Parent == null)
            //{
            //    SwapRoot(secondNode);
            //}
            //else
            //{
            //    firstNode.Parent = secondNode.Parent;
            //    secondNode.Parent = firstNode.Parent;

            //    SwapTrees(firstNode, secondNode);
            //}

            var firstNode = this.BfsSearch(firstKey);
            var secondNode = this.BfsSearch(secondKey);
            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);
            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                this.SwapRoot(secondNode);
                return;
            }

            if (secondParent == null)
            {
                this.SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent.children.IndexOf(firstNode);
            int indexOfSecond = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirst] = secondNode;
            secondParent.children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> secondNode)
        {
            this.children.Clear();
            this.children.AddRange(secondNode.children);
            secondNode.Parent = null;
            this.Value = secondNode.Value;
        }

        //private void SwapTrees(Tree<T> first, Tree<T> second)
        //{
        //    int indexOfFirst = first.Parent.children.IndexOf(first);
        //    int indexOfSecond = second.Parent.children.IndexOf(second);

        //    first.Parent.children[indexOfFirst] = second;
        //    second.Parent.children[indexOfSecond] = first;
        //}

        private ICollection<T> DFS(Tree<T> tree)
        {
            List<T> result = new List<T>();

            foreach (var child in tree.Children)
            {
                result.AddRange(DFS(child));
            }

            result.Add(tree.Value);

            return result;
        }

        private Tree<T> BfsSearch(T parentKey)
        {
            Queue<Tree<T>> tree = new Queue<Tree<T>>();

            tree.Enqueue(this);

            while (tree.Count > 0)
            {
                var subtree = tree.Dequeue();

                if (subtree.Value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    tree.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> DfsSearch(T parentKey)
        {
            if (this.Value.Equals(parentKey))
            {
                return this;
            }

            Tree<T> result = null;
            foreach (var child in this.Children)
            {
                result = child.DfsSearch(parentKey);
                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        private bool RemoveChild(Tree<T> subtree)
        {
            subtree.Parent = null;
            foreach (var child in subtree.Children)
            {
                child.Parent = null;
            }
            return this.children.Remove(subtree);
        }

        private void CheckEmptyNode(Tree<T> tree)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
