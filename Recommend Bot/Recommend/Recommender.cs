using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Recommend_Bot.Recommend
{
    public class Recommender
    {
        private static string AccountKey = ""; // <---  Set to your API key here.
        private const string BaseUri = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0";
        private static RecommendationsApiWrapper recommender = null;
        private static string ModelId = ""; // <---  Set to your Model ID.
        private static long BuildId = 0; // <---  Set to your build ID

        /// <summary>
        /// Constructor that initializes RecommendationApiWrapper
        /// </summary>
        public Recommender()
        {
            recommender = new RecommendationsApiWrapper(AccountKey, BaseUri);
        }

        /// <summary>
        /// Shows how to get item-to-item recommendations
        /// </summary>
        /// <param name="itemId">ItemID</param>
        public String GetRecommendationsItemRequest(string itemId)
        {
            // Get item to item recommendations. (I2I)
            Console.WriteLine();
            Console.WriteLine("Getting Item to Item {0}", itemId);
            var itemSets = recommender.GetRecommendations(ModelId, BuildId, itemId, 6);
            string recoMessage = "";
            if (itemSets.RecommendedItemSetInfo != null)
            {
                foreach (RecommendedItemSetInfo recoSet in itemSets.RecommendedItemSetInfo)
                {
                    foreach (var item in recoSet.Items)
                    {
                        Console.WriteLine("Item id: {0} \n Item name: {1} \t (Rating  {2})", item.Id, item.Name, recoSet.Rating);
                        recoMessage += "Item id; "+item.Id + "Item name: "+item.Name + " \n";
                    }
                }
            }
            else
            {
                Console.WriteLine("No recommendations found.");
            }

            return recoMessage;
            
        }

        /// <summary>
        /// Shows how to get user-to-item-recommendations
        /// </summary>
        /// <param name="userId">User ID</param>
        public String GetRecommendationsUserRequest(string userId)
        {
            
            // Now let's get a user recommendation (U2I)
            Console.WriteLine();
            Console.WriteLine("Getting User Recommendations for User: {0}",userId);
            var itemSets = recommender.GetUserRecommendations(ModelId, BuildId, userId, 6);
            string recoMessage = "";
            if (itemSets.RecommendedItemSetInfo != null)
            {
                foreach (RecommendedItemSetInfo recoSet in itemSets.RecommendedItemSetInfo)
                {
                    foreach (var item in recoSet.Items)
                    {
                        Console.WriteLine("Item id: {0} \n Item name: {1} \t (Rating  {2})", item.Id, item.Name, recoSet.Rating);
                        recoMessage += "Item id; " + item.Id + "Item name: " + item.Name + " \n";
                    }
                }
            }
            else
            {
                Console.WriteLine("No recommendations found.");
            }

            return recoMessage;
        }


    }
}