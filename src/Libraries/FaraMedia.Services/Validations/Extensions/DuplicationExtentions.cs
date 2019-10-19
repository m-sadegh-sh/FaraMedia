namespace FaraMedia.Services.Validations.Extensions {
    using FaraMedia.Core.Domain;

    public static class DuplicationExtentions {
        public static bool IsDuplicate<T>(this T dbEntity,T originalEntity)where T:EntityBase {
            return dbEntity != (originalEntity.Id == 0 ? null : originalEntity);
        }
    }
}