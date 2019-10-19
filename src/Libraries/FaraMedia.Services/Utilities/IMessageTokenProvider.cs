namespace FaraMedia.Services.Utilities {
    using System.Collections.Generic;

    using FaraMedia.Core.Domain.Billing;

    public interface IMessageTokenProvider {
        void AddOrderTokens(IList<Token> tokens, Order order);
    }
}