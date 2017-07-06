using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public class CompoundPredicate : Predicate, ICompoundPredicate
    {
        private eLogicalConnective logicalConnective;
        eLogicalConnective ICompoundPredicate.LogicalConnective
        {
            get { return logicalConnective; }
        }

        private List<Predicate> predicates;
        IEnumerable<IPredicateInternal> ICompoundPredicate.Predicates
        {
            get { return predicates.Cast<IPredicateInternal>(); }
        }

        public CompoundPredicate(eLogicalConnective logicalConnective)
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
            ((IPredicateInternal)clone).IsNegated = ((IPredicateInternal)this).IsNegated;
            return clone;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetCompoundPredicateRenderer<CompoundPredicate>(this);
        }
    }
}
