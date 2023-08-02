using MDMPlatform.Tests;
using MDMPlatform.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;


namespace MDMIdentity.Tests.Configuration
{
    public class WebContentDirectoryFinder_Tests  : MDMPlatformTestBase
    {

        

        [Fact]
        public async Task CalculateContentRootFolder()
        {
            var output = WebContentDirectoryFinder.CalculateContentRootFolder("mdm-identity-service", "MDM.Identity.Self-host");
            output.ShouldNotBeNull();
        }
    }
}
