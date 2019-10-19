namespace FaraMedia.Services.Extensions.Systematic {
    using System;
    using System.Collections.Generic;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Events;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Querying.Systematic;

    using NHibernate;
    using NHibernate.Validator.Engine;

    public sealed class InMemoryResourceValueService : DbService<ResourceValue, ResourceValueQuery> {
        private static readonly IList<ResourceValue> _resourceValues = new List<ResourceValue>();

        public InMemoryResourceValueService(ISession session, IEventPublisher eventPublisher, ValidationProvider<ResourceValue> validationProvider) : base(session, eventPublisher, validationProvider) {}

        public override IList<ResourceValue> GetAll(Action<ResourceValueQuery> queryBuilder = null) {
            return _resourceValues;
        }

        public override ServiceOperationResult Save(ResourceValue resourceValue, bool validateChilds = false) {
            _resourceValues.Add(resourceValue);

            return null;
        }
    }
}