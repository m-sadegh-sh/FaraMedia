namespace FaraMedia.Services.Extensions.Shared {
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Querying.Shared;

    using TB.ComponentModel;

	public static class EntityAttributeServiceExtensions {
        public static T GetById<T>(this IDbService<EntityAttribute, EntityAttributeQuery> service, long id, T fallbackValue, bool load = false) {
			if (Neutrals.Is(id))
                return fallbackValue;

            var attribute = service.GetById(id);

            if (attribute == null)
                return fallbackValue;

            if (!attribute.Value.CanConvertTo<T>())
                return fallbackValue;

	        var convertedValue = attribute.Value.ConvertTo<T>();

            return convertedValue;
        }

        public static EntityAttribute GetByOwnerIdAndKey(this IDbService<EntityAttribute, EntityAttributeQuery> service, long ownerId, string key) {
			if (Neutrals.Is(ownerId))
                return null;

            if (Neutrals.Is(key))
                return null;

            var attribute = service.Get(eaq=>eaq.WithOwnerId(ownerId).WithKey(key));

            return attribute;
        }

        public static T GetValueByOwnerIdAndKey<T>(this IDbService<EntityAttribute, EntityAttributeQuery> service, long ownerId, string key, T fallbackValue) {
			if (Neutrals.Is(ownerId))
                return fallbackValue;

            if (Neutrals.Is(key))
                return fallbackValue;

            var attribute = service.GetByOwnerIdAndKey(ownerId, key);

            if (attribute == null)
                return fallbackValue;

            if (!attribute.Value.CanConvertTo<T>())
                return fallbackValue;

	        var convertedValue = attribute.Value.ConvertTo<T>();

            return convertedValue;
        }

        public static ServiceOperationResultWithValue<EntityAttribute> Save<T>(this IDbService<EntityAttribute, EntityAttributeQuery> service, long ownerId, string systemName, T value) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<EntityAttribute>>();

			if (Neutrals.Is(ownerId))
            {
                result.AddResourceError(EntityAttributeConstants.Messages.InvalidOwnerId);
                return result;
            }

            if (!value.CanConvertTo<string>()) {
                result.AddResourceError(EntityAttributeConstants.Messages.NotSupportedValueType);
                return result;
            }

	        var convertedValue = value.ConvertTo<string>();

            var attribute = service.GetByOwnerIdAndKey(ownerId, systemName);

            if (attribute != null) {
                attribute.Value = convertedValue;

                result.CopyFrom(service.Save(attribute));
            } else {
                attribute = new EntityAttribute {
                    OwnerId = ownerId,
                    Key = systemName,
                    Value = convertedValue,
                };

                result.CopyFrom(service.Save(attribute));
            }

            return result.With(attribute);
        }
    }
}