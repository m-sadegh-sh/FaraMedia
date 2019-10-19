namespace FaraMedia.Web.Framework.UI.Sectionation {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using FaraMedia.Web.Framework.UI.Sectionation.Items;
    using FaraMedia.Web.Framework.UI.Sectionation.Renderers;

    public sealed class SectionBuilderContext {
        private List<SectionData> _sectionDatas;
        private readonly ICollection<string> _tags;

        private SectionData _current;

        public SectionBuilderContext() {
            _sectionDatas = new List<SectionData>();
            _tags = new Collection<string>();
        }

        public SectionBuilderContext AddTag(string tag) {
            if (!string.IsNullOrWhiteSpace(tag))
                _tags.Add(tag);

            return this;
        }

        public SectionBuilderContext AddSeparator() {
            return AddSeparatorCore();
        }

        public SectionBuilderContext AddInnerSeparator() {
            return AddSeparatorCore("inner");
        }

        public SectionBuilderContext AddSeparatorCore(params string[] tags) {
            var separator = new SeparatorSectionItem();

            var sectionData = new SectionData {
                Item = separator,
                Type = SectionType.Separator
            };

            sectionData.AddTags(tags);

            _current = sectionData;

            _sectionDatas.Add(sectionData);

            return this;
        }

        public SectionBuilderContext AddHeroUnit(string titleKey, string descriptionKey, params string[] tags) {
            var heroUnit = new HeroUnitSectionItem(titleKey, descriptionKey);

            var sectionData = new SectionData {
                Item = heroUnit,
                Type = SectionType.HeroUnit
            };

            sectionData.AddTags(tags);

            _current = sectionData;

            _sectionDatas.Add(sectionData);

            return this;
        }

        public SectionBuilderContext AddSubHeroUnit(string titleKey, string descriptionKey, string routeName, params string[] tags) {
            return Add(titleKey, descriptionKey, routeName, null, SectionType.SubHeroUnit, tags);
        }

        public SectionBuilderContext Add(string titleKey, string descriptionKey, string routeName, params string[] tags) {
            return Add(titleKey, descriptionKey, routeName, null, tags);
        }

        public SectionBuilderContext Add(string titleKey, string descriptionKey, string routeName, object routeValues, params string[] tags) {
            return Add(titleKey, descriptionKey, routeName, routeValues, SectionType.Section, tags);
        }

        private SectionBuilderContext Add(string titleKey, string descriptionKey, string routeName, object routeValues, SectionType sectionType, params string[] tags) {
            var clickable = new SectionItem(titleKey, descriptionKey, routeName, routeValues);

            var sectionData = new SectionData {
                Item = clickable,
                Type = sectionType
            };

            sectionData.AddTags(tags);

            _current = sectionData;

            _sectionDatas.Add(sectionData);

            return this;
        }

        public SectionBuilderContext If(Expression<Func<bool>> predicate) {
            if (_current != null)
                _current.Item.Predicate = predicate;

            return this;
        }

        public SectionBuilderContext Reset() {
            _sectionDatas.Clear();

            return this;
        }

        public bool Any() {
            return _sectionDatas.Any();
        }

        public MvcHtmlString RenderUsing<TSectionRenderer>(TSectionRenderer sectionRenderer) where TSectionRenderer : SectionRendererBase {
            if (_tags.Any())
                _sectionDatas = _sectionDatas.Where(md => md.Tags.Any(mdt => _tags.Any(t => t == mdt)) || md.Type == SectionType.Separator).ToList();

            var isHeroUnitFound = _sectionDatas.Any(sd => sd.Type == SectionType.HeroUnit);

            if (isHeroUnitFound) {
                foreach (var sectionData in _sectionDatas.ToList()) {
                    if (sectionData.Type == SectionType.Section || sectionData.Tags.Contains("inner"))
                        _sectionDatas.Remove(sectionData);
                }
            } else {
                var isSubHeroUnitFound = false;
                var removeToEnd = false;
                foreach (var sectionData in _sectionDatas.ToList()) {
                    if (!isSubHeroUnitFound && sectionData.Type == SectionType.Section) {
                        _sectionDatas.Remove(sectionData);
                        continue;
                    }

                    if (sectionData.Type == SectionType.SubHeroUnit) {
                        if (!isSubHeroUnitFound)
                            isSubHeroUnitFound = true;
                        else
                            removeToEnd = true;
                    }

                    if (!isSubHeroUnitFound || removeToEnd)
                        _sectionDatas.Remove(sectionData);
                }
            }

            foreach (var sectionData in _sectionDatas.ToList()) {
                if (!sectionData.Item.IsRenderable)
                    _sectionDatas.Remove(sectionData);
            }

            var isPreviousSeparator = false;
            foreach (var sectionData in _sectionDatas.ToList()) {
                if (sectionData.Type == SectionType.Separator) {
                    if (!isPreviousSeparator)
                        isPreviousSeparator = true;
                    else
                        _sectionDatas.Remove(sectionData);
                } else
                    isPreviousSeparator = false;
            }

            if (_sectionDatas.Any()) {
                var first = _sectionDatas.First();
                if (first.Type == SectionType.Separator)
                    _sectionDatas.Remove(first);
            }

            if (_sectionDatas.Any()) {
                var last = _sectionDatas.Last();
                if (last.Type == SectionType.Separator)
                    _sectionDatas.Remove(last);
            }
            
            return sectionRenderer.Render(_sectionDatas);
        }
    }
}