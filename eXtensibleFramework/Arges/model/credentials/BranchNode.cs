// <copyright company="eXtensoft, LLC" file="BranchNode.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System.Collections.Generic;

    public sealed class BranchNode : Node
    {

        #region Nodes (List<Node>)

        private List<Node> _Nodes = new List<Node>();

        /// <summary>
        /// Gets or sets the List<Node> value for Nodes
        /// </summary>
        /// <value> The List<Node> value.</value>

        public List<Node> Nodes
        {
            get { return _Nodes; }
            set
            {
                if (_Nodes != value)
                {
                    _Nodes = value;
                }
            }
        }

        public override NodeTypeOption NodeType
        {
            get
            {
                return NodeTypeOption.Branch;
            }
        }

        #endregion
    }

}
