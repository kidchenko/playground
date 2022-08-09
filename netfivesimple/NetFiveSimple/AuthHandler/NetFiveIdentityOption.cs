using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;

namespace NetFiveSimple.AuthHandler
{
    public class NetFiveIdentityOption : IConfigureNamedOptions<MicrosoftIdentityOptions>
    {
        public void Configure(MicrosoftIdentityOptions options)
        {
        }

        public void Configure(string name, MicrosoftIdentityOptions options)
        {
            Configure(options);
        }
    }
}