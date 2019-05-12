using FirstMvc.Models;
using System.Collections.Generic;

namespace FirstMvc.Infrastructure
{
    public static class Repository
    {
        private static List<GuestResponseModel> responses = new List<GuestResponseModel>();

        public static IEnumerable<GuestResponseModel> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(GuestResponseModel response)
        {
            responses.Add(response);
        }
    }
}