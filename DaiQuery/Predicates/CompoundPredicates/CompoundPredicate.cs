﻿using System.Collections.Generic;
using System.Linq;

namespace DaiQuery
{
    public class CompoundPredicate : Predicate, ICompoundPredicate
    {
        private LogicalConnective logicalConnective;
        LogicalConnective ICompoundPredicate.LogicalConnective
        {
            get { return logicalConnective; }
        }

        private List<Predicate> predicates;
        IEnumerable<IPredicate> ICompoundPredicate.Predicates
        {
            get { return predicates.Cast<IPredicate>(); }
        }

        public CompoundPredicate(LogicalConnective logicalConnective)
            : base()
        {
            predicates = new List<Predicate>();
            this.logicalConnective = logicalConnective;
        }

        public void AppendPredicates(IEnumerable<Predicate> children)
        {
            predicates.AddRange(children);
        }

        public void AppendPredicates(params Predicate[] children)
        {
            predicates.AddRange(children);
        }

        protected override bool IsEmpty()
        {
            return predicates == null || !predicates.Any();
        }

        internal override Predicate GetClone()
        {
            CompoundPredicate clone = new CompoundPredicate(this.logicalConnective);
            clone.AppendPredicates(this.predicates.Select(p => p.GetClone()));
            ((IPredicate)clone).IsNegated = ((IPredicate)this).IsNegated;
            return clone;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetCompoundPredicateRenderer<CompoundPredicate>(this);
        }
    }
}
