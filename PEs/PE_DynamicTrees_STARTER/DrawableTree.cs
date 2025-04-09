using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PE_DynamicTrees
{
    /// <summary>
    /// DO NOT MODIFY THIS FILE!!!
	///
    /// Base functionality for a drawable tree.
    /// </summary>
    class DrawableTree
	{
		// Constants for drawing
		private const float BranchAngle = 0.2f;
		private const float BranchLength = 25.0f;
		private const int BranchWidth = 2;

		// Fields for drawing
		private Color treeColor;

		// The root of the tree
		protected TreeNode root;


		/// <summary>
		/// Sets up the drawable tree
		/// </summary>
		/// <param name="sb"></param>
		/// <param name="treeColor"></param>
		public DrawableTree(Color treeColor)
		{
			// Save params
			this.treeColor = treeColor;

			// No data yet
			this.root = null;
		}

		/// <summary>
		/// Public facing Draw method - Draws the tree at
		/// the specified position
		/// </summary>
		/// <param name="position">Where to start drawing the tree</param>
		public void Draw(Vector2 position, GraphicsDevice device)
		{
			// Anything to draw?
			if (root == null)
				return;

			// Begin and end the spritebatch once and do
			// all the drawing between those calls
			ShapeBatch.Begin(device);
			Draw(root, position, 0);
			ShapeBatch.End();
		}


		/// <summary>
		/// Draws the lines from this node to its children (if they exist)
		/// </summary>
		/// <param name="node">The starting node</param>
		/// <param name="position">The position of this node on the screen</param>
		/// <param name="angle">The current angle of the line</param>
		private void Draw(TreeNode node, Vector2 position, float angle)
		{
			// Need to draw left?
			if (node.Left != null)
			{
				// Calculate the angle and position of the left node
				float leftAngle = angle - BranchAngle;
				Vector2 leftPos = position + Vector2.TransformNormal(Vector2.UnitY * -BranchLength, Matrix.CreateRotationZ(leftAngle));

				// Recursively draw
				ShapeBatch.Line(position, leftPos, treeColor);
				Draw(node.Left, leftPos, leftAngle);
			}

			// Need to draw right?
			if (node.Right != null)
			{
				// Calculate the angle and position of the right node
				float rightAngle = angle + BranchAngle;
				Vector2 rightPos = position + Vector2.TransformNormal(Vector2.UnitY * -BranchLength, Matrix.CreateRotationZ(rightAngle));

				// Recursively draw
				ShapeBatch.Line(position, rightPos, treeColor);
				Draw(node.Right, rightPos, rightAngle);
			}
		}
	}
}
