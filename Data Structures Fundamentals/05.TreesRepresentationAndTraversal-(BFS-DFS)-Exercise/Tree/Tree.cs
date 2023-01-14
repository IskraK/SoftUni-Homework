namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return DfsToString(this);
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            return this.GetDeepestNode();
        }

        public List<T> GetLeafKeys()
        {
            //List<T> leafs = new List<T>();

            //Queue<Tree<T>> tree = new Queue<Tree<T>>();

            //tree.Enqueue(this);

            //while (tree.Count > 0)
            //{
            //    var subtree = tree.Dequeue();

            //    if (subtree.Children.Count == 0)
            //    {
            //        leafs.Add(subtree.Key);
            //    }

            //    foreach (var child in subtree.Children)
            //    {
            //        tree.Enqueue(child);
            //    }
            //}

            //leafs.Sort();

            //return leafs;

            var leafNodes = this.GetLeafNodes();

            return leafNodes.Select(l => l.Key).ToList();
        }

        //BFS
        private List<Tree<T>> GetLeafNodes()
        {
            var leafNodes = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> leafs = new List<T>();

            Queue<Tree<T>> tree = new Queue<Tree<T>>();

            tree.Enqueue(this);

            while (tree.Count > 0)
            {
                var subtree = tree.Dequeue();

                if (subtree.Children.Count > 0 && subtree.Parent != null)
                {
                    leafs.Add(subtree.Key);
                }

                foreach (var child in subtree.Children)
                {
                    tree.Enqueue(child);
                }
            }

            leafs.Sort();

            return leafs;
        }

        public List<T> GetLongestPath()
        {
            Tree<T> current = this.GetDeepestNode();
            var path = new Stack<T>();

            while (current != null)
            {
                path.Push(current.Key);
                current = current.Parent;
            }

            return path.ToList();
        }

        private Tree<T> GetDeepestNode()
        {
            var leafNodes = this.OrderBfsNodes()
                .Where(tree => ((Tree<T>)tree).children.Count == 0);

            int maxDepth = 0;

            Tree<T> deepestNode = null;

            foreach (var leaf in leafNodes)
            {
                int currentDepth = this.GetDepth(leaf);
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        private IEnumerable<Tree<T>> OrderBfsNodes()
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                result.Add(currentNode);

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }
            return result;
        }

        // Solution starting from leaf node
        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);  // int.Parse(node.Key.ToString())
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    result.Add(currentNodes);
                }
            }

            return result;
        }

        ////DFS Solution
        //public List<List<T>> PathsWithGivenSum(int sum)
        //{
        //    var list = new List<List<T>>();
        //    var currentSum = 0;
        //    this.PathWithSumDFS(this, ref currentSum, sum, list, new List<T>());

        //    return list;
        //}

        //private void PathWithSumDFS(Tree<T> node, ref int currentSum, int targetSum, List<List<T>> allPaths, List<T> currentPathValues)
        //{
        //    currentSum += Convert.ToInt32(node.Key);
        //    currentPathValues.Add(node.Key);

        //    foreach (var child in node.Children)
        //    {
        //        this.PathWithSumDFS(child, ref currentSum, targetSum, allPaths, currentPathValues);
        //    }

        //    if (currentSum == targetSum)
        //    {
        //        allPaths.Add(new List<T>(currentPathValues));
        //    }

        //    currentSum -= Convert.ToInt32(node.Key);
        //    currentPathValues.RemoveAt(currentPathValues.Count - 1);
        //}

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                currentSum += SubTreeSumDFS(child, targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        }


        private string DfsToString(Tree<T> tree, int level = 0)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(new string(' ', level));
            sb.AppendLine($"{tree.Key}");

            foreach (var child in tree.Children)
            {
                sb.AppendLine(DfsToString(child, level + 2));
            }
            return sb.ToString().TrimEnd();
        }

    }
}
