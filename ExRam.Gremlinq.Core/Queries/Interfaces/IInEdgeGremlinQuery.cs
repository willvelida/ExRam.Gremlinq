﻿using System;

namespace ExRam.Gremlinq.Core
{
    public interface IInEdgeGremlinQueryBase :
        IEdgeGremlinQueryBase
    {

    }

    public partial interface IInEdgeGremlinQueryBase<TEdge, TInVertex> :
        IInEdgeGremlinQueryBase,
        IEdgeGremlinQueryBase<TEdge>
    {
        IBothEdgeGremlinQuery<TEdge, TOutVertex, TInVertex> From<TOutVertex>(Func<IVertexGremlinQuery<TInVertex>, IGremlinQuery<TOutVertex>> fromVertexTraversal);

        new IVertexGremlinQuery<TInVertex> InV();
    }

    public interface IInEdgeGremlinQueryBaseRec<TSelf> :
        IInEdgeGremlinQueryBase,
        IEdgeGremlinQueryBaseRec<TSelf>
        where TSelf : IInEdgeGremlinQueryBaseRec<TSelf>
    {

    }

    public interface IInEdgeGremlinQueryBaseRec<TEdge, TInVertex, TSelf> :
        IInEdgeGremlinQueryBaseRec<TSelf>,
        IInEdgeGremlinQueryBase<TEdge, TInVertex>,
        IEdgeGremlinQueryBaseRec<TEdge, TSelf>
        where TSelf : IInEdgeGremlinQueryBaseRec<TEdge, TInVertex, TSelf>
    {

    }

    public interface IInEdgeGremlinQuery<TEdge, TInVertex> :
        IInEdgeGremlinQueryBaseRec<TEdge, TInVertex, IInEdgeGremlinQuery<TEdge, TInVertex>>
    {

    }
}
