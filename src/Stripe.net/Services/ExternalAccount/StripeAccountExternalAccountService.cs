using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeAccountExternalAccountService : StripeService
    {
        public StripeAccountExternalAccountService(string apiKey = null) : base(apiKey) { }

        //Sync
        public virtual StripeBankAccount Create(string accountId, StripeAccountExternalAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/accounts/{accountId}/external_accounts"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        //Async
        public virtual async Task<StripeBankAccount> CreateAsync(string accountId, StripeAccountExternalAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/accounts/{accountId}/external_accounts"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }
    }
}