namespace FaraMedia.Web.Framework.UI.Sectionation.Items {
    using System;
    using System.Linq.Expressions;

    public abstract class SectionItemBase {
        private bool? _isRenderable;

        public Expression<Func<bool>> Predicate { private get; set; }

        public bool IsRenderable {
            get {
                if (_isRenderable == null && Predicate != null)
                    _isRenderable = Predicate.Compile()();
                else
                    _isRenderable = true;

                return (bool) _isRenderable;
            }
        }
    }
}