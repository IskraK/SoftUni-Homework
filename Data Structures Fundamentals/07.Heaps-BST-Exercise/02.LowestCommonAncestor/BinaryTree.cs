namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNode = this.Search(first);
            var secondNode = this.Search(second);
            var firstNodeAncestors = this.GetAncestors(firstNode);
            var secondNodeAncestors = this.GetAncestors(secondNode);
            var intersection = firstNodeAncestors.Intersect(secondNodeAncestors);

            return intersection.ToArray()[0];
        }

        private List<T> GetAncestors(IAbstractBinaryTree<T> node)
        {
            var list = new List<T>();

            while (node != null)
            {
                list.Add(node.Value);
                node = node.Parent;
            }

            return list;
        }

        private IAbstractBinaryTree<T> Search(T element)
        {
            var node = this;

            while (node != null)
            {
                if (IsSmaller(node.Value, element))
                {
                    node = node.RightChild;
                }
                else if (IsGreater(node.Value, element))
                {
                    node = node.LeftChild;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        private bool IsGreater(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }

        private bool IsSmaller(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }
    }
}
