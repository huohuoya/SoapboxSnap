#region "SoapBox.Protocol License"
/// <header module="SoapBox.Protocol"> 
/// Copyright (C) 2010 SoapBox Automation, All Rights Reserved.
/// Contact: SoapBox Automation Licencing (license@soapboxautomation.com)
/// 
/// This file is part of SoapBox Protocol.
///
/// SoapBox Protocol is available under your choice of these licenses:
///  - GPLv3
///  - CDDLv1.0
///
/// GNU General Public License Usage
/// SoapBox Protocol is free software: you can redistribute it and/or modify it
/// under the terms of the GNU General Public License as published by the 
/// Free Software Foundation, either version 3 of the License, or 
/// (at your option) any later version.
/// 
/// SoapBox Protocol is distributed in the hope that it will be useful, but 
/// WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
/// 
/// You should have received a copy of the GNU General Public License along
/// with SoapBox Protocol. If not, see <http://www.gnu.org/licenses/>.
/// 
/// Common Development and Distribution License Usage
/// SoapBox Protocol is subject to the CDDL Version 1.0. 
/// You should have received a copy of the CDDL Version 1.0 along
/// with SoapBox Protocol.  If not, see <http://www.sun.com/cddl/cddl.html>.
/// The CDDL is a royalty free, open source, file based license.
/// </header>
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SoapBox.Protocol.Base
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NodePeerList : NodeBase
    {
        //readonly members
        public readonly TypedChildCollection<NodePeer, NodePeerList> Peers = null;

        #region " FIELDS "

        #endregion

        #region " CONSTRUCTORS "
        private NodePeerList(ReadOnlyDictionary<FieldIdentifier, FieldBase> Fields,
            ReadOnlyCollection<NodeBase> Children)
            : base(Fields, Children)
        {
            Peers = new TypedChildCollection<NodePeer, NodePeerList>(this);
        }

        protected override NodeBase CopyWithNewChildren(ReadOnlyCollection<NodeBase> NewChildren)
        {
            return new NodePeerList(Fields, NewChildren);
        }
        #endregion

        #region " BUILDER(S) "

        private static NodeBase Resurrect(
            ReadOnlyDictionary<FieldIdentifier, FieldBase> Fields,
            ReadOnlyCollection<NodeBase> Children)
        {
            return new NodePeerList(Fields, Children);
        }

        public static NodePeerList BuildWith()
        {
            //build fields
            Dictionary<FieldIdentifier, FieldBase> mutableFields =
                new Dictionary<FieldIdentifier, FieldBase>();

            //build children
            KeyedNodeCollection<NodeBase> mutableChildren =
                new KeyedNodeCollection<NodeBase>();

            //build node
            NodePeerList Builder = new NodePeerList(
                new ReadOnlyDictionary<FieldIdentifier, FieldBase>(mutableFields),
                new ReadOnlyCollection<NodeBase>(mutableChildren));

            return Builder;
        }

        public static NodePeerList BuildWith(ReadOnlyCollection<NodePeer> Peers)
        {
            //build node
            NodePeerList Builder = BuildWith();

            //add the peer list
            Builder = Builder.Peers.Append(Peers);

            return Builder;
        }
        #endregion

        #region " FIND PEER "
        public NodePeer FindPeerByID(FieldGuid id)
        {
            if (GetChildrenRecursive().ContainsKey(id))
            {
                NodeBase find = GetChildrenRecursive()[id];
                return (NodePeer)find;
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}
