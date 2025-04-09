using System;

namespace PE_DynamicTrees
{
    /// <summary>
    /// DO NOT MODIFY THIS FILE!!!
	///
    /// Holds a single piece of data in a tree,
    /// along with up to two child nodes
    /// </summary>
    class TreeNode
	{
		/// <summary>
		/// Gets or sets the data of this node
		/// </summary>
		public int Data { get; set; }

		/// <summary>
		/// Gets or sets this node's left child
		/// </summary>
		public TreeNode Left { get; set; }

		/// <summary>
		/// Gets or sets this node's right child
		/// </summary>
		public TreeNode Right { get; set; }

		/// <summary>
		/// Creates a node with the specified data
		/// </summary>
		/// <param name="data">The data to store in this node</param>
		public TreeNode(int data)
		{
			this.Data = data;
		}
	}
}
