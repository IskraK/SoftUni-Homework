namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return IndentedPreOrderDFS(this, 0);
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            return DFSInOrder(this, 0);
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            return DFSPostOrder(this, 0);
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return DFSPreOrder(this, 0);
        }

        public void ForEachInOrder(Action<T> action)
        {
            ForEachInOrderDFS(this, action);
        }

        ////Another decision
        //public void ForEachInOrder(Action<T> action)
        //{
        //    if (this.LeftChild != null)
        //    {
        //        this.LeftChild.ForEachInOrder(action);
        //    }

        //    action.Invoke(this.Value);

        //    if (this.RightChild != null)
        //    {
        //        this.RightChild.ForEachInOrder(action);
        //    }
        //}


        ////Decision with StringBuilder
        private string IndentedPreOrderDFS(IAbstractBinaryTree<T> node, int indent)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{new string(' ', indent)}{node.Value}");

            if (node.LeftChild != null)
            {
                sb.AppendLine(IndentedPreOrderDFS(node.LeftChild, indent + 2));
            }

            if (node.RightChild != null)
            {
                sb.AppendLine(IndentedPreOrderDFS(node.RightChild, indent + 2));
            }

            return sb.ToString().TrimEnd();
        }

        ////Decision with string
        //private string IndentedPreOrderDFS(IAbstractBinaryTree<T> node, int indent)
        //{
        //    string result = $"{new string(' ', indent)}{node.Value}\r\n";

        //    if (node.LeftChild != null)
        //    {
        //        result += IndentedPreOrderDFS(node.LeftChild, indent + 2);
        //    }

        //    if (node.RightChild != null)
        //    {
        //        result += IndentedPreOrderDFS(node.RightChild, indent + 2);
        //    }

        //    return result;
        //}

        private List<IAbstractBinaryTree<T>> DFSPreOrder(IAbstractBinaryTree<T> node, int indent)
        {
            var result = new List<IAbstractBinaryTree<T>>();
            result.Add(node);

            if (node.LeftChild != null)
            {
                result.AddRange(DFSPreOrder(node.LeftChild, indent + 2));
            }

            if (node.RightChild != null)
            {
                result.AddRange(DFSPreOrder(node.RightChild, indent + 2));
            }

            return result;
        }

        private List<IAbstractBinaryTree<T>> DFSInOrder(IAbstractBinaryTree<T> node, int indent)
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (node.LeftChild != null)
            {
                result.AddRange(DFSInOrder(node.LeftChild, indent + 2));
            }

            result.Add(node);

            if (node.RightChild != null)
            {
                result.AddRange(DFSInOrder(node.RightChild, indent + 2));
            }

            return result;
        }

        private List<IAbstractBinaryTree<T>> DFSPostOrder(IAbstractBinaryTree<T> node, int indent)
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (node.LeftChild != null)
            {
                result.AddRange(DFSPostOrder(node.LeftChild, indent + 2));
            }

            if (node.RightChild != null)
            {
                result.AddRange(DFSPostOrder(node.RightChild, indent + 2));
            }

            result.Add(node);

            return result;
        }

        private void ForEachInOrderDFS(IAbstractBinaryTree<T> node, Action<T> action)
        {
            if (node.LeftChild != null)
            {
                ForEachInOrderDFS(node.LeftChild, action);
            }

            action(node.Value);

            if (node.RightChild != null)
            {
                ForEachInOrderDFS(node.RightChild, action);
            }
        }


        //From Demo
        //public string DFSPreOrder(IAbstractBinaryTree<T> node, int indent)
        //{
        //    string result = $"{new string(' ', indent)}{node.Value}\r\n";

        //    if (node.LeftChild != null)
        //    {
        //        result += DFSPreOrder(node.LeftChild, indent + 2);
        //    }

        //    if (node.RightChild != null)
        //    {
        //        result += DFSPreOrder(node.RightChild, indent + 2);
        //    }

        //    return result;
        //}

        //public string DFSInOrder(IAbstractBinaryTree<T> node, int indent)
        //{
        //    string result = "";

        //    if (node.LeftChild != null)
        //    {
        //        result += DFSInOrder(node.LeftChild, indent + 2);
        //    }

        //    result += $"{new string(' ', indent)}{node.Value}\r\n";

        //    if (node.RightChild != null)
        //    {
        //        result += DFSInOrder(node.RightChild, indent + 2);
        //    }

        //    return result;
        //}

        //public string DFSPostOrder(IAbstractBinaryTree<T> node, int indent)
        //{
        //    string result = "";

        //    if (node.LeftChild != null)
        //    {
        //        result += DFSPostOrder(node.LeftChild, indent + 2);
        //    }

        //    if (node.RightChild != null)
        //    {
        //        result += DFSPostOrder(node.RightChild, indent + 2);
        //    }

        //    result += $"{new string(' ', indent)}{node.Value}\r\n";

        //    return result;
        //}
    }
}
