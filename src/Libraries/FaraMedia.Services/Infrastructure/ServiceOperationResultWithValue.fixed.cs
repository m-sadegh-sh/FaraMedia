namespace FaraMedia.Services.Infrastructure {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Querying.Systematic;

    public sealed class ServiceOperationResultWithValue<T> : ServiceOperationResult {
        public T Value { get; set; }

        public ServiceOperationResultWithValue<T> With(T value) {
            Value = value;

            return this;
        }
    }
}