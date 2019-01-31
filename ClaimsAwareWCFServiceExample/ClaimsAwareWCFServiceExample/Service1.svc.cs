using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClaimsAwareWCFServiceExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       public string ComputeResponse(string input)  
    {  
        // Get the caller's identity from ClaimsPrincipal.Current  
        ClaimsPrincipal claimsPrincipal = OperationContext.Current.ClaimsPrincipal;  

        // Start generating the output  
        StringBuilder builder = new StringBuilder();  
        builder.AppendLine("Computed by ClaimsAwareWebService");  
        builder.AppendLine("Input received from client:" + input);  

        if (claimsPrincipal != null)  
        {  
            // Display the claims from the caller. Do not use this code in a production application.  
            ClaimsIdentity identity = claimsPrincipal.Identity as ClaimsIdentity;  
            builder.AppendLine("Client Name:" + identity.Name);  
            builder.AppendLine("IsAuthenticated:" + identity.IsAuthenticated);  
            builder.AppendLine("The service received the following issued claims of the client:");  

            // Iterate over the caller’s claims and append to the output  
            foreach (Claim claim in claimsPrincipal.Claims)  
            {  
                builder.AppendLine("ClaimType :" + claim.Type + "   ClaimValue:" + claim.Value);  
            }  
        }  

        return builder.ToString();  
    } 
    }
}
